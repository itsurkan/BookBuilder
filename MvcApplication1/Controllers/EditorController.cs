using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
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
                    MvcApplication.logger.Info(ViewBag.Content);
                    return View(doc);
                }
                catch (Exception e)
                {
                    MvcApplication.logger.Info("Error");
                    MvcApplication.logger.Info(e.Message);

                }

            }
            return View((Document)ViewBag.Document);

        }

        public ActionResult  Save(string doc)
        {
            //string path = @"~\Files\" + doc.Project1.UserLogin + @"\" + doc.Project1.Path + @"\" + doc.Path +
            //                     @"\" + doc.Name;
           // System.IO.File.WriteAllText(path, doc);
            Log.Info("Save button clicked:");
            //Log.Info(id);
            Log.Info(doc);
            return View("Index",(Document)ViewBag.Document);




        }
    }
}
