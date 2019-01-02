namespace GraduwayTasks.Web.Models
{
    using System.ComponentModel.DataAnnotations;
    using Base;

    public class EmployeeModel: EntityModelBase
    {
        [Required, StringLength(128)]
        public string FirstName { get; set; }

        [Required, StringLength(128)]
        public string LastName { get; set; }

        [Required, StringLength(128)]
        public string Position { get; set; }
    }
}
