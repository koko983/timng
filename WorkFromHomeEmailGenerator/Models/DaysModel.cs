using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WorkFromHomeEmailGenerator.Models
{
	public class DaysModel
	{
		public IEnumerable<Day> Days { get; set; }

		public double Sum => Days.Sum(d => d.Sum);
	}
}