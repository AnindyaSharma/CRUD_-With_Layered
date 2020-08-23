using CRUD__With_Layered.Database.Database;
using CRUD__With_Layered.Model.EntityModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRUD__With_Layered.Repositories
{
    public class EmployeeRepository
    {
        CRUDWithLayeredDbContext db;
        public EmployeeRepository()
        {
            db = new CRUDWithLayeredDbContext();
        }

        public bool Add(Employee entity)
        {
            db.Employees.Add(entity);
            return db.SaveChanges() > 0;
        }

        public Employee GetById(int? id)
        {
            return db.Employees.Find(id);
        }

        public bool Update(Employee entity)
        {
            db.Entry(entity).State = EntityState.Modified;
            return db.SaveChanges() > 0;
        }

        public ICollection<Employee> GetAll()
        {
            return db.Employees.Include(c => c.Department).ToList();
        }

        public bool Delete(int? id)
        {
            Employee emp = db.Employees.Find(id);
            if (emp != null)
            {
                db.Employees.Remove(emp);
                return db.SaveChanges() > 0;
            }

            return false;
        }

        public ICollection<Employee> GetAllById(int? id)
        {
            return db.Employees.Where(c => c.DepartmentId == id).Include(c=>c.Department).ToList();
        }
    }
}
