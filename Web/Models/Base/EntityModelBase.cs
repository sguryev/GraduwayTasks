namespace GraduwayTasks.Web.Models.Base
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public abstract class EntityModelBase: ModelBase
    {
        [Required, StringLength(128)]
        public string Id { get; set; }

        public DateTimeOffset CreatedAt { get; set; }
    }
}
