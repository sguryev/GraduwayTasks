namespace GraduwayTasks.Data.Model.Base
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public abstract class EntityBase
    {
        protected EntityBase()
        {
            Id = Guid.NewGuid().ToString();
            CreatedAt = DateTimeOffset.UtcNow;

            //todo: add soft deleting
        }

        [Key, Required, StringLength(128)]
        public string Id { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        [Timestamp]
        public byte[] Version { get; set; }
    }
}
