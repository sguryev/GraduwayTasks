namespace GraduwayTasks.Web.Services.Employee
{
    using AutoMapper;
    using Data;
    using Data.Model;
    using Data.Model.Enums;
    using Models;

    public class EmployeeService : IEmployeeService
    {
        private readonly IMapper _mapper;

        public EmployeeService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public Employee CreateEmployee(EmployeePostModel model, ApplicationDbContext dbContext)
        {
            var entity = _mapper.Map<Employee>(model);

            dbContext.Employees.Add(entity);

            dbContext.WorkItems.AddRange(
                new WorkItem
                {
                    Title = "Change the password",
                    Description = "This is a default task for new employee",
                    Priority = Priority.Critical,
                    State = State.New,
                    EmployeeId = entity.Id
                },
                new WorkItem
                {
                    Title = "Read the policies",
                    Description = "This is a default task for new employee",
                    Priority = Priority.Medium,
                    State = State.New,
                    EmployeeId = entity.Id
                }
            );

            return entity;
        }
    }
}
