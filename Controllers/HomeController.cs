using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EmplyeeDetail.Models;
namespace EmplyeeDetail.Controllers
{
    public class HomeController : Controller
    {
        EmployeeDataAccessModel objemployee = new EmployeeDataAccessModel();
        public ActionResult Index()
        {
            List<Models.EmployeeDataModel> lstEmployee = new List<EmployeeDataModel>();

            lstEmployee = objemployee.GetAllEmployees().ToList();
            return View(lstEmployee);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind] EmployeeDataModel employee)
        {
            if (ModelState.IsValid)

            {
                objemployee.AddEmployee(employee);
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return null;
            }
            EmployeeDataModel employee = objemployee.GetEmployeeData(id);
            if (employee == null)
            {
                return null;
            }
            return View(employee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [Bind]EmployeeDataModel employee)
        {
            if (id != employee.EmployeelD)
            {
                return null;
            }
            if (ModelState.IsValid)

            {
                objemployee.UpdateEmployee(employee);
                return RedirectToAction("Index");
            }
            return View(employee);
        }




    }
}