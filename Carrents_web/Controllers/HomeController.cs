using Carrents_web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Carrents_web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult SendEmail()
        {
            return View(new SendEmailViewModel());
        }

        [HttpPost]
        public ActionResult SendEmail(SendEmailViewModel model, HttpPostedFileBase Attachment)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    String toEmail = model.ToEmail;
                    String subject = model.Subject;
                    String contents = model.Contents;
                     model.filename = Attachment.FileName;
                    String serverPath = Server.MapPath("~/Uploadfile/");
                    model.Path = serverPath + model.filename;
                    Attachment.SaveAs(model.Path);
                    SendEmail es = new SendEmail();
                    es.Send(toEmail, subject, contents, model.filename, model.Path);

                    ViewBag.Result = "Email has been send.";

                    ModelState.Clear();

                    return View(new SendEmailViewModel());
                }
                catch
                {
                    return View();
                }
            }
     return View();
        }
    }
}