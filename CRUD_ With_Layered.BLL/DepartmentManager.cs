using CRUD__With_Layered.Model.EntityModels;
using CRUD__With_Layered.Repository;
using System.Collections.Generic;

namespace CRUD__With_Layered.BLL
{
    public class DepartmentManager
    {
        DepartmentRepository departmentRepository;
        public DepartmentManager()
        {
            departmentRepository = new DepartmentRepository();
        }

        public bool Add(Department entity)
        {
            if (entity == null || entity.Name == "")
            {
                return false;
            }
            return departmentRepository.Add(entity);
        }

        public Department GetById(int? id)
        {
            if (id == null)
            {
                return null;
            }
            return departmentRepository.GetById(id);
        }

        public bool Update(Department entity)
        {
            return departmentRepository.Update(entity);
        }

        public ICollection<Department> GetAll()
        {
            return departmentRepository.GetAll();
        }

        public bool Delete(int? id)
        {
            if (id != null && id > 0)
            {
                return departmentRepository.Delete(id);
            }
            return false;
        }
    }
}
   

