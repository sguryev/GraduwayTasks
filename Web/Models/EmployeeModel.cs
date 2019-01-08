﻿namespace GraduwayTasks.Web.Models
{
    using Base;

    public class EmployeeModel: EntityModelBase
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Position { get; set; }
    }
}
