using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CardLearner
{
	class Deck : IEnumerable
	{
		public string Name { get; private set; }
		[JsonInclude]
		public int NumAgain = 0;
		[JsonInclude]
		public int NumTodo = 0;
		[JsonInclude]
		public int NumDone = 0;
		[JsonInclude]
		private List<Card> mCards = new List<Card>();

		public Deck()
		{
		}

		public Deck(string path)
		{
			Name = Path.GetFileNameWithoutExtension(path);
			using (JsonDocument doc = JsonDocument.Parse(File.ReadAllText(path)))
			{
				foreach (JsonElement card in doc.RootElement.GetProperty("Cards").EnumerateArray())
				{
					mCards.Add(JsonSerializer.Deserialize<Card>(card.GetRawText()));
				}
			}
		}

		/// <summary>
		/// Checks the date on every card and figures out if it needs to be studied again
		/// </summary>
		/// <returns>Cards which need to be studied</returns>
		public List<Card> GetCardsToStudy()
		{
			List<Card> cardsToStudy = new List<Card>();
			foreach (Card card in mCards)
			{
				if (card.NextReviewDate <= DateTime.Now)
					cardsToStudy.Add(card);
			}
			return cardsToStudy;
		}

		public void ExportToFile(string path)
		{
			var options = new JsonSerializerOptions { WriteIndented = true };
			var data =
				new
				{
					NumAgain = NumAgain,
					NumTodo = NumTodo,
					NumDone = NumDone,
					Cards = mCards,
				};
			string serializedStr = JsonSerializer.Serialize(data, options);

			using (var writer = new StreamWriter(path))
			{
				writer.Write(serializedStr);
			}
		}

		public void ResetProgress()
		{
			foreach (Card card in mCards)
				card.ResetProgress();
		}

		public IEnumerator GetEnumerator()
		{
			return mCards.GetEnumerator();
		}

		public override string ToString()
		{
			return Name;
		}

		public Card this[int index]
		{
			get => GetValue(index);
			set => SetValue(index, value);
		}

		private Card GetValue(int index)
		{
			return mCards[index];
		}

		private void SetValue(int index, Card value)
		{
			mCards[index] = value;
		}
	}
}
