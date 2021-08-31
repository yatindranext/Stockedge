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

        public ActionResult EmployeeTbl(int type = 1 )
        {

            var empdetails = empDB.EmpTbls.OrderBy(x => x.Name).ToList();

            decimal dedu = 0;
            decimal finalsly = 0;
            if(type == 2)
            {
                 empdetails = empDB.EmpTbls.OrderBy(x => x.DepartmentID).ToList();
            }
            foreach (var item in empdetails)
            {
                if(item.AnnualSalary <= 250000)
                {
                    item.AnnualSalary = item.AnnualSalary;
                }
                else if (item.AnnualSalary > 250000 && item.AnnualSalary < 500000)
                {
                    dedu = (item.AnnualSalary * 5) / 100;
                    finalsly = item.AnnualSalary - dedu;

                    item.AnnualSalary = finalsly;
                }
                else if (item.AnnualSalary > 500000 && item.AnnualSalary < 1000000)
                {
                    dedu = (item.AnnualSalary * 20) / 100;
                    finalsly = item.AnnualSalary - dedu;

                    item.AnnualSalary = finalsly;
                }
                else if (item.AnnualSalary > 1000000)
                {
                    dedu = (item.AnnualSalary * 30) / 100;
                    finalsly = item.AnnualSalary - dedu;

                    item.AnnualSalary = finalsly;
                }

                item.Year = DateTime.Now.Year - item.DateOfJoining.Year;
                item.Month = DateTime.Now.Month - item.DateOfJoining.Month;
            }
            return View(empdetails);
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
        public ActionResult Submit(EmpTbl emp)
        {
            try
            {
                if(emp != null)
                {
                    var data = new EmpTbl
                    {
                        Name = emp.Name,
                        Address = emp.Address,
                        DateOfJoining = emp.DateOfJoining,
                        IsCurrentEmp = emp.IsCurrentEmp,
                        AnnualSalary = emp.AnnualSalary,
                        DepartmentID = emp.DepartmentID

                    };
                    empDB.EmpTbls.Add(data);
                    empDB.SaveChanges();
                }
            }
            catch(Exception ex)
            {

            }
            

            return View();
        }
    }
}