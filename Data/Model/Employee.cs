namespace GraduwayTasks.Data.Model
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Base;

    public class Employee: EntityBase
    {
        [Required, StringLength(128)]
        public string FirstName { get; set; }

        [Required, StringLength(128)]
        public string LastName { get; set; }

        [Required, StringLength(128)]
        public string Position { get; set; }

        #region Navigations

        public ICollection<WorkItem> WorkItems { get; set; }

        #endregion
    }
}
