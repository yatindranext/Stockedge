using StockEdge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StockEdge.Controllers
{
    public class HomeController : Controller
    {
        EmpCapSysDBEntities empDB = new EmpCapSysDBEntities();
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

        public ActionResult EmployeeTbl()
        {
            return View();
        }

        public ActionResult Create()
        {
            List<EmpDepTbl> empList = new List<EmpDepTbl>();

            var depList = empDB.EmpDepTbls.ToList();

            if(depList != null)
            {

                ViewBag.List = depList.ToList();

            }

            return View();
        }

        [HttpPost]
        public ActionResult Submit()
        {
            

            return View();
        }
    }
}