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
    public class WorkItemController : BaseController
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

            return Ok(_mapper.Map<WorkItemModel[]>(await query.ToArrayAsync(cancellationToken)));
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
                .ToArrayAsync(cancellationToken)));
        }
    }
}
