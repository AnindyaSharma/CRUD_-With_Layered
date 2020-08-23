using CRUD__With_Layered.Database.Database;
using CRUD__With_Layered.Model.EntityModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRUD__With_Layered.Repository
{
    public class DepartmentRepository
    {
        CRUDWithLayeredDbContext db;
        public DepartmentRepository()
        {
            db = new CRUDWithLayeredDbContext();
        }

        public bool Add(Department entity)
        {
            db.Departments.Add(entity);
            return db.SaveChanges() > 0;
        }

        public Department GetById(int? id)
        {
            return db.Departments.Find(id);
        }

        public bool Update(Department entity)
        {
            db.Entry(entity).State = EntityState.Modified;
            return db.SaveChanges() > 0;
        }

        public ICollection<Department> GetAll()
        {
            return db.Departments.ToList();
        }

        public bool Delete(int? id)
        {
            Department depart = db.Departments.Find(id);
            if (depart != null)
            {
                db.Departments.Remove(depart);
                return db.SaveChanges() > 0;
            }

            return false;
        }
    }
}
