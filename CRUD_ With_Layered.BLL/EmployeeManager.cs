using CRUD__With_Layered.Model.EntityModels;
using CRUD__With_Layered.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRUD__With_Layered.BLL
{
    public class EmployeeManager
    {
        EmployeeRepository employeeRepository;
        public EmployeeManager()
        {
            employeeRepository = new EmployeeRepository();
        }

        public bool Add(Employee entity)
        {
            if (entity == null)
            {
                return false;
            }
            return employeeRepository.Add(entity);
        }

        public Employee GetById(int? id)
        {
            if (id == null)
            {
                return null;
            }
            return employeeRepository.GetById(id);
        }

        public bool Update(Employee entity)
        {
            return employeeRepository.Update(entity);
        }

        public ICollection<Employee> GetAll()
        {
            return employeeRepository.GetAll();
        }

        public bool Delete(int? id)
        {
            if (id != null && id > 0)
            {
                return employeeRepository.Delete(id);
            }
            return false;
        }

        public ICollection<Employee> GetAllById(int? id)
        {
            return employeeRepository.GetAllById(id);
        }
    }
}
