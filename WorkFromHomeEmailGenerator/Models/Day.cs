using System;
using System.Collections.Generic;
using System.Linq;

namespace WorkFromHomeEmailGenerator.Models
{
	public class Day
	{
		public DateTime Date { get; set; }

		public IEnumerable<DateTimeRange> Hours { get; set; }

		public WorkProject ASIPortal { get; set; }

		public WorkProject TSNPortal { get; set; }

		public double Sum => Hours.Sum(r => r.TotalMinutes);
	}
}