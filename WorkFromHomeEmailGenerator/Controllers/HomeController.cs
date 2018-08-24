using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WorkFromHomeEmailGenerator.Models;

namespace WorkFromHomeEmailGenerator.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public ActionResult Go(DaysModel model)
		{
			var output = RenderPartialViewToString("EmailTemplate", model);
			var html = new HtmlDocument();
			html.LoadHtml(output);
			var virtualLocation = $"/Content/{DateTime.Now.ToFileTime()}_generatedEmail.html";
			html.Save(Server.MapPath(virtualLocation));

			return Json(new { success = true, place = virtualLocation });
		}

		private string RenderPartialViewToString(string viewName, object model)
		{
			if (string.IsNullOrEmpty(viewName))
			{
				viewName = ControllerContext.RouteData.GetRequiredString("action");
			}

			ViewData.Model = model;
			using (StringWriter sWriter = new StringWriter())
			{
				ViewEngineResult viewResult = ViewEngines.Engines.FindPartialView(ControllerContext, viewName);
				ViewContext viewContext = new ViewContext(ControllerContext, viewResult.View, ViewData, TempData, sWriter);
				viewResult.View.Render(viewContext, sWriter);
				return sWriter.GetStringBuilder().ToString();
			}
		}
	}
}