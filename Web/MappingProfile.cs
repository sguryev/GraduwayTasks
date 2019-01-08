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

            CreateMap<EmployeePostModel, Employee>();
        }

        private void MapWorkItem()
        {
            CreateMap<WorkItem, WorkItemModel>();

            CreateMap<WorkItemPostModel, WorkItem>();
        }
    }
}
