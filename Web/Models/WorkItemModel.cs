﻿namespace GraduwayTasks.Web.Models
{
    using Base;
    using Data.Model.Enums;

    public class WorkItemModel: EntityModelBase
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public Priority Priority { get; set; }

        public State State { get; set; }

        public string EmployeeId { get; set; }
    }
}
