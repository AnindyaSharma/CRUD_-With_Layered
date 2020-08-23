using CRUD__With_Layered.Model.EntityModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD__With_Layered.Models
{
    public class DepByEmpViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Salary { get; set; }
        public Employee Employee { get; set; }
        public List<Employee> Employees { get; set; }
        public int? DepartmentId { get; set; }
        public ICollection<SelectListItem> DepartmentItems { get; set; }
    }
}
