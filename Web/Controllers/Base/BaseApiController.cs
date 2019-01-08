namespace GraduwayTasks.Web.Controllers.Base
{
    using Data;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    public abstract class BaseApiController: Controller
    {
        protected BaseApiController(ApplicationDbContext dbContext)
        {
            DbContext = dbContext;
        }

        protected ApplicationDbContext DbContext { get; }
    }
}