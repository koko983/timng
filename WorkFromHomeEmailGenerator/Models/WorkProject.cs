using System.Collections.Generic;
using System.Linq;

namespace WorkFromHomeEmailGenerator.Models
{
	public class WorkProject
	{
		public IEnumerable<Bug> Bugs { get; set; }

		public IEnumerable<WorkTask> Tasks { get; set; }

		public IEnumerable<Changeset> Changesets { get; set; }

		public bool HasWork
		{
			get
			{
				return Tasks.Any() || Bugs.Any() || Changesets.Any();
			}
		}

		public WorkProject()
		{
			Bugs = new HashSet<Bug>();
			Tasks = new HashSet<WorkTask>();
			Changesets = new HashSet<Changeset>();
		}

		public string GetMyShit()
		{
			var strings = new List<string>();
			if (Tasks.Any())
			{
				strings.Add($"<strong class='text-success'>Tasks</strong> <i>{Tasks.GetItemDescription()}</i>");
			}
			if (Bugs.Any())
			{
				strings.Add($"<strong class='text-danger'>Bugs</strong> <i>{Bugs.GetItemDescription()}</i>");
			}
			if (Changesets.Any())
			{
				strings.Add($"<strong class='text-info'>Changesets</strong> <i>{Changesets.GetItemDescription()}</i>");
			}

			return string.Join("-", strings);
		}
	}
}