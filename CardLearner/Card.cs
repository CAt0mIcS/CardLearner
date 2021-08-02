using System;
using System.Text.Json.Serialization;

namespace CardLearner
{
	public class Card
	{
		[JsonInclude]
		public string Front = "";
		[JsonInclude]
		public string Back = "";

		[JsonIgnore]
		private DateTime mReviewDate;

		/// <summary>
		/// Specifies the date when the card was last reviewed
		/// </summary>
		[JsonInclude]
		public DateTime ReviewDate
		{
			get => mReviewDate;
			set
			{
				mReviewDate = value;
				NextReviewDate = mReviewDate.AddDays(InterRepetitionInterval);
			}
		}

		[JsonIgnore]
		public DateTime NextReviewDate { get; private set; }

		private float mInterRepetitionInterval = 0;
		/// <summary>
		/// The inter-repetition is the length of time (in days) SuperMemo will wait after the 
		/// previous review before asking the user to review the card again.
		/// </summary>
		[JsonInclude]
		public float InterRepetitionInterval
		{
			get => mInterRepetitionInterval;
			set
			{
				mInterRepetitionInterval = value;
				NextReviewDate = NextReviewDate.AddDays(mInterRepetitionInterval);
			}
		}

		/// <summary>
		/// The repetition number is the number of times the card has been 
		/// (meaning it was given a grade ≥ 3) in a row since the last time it was not.
		/// </summary>
		[JsonInclude]
		public int SuccessfulRepetitions = 0;

		/// <summary>
		/// The easiness factor loosely indicates how "easy" the card is 
		/// (more precisely, it determines how quickly the inter-repetition interval grows).
		/// </summary>
		[JsonInclude]
		public float EasinessFactor = 2.5f;


		public void ResetProgress()
		{
			EasinessFactor = 2.5f;
			SuccessfulRepetitions = 0;
			mInterRepetitionInterval = 0;
			NextReviewDate = DateTime.Now;
		}
	}
}
