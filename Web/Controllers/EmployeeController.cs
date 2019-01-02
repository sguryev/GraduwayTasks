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
    public class EmployeeController : BaseController
    {
        private readonly IMapper _mapper;

        public EmployeeController(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext)
        {
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string id, CancellationToken cancellationToken)
        {
            var query = DbContext.Employees.AsQueryable();

            if (!string.IsNullOrEmpty(id))
            {
                var entity = await query.SingleOrDefaultAsync(e => e.Id == id, cancellationToken);
                return entity == null 
                    ? (IActionResult) NotFound() 
                    : Ok(_mapper.Map<EmployeeModel>(entity));
            }

            return Ok(_mapper.Map<EmployeeModel[]>(
                await query
                    .OrderBy(e => e.FirstName)
                    .ThenBy(e => e.LastName)
                    .ToArrayAsync(cancellationToken)));
        }
    }
}
