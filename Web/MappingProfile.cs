namespace GraduwayTasks.Web
{
    using AutoMapper;
    using Data.Model;
    using Models;

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            MapEmployee();
            MapWorkItem();
        }

        private void MapEmployee()
        {
            CreateMap<Employee, EmployeeModel>();
        }

        private void MapWorkItem()
        {
            CreateMap<WorkItem, WorkItemModel>();
        }
    }
}
