using GraphqlCRUDOperations.Data;
using GraphqlCRUDOperations.Models;
using Microsoft.EntityFrameworkCore;

namespace GraphqlCRUDOperations
{
    public class Query
    {
        [UsePaging(IncludeTotalCount =true, DefaultPageSize =5)]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Employee> GetEmployees(AppDbContext db) => 
             db.EmployeeTable;

        public async Task<Employee?> GetEmployeesById(int id, AppDbContext db) =>
            await db.EmployeeTable.FindAsync(id);
    }
}
