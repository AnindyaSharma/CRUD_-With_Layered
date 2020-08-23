using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD__With_Layered.Models
{
    public class EmployeeEditViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Salary { get; set; }

        public int? DepartmentId { get; set; }
        public ICollection<SelectListItem> DepartmentItems { get; set; }
    }
}
