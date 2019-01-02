namespace GraduwayTasks.Data.Model
{
    using System.ComponentModel.DataAnnotations;
    using Base;
    using Enums;

    public class WorkItem: EntityBase
    {
        [Required, StringLength(128)]
        public string Title { get; set; }

        [StringLength(512)]
        public string Description { get; set; }

        [Range((byte)Priority.Critical, (byte)Priority.Medium)]
        public Priority Priority { get; set; }

        [Range((byte)State.New, (byte)State.Closed)]
        public State State { get; set; }

        #region Navigations

        [StringLength(128)]
        public string EmployeeId { get; set; }
        public Employee Employee { get; set; }

        #endregion
    }
}
