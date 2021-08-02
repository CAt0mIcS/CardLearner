
namespace CardLearner
{
	partial class CardLearner
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.btnMinimize = new System.Windows.Forms.Button();
			this.btnClose = new System.Windows.Forms.Button();
			this.pnlViews = new System.Windows.Forms.Panel();
			this.btnSettings = new System.Windows.Forms.Button();
			this.btnEdit = new System.Windows.Forms.Button();
			this.btnPractice = new System.Windows.Forms.Button();
			this.btnViews = new System.Windows.Forms.Button();
			this.lstviewPracticeCards = new System.Windows.Forms.ListView();
			this.contextMenuPracticeCards = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.resetProgressToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.txtFront = new System.Windows.Forms.RichTextBox();
			this.txtBack = new System.Windows.Forms.RichTextBox();
			this.btnSolve = new System.Windows.Forms.Button();
			this.btnAgain = new System.Windows.Forms.Button();
			this.btnHard = new System.Windows.Forms.Button();
			this.btnGood = new System.Windows.Forms.Button();
			this.btnEasy = new System.Windows.Forms.Button();
			this.pnlViews.SuspendLayout();
			this.contextMenuPracticeCards.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnMinimize
			// 
			this.btnMinimize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
			this.btnMinimize.FlatAppearance.BorderSize = 0;
			this.btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnMinimize.Font = new System.Drawing.Font("Nirmala UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnMinimize.ForeColor = System.Drawing.SystemColors.Control;
			this.btnMinimize.Location = new System.Drawing.Point(621, 0);
			this.btnMinimize.Name = "btnMinimize";
			this.btnMinimize.Size = new System.Drawing.Size(35, 35);
			this.btnMinimize.TabIndex = 23;
			this.btnMinimize.Text = "_";
			this.btnMinimize.UseVisualStyleBackColor = false;
			this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click);
			// 
			// btnClose
			// 
			this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
			this.btnClose.FlatAppearance.BorderSize = 0;
			this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnClose.Font = new System.Drawing.Font("Nirmala UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnClose.ForeColor = System.Drawing.SystemColors.Control;
			this.btnClose.Location = new System.Drawing.Point(662, 0);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(35, 35);
			this.btnClose.TabIndex = 22;
			this.btnClose.Text = "X";
			this.btnClose.UseVisualStyleBackColor = false;
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			// 
			// pnlViews
			// 
			this.pnlViews.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(188)))), ((int)(((byte)(156)))));
			this.pnlViews.Controls.Add(this.btnSettings);
			this.pnlViews.Controls.Add(this.btnEdit);
			this.pnlViews.Controls.Add(this.btnPractice);
			this.pnlViews.Location = new System.Drawing.Point(0, 47);
			this.pnlViews.Name = "pnlViews";
			this.pnlViews.Size = new System.Drawing.Size(143, 408);
			this.pnlViews.TabIndex = 24;
			this.pnlViews.VisibleChanged += new System.EventHandler(this.pnlViews_VisibleChanged);
			// 
			// btnSettings
			// 
			this.btnSettings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(168)))), ((int)(((byte)(126)))));
			this.btnSettings.BackgroundImage = global::CardLearner.Properties.Resources.Settings_Icon;
			this.btnSettings.FlatAppearance.BorderSize = 0;
			this.btnSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSettings.Font = new System.Drawing.Font("Nirmala UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnSettings.ForeColor = System.Drawing.SystemColors.Control;
			this.btnSettings.Location = new System.Drawing.Point(3, 370);
			this.btnSettings.Name = "btnSettings";
			this.btnSettings.Size = new System.Drawing.Size(35, 35);
			this.btnSettings.TabIndex = 27;
			this.btnSettings.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnSettings.UseVisualStyleBackColor = false;
			// 
			// btnEdit
			// 
			this.btnEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(168)))), ((int)(((byte)(126)))));
			this.btnEdit.FlatAppearance.BorderSize = 0;
			this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnEdit.Font = new System.Drawing.Font("Nirmala UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnEdit.ForeColor = System.Drawing.SystemColors.Control;
			this.btnEdit.Location = new System.Drawing.Point(0, 97);
			this.btnEdit.Name = "btnEdit";
			this.btnEdit.Size = new System.Drawing.Size(143, 35);
			this.btnEdit.TabIndex = 26;
			this.btnEdit.Text = "Edit Deck";
			this.btnEdit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnEdit.UseVisualStyleBackColor = false;
			// 
			// btnPractice
			// 
			this.btnPractice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(168)))), ((int)(((byte)(126)))));
			this.btnPractice.FlatAppearance.BorderSize = 0;
			this.btnPractice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnPractice.Font = new System.Drawing.Font("Nirmala UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnPractice.ForeColor = System.Drawing.SystemColors.Control;
			this.btnPractice.Location = new System.Drawing.Point(0, 56);
			this.btnPractice.Name = "btnPractice";
			this.btnPractice.Size = new System.Drawing.Size(143, 35);
			this.btnPractice.TabIndex = 25;
			this.btnPractice.Text = "Practice";
			this.btnPractice.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnPractice.UseVisualStyleBackColor = false;
			this.btnPractice.Click += new System.EventHandler(this.btnPractice_Click);
			// 
			// btnViews
			// 
			this.btnViews.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
			this.btnViews.BackgroundImage = global::CardLearner.Properties.Resources.ViewOpenIcon;
			this.btnViews.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.btnViews.FlatAppearance.BorderSize = 0;
			this.btnViews.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnViews.Font = new System.Drawing.Font("Nirmala UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnViews.ForeColor = System.Drawing.SystemColors.Control;
			this.btnViews.Location = new System.Drawing.Point(3, 50);
			this.btnViews.Name = "btnViews";
			this.btnViews.Size = new System.Drawing.Size(61, 35);
			this.btnViews.TabIndex = 25;
			this.btnViews.UseVisualStyleBackColor = false;
			this.btnViews.Click += new System.EventHandler(this.btnViews_Click);
			// 
			// lstviewPracticeCards
			// 
			this.lstviewPracticeCards.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
			this.lstviewPracticeCards.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lstviewPracticeCards.ContextMenuStrip = this.contextMenuPracticeCards;
			this.lstviewPracticeCards.Font = new System.Drawing.Font("Myanmar Text", 15.75F);
			this.lstviewPracticeCards.ForeColor = System.Drawing.SystemColors.Control;
			this.lstviewPracticeCards.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
			this.lstviewPracticeCards.HideSelection = false;
			this.lstviewPracticeCards.Location = new System.Drawing.Point(205, 99);
			this.lstviewPracticeCards.MultiSelect = false;
			this.lstviewPracticeCards.Name = "lstviewPracticeCards";
			this.lstviewPracticeCards.Size = new System.Drawing.Size(435, 333);
			this.lstviewPracticeCards.TabIndex = 25;
			this.lstviewPracticeCards.UseCompatibleStateImageBehavior = false;
			this.lstviewPracticeCards.View = System.Windows.Forms.View.Details;
			this.lstviewPracticeCards.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.lstviewPracticeCards_ItemSelectionChanged);
			// 
			// contextMenuPracticeCards
			// 
			this.contextMenuPracticeCards.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
			this.contextMenuPracticeCards.DropShadowEnabled = false;
			this.contextMenuPracticeCards.Font = new System.Drawing.Font("Nirmala UI", 11F);
			this.contextMenuPracticeCards.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.resetProgressToolStripMenuItem});
			this.contextMenuPracticeCards.Name = "contextMenuPracticeCards";
			this.contextMenuPracticeCards.Size = new System.Drawing.Size(175, 28);
			// 
			// resetProgressToolStripMenuItem
			// 
			this.resetProgressToolStripMenuItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.resetProgressToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.resetProgressToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
			this.resetProgressToolStripMenuItem.Name = "resetProgressToolStripMenuItem";
			this.resetProgressToolStripMenuItem.Size = new System.Drawing.Size(174, 24);
			this.resetProgressToolStripMenuItem.Text = "Reset Progress";
			this.resetProgressToolStripMenuItem.Click += new System.EventHandler(this.resetProgressToolStripMenuItem_Click);
			// 
			// txtFront
			// 
			this.txtFront.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
			this.txtFront.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtFront.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtFront.Font = new System.Drawing.Font("Nirmala UI", 15F);
			this.txtFront.Location = new System.Drawing.Point(205, 47);
			this.txtFront.Name = "txtFront";
			this.txtFront.ReadOnly = true;
			this.txtFront.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
			this.txtFront.Size = new System.Drawing.Size(451, 166);
			this.txtFront.TabIndex = 26;
			this.txtFront.Text = "";
			this.txtFront.Visible = false;
			// 
			// txtBack
			// 
			this.txtBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
			this.txtBack.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtBack.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtBack.Font = new System.Drawing.Font("Nirmala UI", 15F);
			this.txtBack.Location = new System.Drawing.Point(205, 219);
			this.txtBack.Name = "txtBack";
			this.txtBack.ReadOnly = true;
			this.txtBack.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
			this.txtBack.Size = new System.Drawing.Size(451, 166);
			this.txtBack.TabIndex = 27;
			this.txtBack.Text = "";
			this.txtBack.Visible = false;
			// 
			// btnSolve
			// 
			this.btnSolve.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
			this.btnSolve.FlatAppearance.BorderSize = 0;
			this.btnSolve.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSolve.Font = new System.Drawing.Font("Nirmala UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnSolve.ForeColor = System.Drawing.SystemColors.Control;
			this.btnSolve.Location = new System.Drawing.Point(205, 397);
			this.btnSolve.Name = "btnSolve";
			this.btnSolve.Size = new System.Drawing.Size(82, 46);
			this.btnSolve.TabIndex = 28;
			this.btnSolve.Text = "Solve";
			this.btnSolve.UseVisualStyleBackColor = false;
			this.btnSolve.Visible = false;
			this.btnSolve.Click += new System.EventHandler(this.btnSolve_Click);
			// 
			// btnAgain
			// 
			this.btnAgain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
			this.btnAgain.FlatAppearance.BorderSize = 0;
			this.btnAgain.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnAgain.Font = new System.Drawing.Font("Nirmala UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnAgain.ForeColor = System.Drawing.Color.Red;
			this.btnAgain.Location = new System.Drawing.Point(293, 397);
			this.btnAgain.Name = "btnAgain";
			this.btnAgain.Size = new System.Drawing.Size(89, 46);
			this.btnAgain.TabIndex = 29;
			this.btnAgain.Text = "Again";
			this.btnAgain.UseVisualStyleBackColor = false;
			this.btnAgain.Visible = false;
			this.btnAgain.Click += new System.EventHandler(this.btnAgain_Click);
			// 
			// btnHard
			// 
			this.btnHard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
			this.btnHard.FlatAppearance.BorderSize = 0;
			this.btnHard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnHard.Font = new System.Drawing.Font("Nirmala UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnHard.ForeColor = System.Drawing.SystemColors.Control;
			this.btnHard.Location = new System.Drawing.Point(385, 397);
			this.btnHard.Name = "btnHard";
			this.btnHard.Size = new System.Drawing.Size(89, 46);
			this.btnHard.TabIndex = 30;
			this.btnHard.Text = "Hard";
			this.btnHard.UseVisualStyleBackColor = false;
			this.btnHard.Visible = false;
			this.btnHard.Click += new System.EventHandler(this.btnHard_Click);
			// 
			// btnGood
			// 
			this.btnGood.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
			this.btnGood.FlatAppearance.BorderSize = 0;
			this.btnGood.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnGood.Font = new System.Drawing.Font("Nirmala UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnGood.ForeColor = System.Drawing.Color.Chartreuse;
			this.btnGood.Location = new System.Drawing.Point(480, 397);
			this.btnGood.Name = "btnGood";
			this.btnGood.Size = new System.Drawing.Size(89, 46);
			this.btnGood.TabIndex = 31;
			this.btnGood.Text = "Good";
			this.btnGood.UseVisualStyleBackColor = false;
			this.btnGood.Visible = false;
			this.btnGood.Click += new System.EventHandler(this.btnGood_Click);
			// 
			// btnEasy
			// 
			this.btnEasy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
			this.btnEasy.FlatAppearance.BorderSize = 0;
			this.btnEasy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnEasy.Font = new System.Drawing.Font("Nirmala UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnEasy.ForeColor = System.Drawing.Color.Aqua;
			this.btnEasy.Location = new System.Drawing.Point(575, 397);
			this.btnEasy.Name = "btnEasy";
			this.btnEasy.Size = new System.Drawing.Size(89, 46);
			this.btnEasy.TabIndex = 32;
			this.btnEasy.Text = "Easy";
			this.btnEasy.UseVisualStyleBackColor = false;
			this.btnEasy.Visible = false;
			this.btnEasy.Click += new System.EventHandler(this.btnEasy_Click);
			// 
			// CardLearner
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
			this.ClientSize = new System.Drawing.Size(699, 455);
			this.Controls.Add(this.btnEasy);
			this.Controls.Add(this.btnGood);
			this.Controls.Add(this.btnHard);
			this.Controls.Add(this.btnAgain);
			this.Controls.Add(this.btnSolve);
			this.Controls.Add(this.txtBack);
			this.Controls.Add(this.txtFront);
			this.Controls.Add(this.btnViews);
			this.Controls.Add(this.lstviewPracticeCards);
			this.Controls.Add(this.pnlViews);
			this.Controls.Add(this.btnMinimize);
			this.Controls.Add(this.btnClose);
			this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "CardLearner";
			this.Text = "Card Learner";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.CardLearner_FormClosed);
			this.Resize += new System.EventHandler(this.CardLearner_Resize);
			this.pnlViews.ResumeLayout(false);
			this.contextMenuPracticeCards.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.Button btnMinimize;
		private System.Windows.Forms.Button btnClose;
		private System.Windows.Forms.Panel pnlViews;
		private System.Windows.Forms.Button btnViews;
		private System.Windows.Forms.Button btnPractice;
		private System.Windows.Forms.Button btnEdit;
		private System.Windows.Forms.Button btnSettings;
		private System.Windows.Forms.ListView lstviewPracticeCards;
		private System.Windows.Forms.RichTextBox txtFront;
		private System.Windows.Forms.RichTextBox txtBack;
		private System.Windows.Forms.Button btnSolve;
		private System.Windows.Forms.Button btnAgain;
		private System.Windows.Forms.Button btnHard;
		private System.Windows.Forms.Button btnGood;
		private System.Windows.Forms.Button btnEasy;
		private System.Windows.Forms.ContextMenuStrip contextMenuPracticeCards;
		private System.Windows.Forms.ToolStripMenuItem resetProgressToolStripMenuItem;
	}
}
