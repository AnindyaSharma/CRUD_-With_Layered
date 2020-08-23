using System;
using System.Collections.Generic;
using System.Text;

namespace CRUD__With_Layered.Model.EntityModels
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Employee> Employees { get; set; }
    }
}
