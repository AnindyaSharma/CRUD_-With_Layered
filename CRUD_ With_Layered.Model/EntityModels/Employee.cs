using System;
using System.Collections.Generic;
using System.Text;

namespace CRUD__With_Layered.Model.EntityModels
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Salary { get; set; }

        public int? DepartmentId { get; set; }
        public Department Department { get; set; }


    }
}
