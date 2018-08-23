using System;
using System.Collections.Generic;

namespace WorkFromHomeEmailGenerator.Models
{
	public class Day
	{
		public DateTime Date { get; set; }

		public IEnumerable<DateTimeRange> Hours { get; set; }

		public WorkProject ASIPortal { get; set; }

		public WorkProject TSNPortal { get; set; }
	}
}