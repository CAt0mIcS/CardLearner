using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace CardLearner
{
	public partial class CardLearner : Form
	{
		private const int mGripSize = 16;
		private const int mCaptionBarHeight = 35 + 6 + 6;
		private SolidBrush mMoveBarBrush = new SolidBrush(Color.FromArgb(34, 40, 54));
		private ListViewItem mSelectedDeck = null;
		private List<Card> mCurrentStudyCards = null;
		public const int UserGradeAgain = 0;
		public const int UserGradeHard = 3;
		public const int UserGradeGood = 4;
		public const int UserGradeEasy = 5;

		/// <summary>
		/// Specifies if the next review time should be recalculated and updated (true in normal study, false in custom study)
		/// </summary>
		private bool mUpdateTimes = true;

		/// <summary>
		/// Specifies how far the close button is away from the right window border
		/// and the free distance between the minimize and close button.
		/// </summary>
		private const int mFormBorderSpace = 6;


		public CardLearner()
		{
			InitializeComponent();
			SetStyle(ControlStyles.UserPaint, true);
			SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
			SetStyle(ControlStyles.AllPaintingInWmPaint, true);

			List<ListViewItem> listViewItems = new List<ListViewItem>();
			int longestName = -2;
			int longestNumber = -2;


			foreach (Deck deck in Program.Decks)
			{
				ListViewItem item = new ListViewItem(deck.Name);
				item.SubItems.Add(deck.NumAgain.ToString());
				item.SubItems.Add(deck.NumTodo.ToString());
				item.SubItems.Add(deck.NumDone.ToString());
				listViewItems.Add(item);

				// Figure out best size for columns 
				Size textSize = TextRenderer.MeasureText(deck.Name, lstviewPracticeCards.Font);
				if (textSize.Width > longestName)
					longestName = textSize.Width;

				textSize = TextRenderer.MeasureText(deck.NumAgain.ToString(), lstviewPracticeCards.Font);
				if (textSize.Width > longestNumber)
					longestNumber = textSize.Width;
				textSize = TextRenderer.MeasureText(deck.NumTodo.ToString(), lstviewPracticeCards.Font);
				if (textSize.Width > longestNumber)
					longestNumber = textSize.Width;
				textSize = TextRenderer.MeasureText(deck.NumDone.ToString(), lstviewPracticeCards.Font);
				if (textSize.Width > longestNumber)
					longestNumber = textSize.Width;
			}

			// Create columns for the items and subitems.
			// Width of -2 indicates auto-size.
			lstviewPracticeCards.Columns.Add("Name", longestName, HorizontalAlignment.Left);
			lstviewPracticeCards.Columns.Add("ProgressionAgain", longestNumber, HorizontalAlignment.Right);
			lstviewPracticeCards.Columns.Add("ProgressionTodo", longestNumber, HorizontalAlignment.Right);
			lstviewPracticeCards.Columns.Add("ProgressionDone", longestNumber, HorizontalAlignment.Right);
			lstviewPracticeCards.Items.AddRange(listViewItems.ToArray());
		}

		#region BorderBasics
		private void CardLearner_Resize(object sender, EventArgs e)
		{
			btnClose.Location = new Point(Size.Width - btnClose.Size.Width - mFormBorderSpace, btnClose.Location.Y);
			btnMinimize.Location = new Point(Size.Width - btnClose.Size.Width - mFormBorderSpace - btnMinimize.Size.Width - mFormBorderSpace, btnMinimize.Location.Y);
			pnlViews.Height = Height - mCaptionBarHeight;
			btnSettings.Location = new Point(btnSettings.Location.X, pnlViews.Height - mFormBorderSpace - btnSettings.Height);
			Refresh();
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			// Draw move bar
			Rectangle rc = new Rectangle(ClientSize.Width - mGripSize, ClientSize.Height - mGripSize, mGripSize, mGripSize);
			ControlPaint.DrawSizeGrip(e.Graphics, BackColor, rc);
			rc = new Rectangle(0, 0, ClientSize.Width, mCaptionBarHeight);
			e.Graphics.FillRectangle(mMoveBarBrush, rc);

			// Draw point before selected deck
			if (mSelectedDeck != null)
			{
				int diameter = 10;
				Point pos = new Point(lstviewPracticeCards.Location.X - 20, mSelectedDeck.Position.Y + lstviewPracticeCards.Location.Y + (mSelectedDeck.Bounds.Height / 2 - diameter));
				Rectangle rect = new Rectangle(pos, new Size(diameter, diameter));
				e.Graphics.FillEllipse(mMoveBarBrush, rect);
			}
		}

		protected override void WndProc(ref Message m)
		{
			if (m.Msg == 0x84)
			{
				// Trap WM_NCHITTEST

				Point pos = new Point(m.LParam.ToInt32());
				pos = PointToClient(pos);
				if (pos.Y < mCaptionBarHeight)
				{
					m.Result = (IntPtr)2;  // HTCAPTION

					return;
				}
				if (pos.X >= ClientSize.Width - mGripSize && pos.Y >= ClientSize.Height - mGripSize)
				{
					m.Result = (IntPtr)17; // HTBOTTOMRIGHT

					return;
				}
			}
			base.WndProc(ref m);
		}

		private void btnClose_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void btnMinimize_Click(object sender, EventArgs e)
		{
			WindowState = FormWindowState.Minimized;
		}
		#endregion

		private void btnPractice_Click(object sender, EventArgs e)
		{
			if (mSelectedDeck == null)
				return;

			foreach (Deck deck in Program.Decks)
			{
				if (deck.Name == mSelectedDeck.Text)
				{
					LoadPracticeWindow(deck);
					break;
				}
			}
		}

		private bool InPracticeWindow()
		{
			return btnViews.Text == "<<";
		}

		#region RandomizeListOrder
		[ThreadStatic] private Random Local;
		private Random ThisThreadsRandom()
		{
			return Local ?? (Local = new Random(unchecked(Environment.TickCount * 31 + Thread.CurrentThread.ManagedThreadId)));
		}

		private void Shuffle<T>(IList<T> list)
		{
			int n = list.Count;
			while (n > 1)
			{
				n--;
				int k = ThisThreadsRandom().Next(n + 1);
				T value = list[k];
				list[k] = list[n];
				list[n] = value;
			}
		}
		#endregion

		private void LoadPracticeWindow(Deck deck)
		{
			List<Card> cardsToStudy = deck.GetCardsToStudy();
			if (cardsToStudy.Count == 0)
			{
				DialogResult result = MessageBox.Show("Nothing to study for now. Do you want to review all cards in this deck? The time to the next review will only be changed if you answer incorrectly (Again/Hard)",
					"Deck unavailable", MessageBoxButtons.YesNo);
				if (result == DialogResult.Yes)
				{
					// CL_TODO: Fix custom study session
					mUpdateTimes = false;
					foreach (Card card in deck.Cards)
						cardsToStudy.Add(card);
				}
				else
					return;
			}
			pnlViews.Hide();
			btnViews.Text = "<<";
			btnViews.BackgroundImage = null;
			mSelectedDeck = null;
			lstviewPracticeCards.Visible = false;
			txtFront.Visible = true;
			txtBack.Visible = true;
			btnSolve.Visible = true;
			txtBack.Text = "";

			Shuffle(cardsToStudy);
			txtFront.Text = cardsToStudy[0].Front;
			mCurrentStudyCards = cardsToStudy;
		}

		private void UnloadPracticeWindow()
		{
			pnlViews.Show();
			btnViews.BackgroundImage = Properties.Resources.ViewOpenIcon;
			btnViews.Text = "";
			lstviewPracticeCards.Visible = true;
			txtFront.Visible = false;
			txtBack.Visible = false;
			mCurrentStudyCards = null;
			btnSolve.Visible = false;
			btnAgain.Visible = false;
			btnHard.Visible = false;
			btnGood.Visible = false;
			btnEasy.Visible = false;
			btnSolve.Text = "Solve";
			mUpdateTimes = true;
		}

		private void lstviewPracticeCards_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
		{
			if (!e.IsSelected && e.Item != mSelectedDeck)
				mSelectedDeck = null;
			else
			{
				if (lstviewPracticeCards.SelectedItems.Count > 0)
				{
					mSelectedDeck = lstviewPracticeCards.SelectedItems[0];
					Refresh();
				}
			}

			e.Item.Selected = false;
		}

		private void CardLearner_FormClosed(object sender, FormClosedEventArgs e)
		{
			foreach (Deck deck in Program.Decks)
				deck.ExportToFile(Path.Combine(Program.DeckDirectory, deck.Name) + ".deck");
		}

		private void btnViews_Click(object sender, EventArgs e)
		{
			// Use normal panel show/hide button event
			if (btnViews.BackgroundImage != null)
			{
				pnlViews.Visible = !pnlViews.Visible;
			}
			// Use as back button
			else if (InPracticeWindow())
			{
				UnloadPracticeWindow();
			}

		}

		private void pnlViews_VisibleChanged(object sender, EventArgs e)
		{
			// Move controls next to panel 
			if (pnlViews.Visible)
			{
				lstviewPracticeCards.Location = new Point(lstviewPracticeCards.Location.X + pnlViews.Size.Width, lstviewPracticeCards.Location.Y);
			}
			else
			{
				lstviewPracticeCards.Location = new Point(lstviewPracticeCards.Location.X - pnlViews.Size.Width, lstviewPracticeCards.Location.Y);
			}
		}

		private void btnSolve_Click(object sender, EventArgs e)
		{
			if (btnSolve.Text == "Solve")
			{
				txtBack.Text = mCurrentStudyCards[0].Back;
				btnAgain.Visible = true;
				btnHard.Visible = true;
				btnGood.Visible = true;
				btnEasy.Visible = true;

				DisplayReviewTimes();
			}
			else if (btnSolve.Text == "Quit")
			{
				UnloadPracticeWindow();
			}
		}

		/// <summary>
		/// Display when card will be reviewed again dependent on btn(Again/Hard/Good/Easy)
		/// </summary>
		private void DisplayReviewTimes()
		{
			Func<int, float> getReviewTime = (int userGrade) =>
			{
				return CalculateInterRepetitionInterval(userGrade, mCurrentStudyCards[0], CalculateEasinessFactor(mCurrentStudyCards[0], userGrade));
			};

			Func<string, float, string> getReviewTimeString = (string str, float factor) =>
			{
				string suffix = "d";
				// convert days to months
				if (factor > 30)
				{
					factor /= 30;
					suffix = "mon";
				}
				// leave at days
				else if (factor >= 1)
				{
				}
				// convert days to hours (at 3h)
				else if (factor > 0.125f)
				{
					factor *= 24;
					suffix = "h";
				}
				// convert days to minutes
				else
				{
					factor *= 24 * 60;
					suffix = "min";
				}
				return str + factor + suffix;
			};

			btnAgain.Text = getReviewTimeString("Again\n", getReviewTime(UserGradeAgain));
			btnHard.Text = getReviewTimeString("Hard\n", getReviewTime(UserGradeHard));
			btnGood.Text = getReviewTimeString("Good\n", getReviewTime(UserGradeGood));
			btnEasy.Text = getReviewTimeString("Easy\n", getReviewTime(UserGradeEasy));
		}

		private static float CalculateEasinessFactor(Card card, int userGrade)
		{
			return card.EasinessFactor + (0.1f - (5 - userGrade) * (0.08f + (5 - userGrade) * 0.02f)); //default
		}

		private static float CalculateInterRepetitionInterval(int userGrade, Card card, float easinessFactor = float.MaxValue)
		{
			Func<float, float, float> getInterRepetitionInterval = (float factor0, float factor1) =>
			{
				if (easinessFactor == float.MaxValue)
					easinessFactor = card.EasinessFactor;

				if (card.SuccessfulRepetitions == 0)
					return factor0;
				else if (card.SuccessfulRepetitions == 1)
					return factor1;
				else
					return card.InterRepetitionInterval * easinessFactor;
			};

			switch (userGrade)
			{
				case UserGradeEasy:
					return getInterRepetitionInterval(1.0f, 4.0f); //4d
				case UserGradeGood:
					return getInterRepetitionInterval(6.944444444444444e-3f, 1.0f); // 10min - 1d
				case UserGradeHard:
					return getInterRepetitionInterval(0.0041666666666666f, 0.0041666666666666f); // 6min - 10min
				case UserGradeAgain:
					return 6.944444444444444e-4f; // 1min
			}
			throw new ArgumentException("userGrade " + userGrade + " is invalid.");
		}

		private static void SuperMemoAlgorithm(int userGrade, Card card)
		{
			// Correct response
			if (userGrade >= 3)
			{
				card.InterRepetitionInterval = CalculateInterRepetitionInterval(userGrade, card);
				card.EasinessFactor = CalculateEasinessFactor(card, userGrade);
				if (card.EasinessFactor < 1.3f)
					card.EasinessFactor = 1.3f;

				++card.SuccessfulRepetitions;
			}
			// Incorrect response
			else
			{
				card.SuccessfulRepetitions = 0;
				card.InterRepetitionInterval = 0.0069444444444444f; // 10 minutes, default: 1
			}
		}

		private void LoadNextCard(bool deletePrevious)
		{
			mCurrentStudyCards[0].ReviewDate = DateTime.Now;

			if (deletePrevious && mCurrentStudyCards[0].SuccessfulRepetitions >= 2)
				mCurrentStudyCards.RemoveAt(0);
			else
			{
				// Move card to random place
				Card card = mCurrentStudyCards[0];
				mCurrentStudyCards.RemoveAt(0);
				mCurrentStudyCards.Insert(new Random().Next(0, mCurrentStudyCards.Count), card);
			}

			btnAgain.Visible = false;
			btnHard.Visible = false;
			btnGood.Visible = false;
			btnEasy.Visible = false;

			if (mCurrentStudyCards.Count == 0)
			{
				btnSolve.Text = "Quit";
				return;
			}

			txtFront.Text = mCurrentStudyCards[0].Front;
			txtBack.Text = "";
		}

		private void btnAgain_Click(object sender, EventArgs e)
		{
			SuperMemoAlgorithm(UserGradeAgain, mCurrentStudyCards[0]);
			LoadNextCard(false);
		}

		private void btnHard_Click(object sender, EventArgs e)
		{
			SuperMemoAlgorithm(UserGradeHard, mCurrentStudyCards[0]);
			LoadNextCard(false);
		}

		private void btnGood_Click(object sender, EventArgs e)
		{
			if (mUpdateTimes)
				SuperMemoAlgorithm(UserGradeGood, mCurrentStudyCards[0]);
			LoadNextCard(true);
		}

		private void btnEasy_Click(object sender, EventArgs e)
		{
			if (mUpdateTimes)
				SuperMemoAlgorithm(UserGradeEasy, mCurrentStudyCards[0]);
			LoadNextCard(true);
		}

		private void resetProgressToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (mSelectedDeck == null)
				return;
			foreach (Deck deck in Program.Decks)
				if (deck.Name == mSelectedDeck.Text)
					deck.ResetProgress();
		}
	}
}
