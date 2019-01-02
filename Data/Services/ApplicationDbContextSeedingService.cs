namespace GraduwayTasks.Data.Services
{
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using Model;
    using Model.Enums;

    public class ApplicationDbContextSeedingService
    {
        private readonly ApplicationDbContext _dbContext;

        public ApplicationDbContextSeedingService(
            ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task EnsureMigratedAndSeededAsync()
        {
            await _dbContext.Database.MigrateAsync().ConfigureAwait(false);

            if (!await _dbContext.Employees.AnyAsync())
            {
                var employees = new[]
                {
                    new Employee {FirstName = "John", LastName = "Doe", Position = "Manager"},
                    new Employee {FirstName = "Bill", LastName = "White", Position = "CTO"},
                    new Employee {FirstName = "Jane", LastName = "Black", Position = "CEO"},
                    new Employee {FirstName = "Mark", LastName = "Filch", Position = "Developer"},
                    new Employee {FirstName = "Tom", LastName = "Trump", Position = "Tester"}
                };

                foreach (var employee in employees)
                {
                    employee.WorkItems = new[]
                    {
                        new WorkItem {Title = $"Task for {employee.FirstName} 1", State = State.New, Priority = Priority.Medium, Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua"},
                        new WorkItem {Title = $"Task for {employee.FirstName} 2", State = State.Active, Priority = Priority.Critical, Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua"},
                        new WorkItem {Title = $"Task for {employee.FirstName} 3", State = State.Resolved, Priority = Priority.Medium, Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua"},
                        new WorkItem {Title = $"Task for {employee.FirstName} 4", State = State.New, Priority = Priority.Low, Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua"},
                        new WorkItem {Title = $"Task for {employee.FirstName} 5", State = State.Resolved, Priority = Priority.Critical, Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua"},
                        new WorkItem {Title = $"Task for {employee.FirstName} 6", State = State.Active, Priority = Priority.Medium, Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua"},
                        new WorkItem {Title = $"Task for {employee.FirstName} 7", State = State.Resolved, Priority = Priority.Low, Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua"},
                        new WorkItem {Title = $"Task for {employee.FirstName} 8", State = State.Active, Priority = Priority.Critical, Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua"},
                    };
                }

                _dbContext.Employees.AddRange(employees);

                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
