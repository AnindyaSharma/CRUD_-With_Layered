using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRUD__With_Layered.BLL;
using CRUD__With_Layered.Model.EntityModels;
using Microsoft.AspNetCore.Mvc;

namespace CRUD__With_Layered.Controllers
{
    public class DepartmentController : Controller
    {
        DepartmentManager departmentManager;
        public DepartmentController()
        {
            departmentManager = new DepartmentManager();
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Department department)
        {
            if (ModelState.IsValid)
            {
                bool isSaved = departmentManager.Add(department);
                if (isSaved)
                {
                    return RedirectToAction("List", "Department", null);
                }
            }

            return View();
        }

        public IActionResult List()
        {
            ICollection<Department> departmentList = departmentManager.GetAll();
            return View(departmentList);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            Department dep =departmentManager.GetById(id);
            return View(dep);
        }

        [HttpPost]
        public IActionResult Edit(Department dep)
        {
            bool isSaved = departmentManager.Update(dep);
            if (isSaved)
            {
                return RedirectToAction("List", "Department", null);
            }
            return View();
        }

        public IActionResult Delete(int? id)
        {
            bool isSaved = departmentManager.Delete(id);
            if (isSaved)
            {
                return RedirectToAction("List", "Department", null);
            }
            return View("List");
        }
    }
}