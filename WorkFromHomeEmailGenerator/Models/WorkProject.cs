using System.Collections.Generic;
using System.Linq;

namespace WorkFromHomeEmailGenerator.Models
{
	public class WorkProject
	{
		public IEnumerable<Bug> Bugs { get; set; }

		public IEnumerable<WorkTask> Tasks { get; set; }

		public IEnumerable<Changeset> Changesets { get; set; }

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

			return string.Join(" - ", strings);
		}
	}

	public static class WorkProjectExtensions
	{
		public static bool HasWork(this WorkProject project)
		{
			return project != null && (project.Tasks.Any() || project.Bugs.Any() || project.Changesets.Any());
		}
	}
}
