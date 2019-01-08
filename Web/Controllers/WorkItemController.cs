using GraduwayTasks.Data.Model;

namespace GraduwayTasks.Web.Controllers
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using AutoMapper;
    using Base;
    using Data;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Models;

    [Route("api/[controller]")]
    public class WorkItemController : BaseApiController
    {
        private readonly IMapper _mapper;

        public WorkItemController(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext)
        {
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string id, CancellationToken cancellationToken)
        {
            var query = DbContext.WorkItems.AsQueryable();

            if (!string.IsNullOrEmpty(id))
            {
                var entity = await query.SingleOrDefaultAsync(e => e.Id == id, cancellationToken);
                return entity == null 
                    ? (IActionResult) NotFound() 
                    : Ok(_mapper.Map<WorkItemModel>(entity));
            }

            return Ok(_mapper.Map<WorkItemModel[]>(
                await query
                    .OrderBy(wi => wi.Priority)
                    .ThenBy(wi => wi.State)
                    .ThenBy(wi => wi.Title)
                    .ToArrayAsync(cancellationToken)));
        }

        [HttpGet("employee/{employeeId}")]
        public async Task<IActionResult> GetByEmployeeId(string employeeId, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(employeeId))
            {
                return BadRequest();
            }

            return Ok(_mapper.Map<WorkItemModel[]>(await DbContext.WorkItems
                .Where(wi => wi.EmployeeId == employeeId)
                .OrderBy(wi => wi.Priority)
                .ThenBy(wi => wi.State)
                .ThenBy(wi => wi.Title)
                .ToArrayAsync(cancellationToken)));
        }

        [HttpPost]
        public async Task<IActionResult> Post(WorkItemPostModel model, CancellationToken cancellationToken)
        {
            if (model == null)
            {
                return BadRequest($"{nameof(model)} is null");
            }

            //[ApiController] makes the validation https://docs.microsoft.com/en-us/aspnet/core/web-api/?view=aspnetcore-2.2#automatic-http-400-responses

            var entity = _mapper.Map<WorkItem>(model);

            DbContext.WorkItems.Add(entity);

            await DbContext.SaveChangesAsync(cancellationToken);

            return CreatedAtAction(nameof(Get), Mapper.Map<WorkItemModel>(entity));
        }
    }
}
