using GraphqlCRUDOperations.Data;
using GraphqlCRUDOperations.Models;

namespace GraphqlCRUDOperations
{
    public class Mutation
    {
        public async Task<Employee> AddEmployee(string name, string email, string dept, AppDbContext db)

        {
            var newEmployee = new Employee
            {
                Name = name,
                Email = email,
                Department = dept
            };
            db.EmployeeTable.Add(newEmployee);
            await db.SaveChangesAsync();
            return newEmployee;
        }

        public async Task<Employee?> UpdateEmployee (int id, string name, string email, string dept, AppDbContext db)
        {
            var employee = await db.EmployeeTable.FindAsync(id);

            if(employee == null)
            {
               throw new GraphQLException ("Employee not found");
            }

            employee.Name = name;
            employee.Email = email;
            employee.Department = dept;

            await db.SaveChangesAsync();

            return employee;


        }

        public async Task<string> DeleteEmployee (int id,  AppDbContext db)
        {
            var employee = await db.EmployeeTable.FindAsync(id);

            if(employee == null)
            {
                throw new GraphQLException("Employee not found");
            }

            db.EmployeeTable.Remove(employee);
            await db.SaveChangesAsync();
            return "Employee deleted Successfully";
        }
        




    }
}
