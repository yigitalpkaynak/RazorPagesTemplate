using razorpagesExample.Models;

namespace razorpagesExample.Repository;

public class SQLEmployeeRepository : IEmployeeRepository
{
    private readonly DataContext _context;
    public SQLEmployeeRepository(DataContext dataContext)
    {
        _context = dataContext;
    }

    public IEnumerable<Employee> GetAll()
    {
        return _context.Employees.ToList();
    }

    public Employee GetById(int id)
    {
        return _context.Employees.FirstOrDefault(i => i.Id == id)!;
    }

    public Employee? Update(Employee entity)
    {
        var entityToUpdate = _context.Employees.FirstOrDefault(i => i.Id == entity.Id);

        if(entityToUpdate != null)
        {
            entityToUpdate.Name = entity.Name;
            entityToUpdate.Email = entity.Email;
            entityToUpdate.Deparment = entity.Deparment;
            entityToUpdate.Photo = entity.Photo;
            _context.SaveChanges();
        }
        return entityToUpdate!;
    }
}
