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
        public ActionResult Index(int? id)
        {
            int stevilka = id ?? 1;
            var data = (from x in db.TestDatas
                        where x.IdPostaje==stevilka
                        orderby x.Id descending
                        select x).Take(30);
            ViewData["id"] = stevilka;
            return View(data);
        }

        public ActionResult ZadnjiPodatki(int? id)
        {
            int stevilka = id ?? 1;
            var data1 = (from x in db.TestDatas
                         where x.IdPostaje==stevilka
                         orderby x.Id descending
                        select x).Take(5);
            return PartialView("zadnji", data1);
        }
        
    }
}
