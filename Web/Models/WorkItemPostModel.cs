namespace GraduwayTasks.Web.Models
{
    using System.ComponentModel.DataAnnotations;
    using Base;
    using Data.Model.Enums;

    public class WorkItemPostModel: ModelBase
    {
        [Required, StringLength(128)]
        public string Title { get; set; }

        [StringLength(512)]
        public string Description { get; set; }

        [Range((byte)Priority.Critical, (byte)Priority.Medium)]
        public Priority Priority { get; set; }

        [Range((byte)State.New, (byte)State.Closed)]
        public State State { get; set; }

        [StringLength(128)]
        public string EmployeeId { get; set; }
    }
}
