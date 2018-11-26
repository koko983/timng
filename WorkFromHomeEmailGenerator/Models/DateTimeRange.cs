using System;

namespace WorkFromHomeEmailGenerator.Models
{
	public class DateTimeRange
	{
		public DateTime Start { get; set; }

		public DateTime End { get; set; }

		public double TotalMinutes => (End - Start).TotalMinutes;
	}
}