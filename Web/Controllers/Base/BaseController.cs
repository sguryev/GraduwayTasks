namespace GraduwayTasks.Web.Controllers.Base
{
    using Data;
    using Microsoft.AspNetCore.Mvc;

    public abstract class BaseController: Controller
    {
        protected BaseController(ApplicationDbContext dbContext)
        {
            DbContext = dbContext;
        }

        protected ApplicationDbContext DbContext { get; }
    }
}