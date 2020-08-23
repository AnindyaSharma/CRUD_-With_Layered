using System.Collections.Generic;
using System.Linq;
using CRUD__With_Layered.BLL;
using CRUD__With_Layered.Model.EntityModels;
using CRUD__With_Layered.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CRUD__With_Layered.Controllers
{
    public class EmployeeController : Controller
    {
        EmployeeManager employeeManager;
        DepartmentManager departmentManager;
        public EmployeeController()
        {
            employeeManager = new EmployeeManager();
            departmentManager = new DepartmentManager();
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            EmployeeCreateViewModel departmentList = new EmployeeCreateViewModel();
            departmentList.DepartmentItems = departmentManager.GetAll().ToList().Select(c => new SelectListItem()
            {
                Text = c.Name,
                Value = c.Id.ToString()
            }).ToList();


            return View(departmentList);
        }

        [HttpPost]
        public IActionResult Create(EmployeeCreateViewModel model)
        {
            if (model != null)
            {
                Employee employee = new Employee()
                {
                    Name = model.Name,
                    Email = model.Email,
                    Salary = model.Salary,
                    DepartmentId = model.DepartmentId
                };
                bool isSaved = employeeManager.Add(employee);
                if (isSaved)
                {
                    return RedirectToAction("List");
                }
            }
            return View("List");
        }

        public IActionResult List()
        {
            List<Employee> employeeList = employeeManager.GetAll().ToList();
            return View(employeeList);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            var model = employeeManager.GetById(id);
            EmployeeEditViewModel emplist = new EmployeeEditViewModel()
            {
                Id = model.Id,
                Name = model.Name,
                Email = model.Email,
                Salary = model.Salary,
                DepartmentId = model.DepartmentId,
                DepartmentItems = departmentManager.GetAll().ToList().Select(c => new SelectListItem()
                {
                    Text = c.Name,
                    Value = c.Id.ToString()
                }).ToList()
            };
            if (emplist != null)
            {
                return View(emplist);
            }
            return View();
        }

        [HttpPost]
        public IActionResult Edit(Employee employee)
        {
            if (employee != null)
            {
                bool isSaved = employeeManager.Update(employee);
                if (isSaved)
                {
                    return RedirectToAction("List");
                }
            }
            return View();
        }

        public IActionResult Delete(int? id)
        {
            if (id != null && id > 0)
            {
                bool isSaved = employeeManager.Delete(id);
                if (isSaved)
                {
                    return RedirectToAction("List");
                }
            }
            return View();
        }

        [HttpGet]
        public IActionResult GetAllById()
        {
            DepByEmpViewModel departmentList = new DepByEmpViewModel();
            departmentList.DepartmentItems = departmentManager.GetAll().ToList().Select(c => new SelectListItem()
            {
                Text = c.Name,
                Value = c.Id.ToString()
            }).ToList();
            return View(departmentList);
        }

        [HttpPost]
        public IActionResult GetAllById(DepByEmpViewModel empview)
        {
            var depId = empview.DepartmentId;
            if (depId != null)
            {
                List<Employee> employeeList = employeeManager.GetAllById(depId).ToList();
                
                return View("EmployeeListView", employeeList);
            }
            return View();
        }
    }
}
