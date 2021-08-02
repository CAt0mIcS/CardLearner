using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace CardLearner
{
	static class Program
	{
		public static List<Deck> Decks = new List<Deck>();
		public static string DeckDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "CardLearner\\Decks");

		[STAThread]
		static void Main()
		{
			// Load in all decks from the default directory
			Directory.CreateDirectory(DeckDirectory);
			foreach (string file in Directory.GetFiles(DeckDirectory, "*.deck", SearchOption.AllDirectories))
			{
				Decks.Add(new Deck(file));
			}

			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new CardLearner());
		}
	}
}
