namespace GraduwayTasks.Web.Services.Employee
{
    using System.Threading;
    using Data;
    using Data.Model;
    using Models;

    public interface IEmployeeService
    {
        Employee CreateEmployee(EmployeePostModel model, ApplicationDbContext dbContext);
    }
}