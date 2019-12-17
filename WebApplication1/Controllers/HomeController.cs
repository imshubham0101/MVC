using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Filter;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        DbEntities mydb = new DbEntities();

        [SBfilter]
        public ActionResult Index()
        {
            return View("index", mydb.Employees.ToList());
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
            mydb.SaveChanges();
            return Redirect("/Home/Index");

        }

        public ActionResult Delete(int id)
        {
            Employee emp = mydb.Employees.Find(id);
            mydb.Employees.Remove(emp);
            mydb.SaveChanges();
            return Redirect("/Home/Index");
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult AfterCreate(Employee emp)
        {
            mydb.Employees.Add(emp);
            mydb.SaveChanges();
            return Redirect("/Home/Index");
        }

    }
}