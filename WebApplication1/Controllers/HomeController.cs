using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        DbEntities mydb = new DbEntities();


        public ActionResult Home()
        {
            return View("home", mydb.Employees.ToList());
        }

       public ActionResult Edit(int id)
        {
            Employee emp = mydb.Employees.Find(id);
            return View("edit", emp);
        }
        public ActionResult AfterEdit(Employee emp)
        {
            Employee oldEmp = mydb.Employees.Find(emp.Id);
            oldEmp.Name = emp.Name;
            oldEmp.Address = emp.Address;
            return View("Home");

        }

    }
}