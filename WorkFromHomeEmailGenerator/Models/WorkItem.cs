using System.Collections.Generic;
using System.Linq;

namespace WorkFromHomeEmailGenerator.Models
{
	public abstract class WorkItem
	{
		public int Number { get; set; }
	}

	public static class WorkItemExtensions
	{
		public static string GetItemDescription(this IEnumerable<WorkItem> workItems)
		{
			return string.Join(",", workItems.Select(t => t.Number.ToString()));
		}
	}
}