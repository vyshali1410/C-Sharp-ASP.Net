using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Employee.Controllers
{
    public class EmployeeController : Controller
    {
        DataClasses1DataContext obj = new DataClasses1DataContext();
        // GET: Employee
        public ActionResult Index()
        {
            var record = from x in obj.employees select x;
            return View(record);
        }

        public ActionResult Salary()
        {
            var data = from x in obj.employees
                       where x.Salary > 2000 && x.Salary < 10000
                       select x;
            return View(data);
        }
        public ActionResult Names()
        {
            var data = from x in obj.employees
                       where x.Name == "James"
                       select x;
            return View(data);
        }
        public ActionResult Address()
        {
            var data = from x in obj.employees
                       where x.Address == "ON"
                       select x;
            return View(data);
        }
    }
}