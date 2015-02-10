using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mime;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.HtmlControls;
using MvcApplication1.DbModels;

namespace MvcApplication1.Controllers
{
    [Authorize]
    public class EditorController : Controller
    {
        public readonly Entities db = MvcApplication.RepoContext;
        public NLog.Logger Log = MvcApplication.logger;

        public ActionResult Index(int? id)
        {
            MvcApplication.logger.Info("Enter to editor at {0}", DateTime.Now);

            if (id != null)
            {
                try
                {
                    Document doc = db.Documents.Find(id);
                    string path = @"~\Files\" + doc.Project1.UserLogin + @"\" + doc.Project1.Path + @"\" + doc.Path +
                                  @"\" + doc.Name;
                    MvcApplication.logger.Info(path);


                    ViewBag.Content = System.IO.File.ReadAllText(Server.MapPath(path));
                    ViewBag.Document = doc;
                    MvcApplication.logger.Info(doc.Name);
                    return View();
                }
                catch (Exception e)
                {
                    MvcApplication.logger.Info("Error");
                    MvcApplication.logger.Info(e.Message);

                }

            }
            return View((Document)ViewBag.Document);

        }

        [HttpPost]
        public void Save(string textAnswer, int id)
        {
            //string path = @"~\Files\" + doc.Project1.UserLogin + @"\" + doc.Project1.Path + @"\" + doc.Path +
            //                     @"\" + doc.Name;
           // System.IO.File.WriteAllText(path, doc);
            Log.Info("Save button clicked:");
          
            //Log.Info(doc.GetType());

            Log.Info("Exit save");
            //return doc.ToString();
            //View("Index",(Document)ViewBag.Document);
        }
    }
}
