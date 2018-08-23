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
			html.Save(Server.MapPath($"~/Content/generatedEmail{DateTime.Now.ToShortDateString()}.html"));

			return Json(new { success = true, message = "done" });
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