using HospitalAPI.Data;
using HospitalAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace HospitalAPI.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly AppDbContext _context;

        public DepartmentRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<Department> GetAll()
        {
            return _context.Departments.ToList();
        }

        public Department? GetById(int id)
        {
            return _context.Departments
                .FirstOrDefault(d => d.DepartmentId == id);
        }

        public Department Add(Department department)
        {
            _context.Departments.Add(department);
            _context.SaveChanges();

            return department;
        }

        public Department? Update(int id, Department department)
        {
            var existingDepartment = _context.Departments
                .FirstOrDefault(d => d.DepartmentId == id);

            if (existingDepartment == null)
            {
                return null;
            }

            existingDepartment.DepartmentName = department.DepartmentName;
            existingDepartment.Description = department.Description;

            _context.SaveChanges();

            return existingDepartment;
        }

        public bool Delete(int id)
        {
            var department = _context.Departments
                .FirstOrDefault(d => d.DepartmentId == id);

            if (department == null)
            {
                return false;
            }

            _context.Departments.Remove(department);
            _context.SaveChanges();

            return true;
        }
    }
}