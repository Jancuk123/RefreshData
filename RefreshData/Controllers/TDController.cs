using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RefreshData.Models;

namespace RefreshData.Controllers
{
    public class TDController : Controller
    {
        private RDContext db = new RDContext();

        // GET: TD
        public ActionResult Index()
        {
            var data = (from x in db.TestDatas
                        select x).Take(30);

            return View(data);
        }

        public ActionResult ZadnjiPodatki()
        {
            int randomSkip = new Random().Next(1, 1000);
            var data1 = (from x in db.TestDatas
                         orderby x.Id
                        select x).Skip(randomSkip).Take(5);
            return PartialView("zadnji", data1);
        }
        
    }
}
