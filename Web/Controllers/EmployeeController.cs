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
    using Services.Employee;

    [Route("api/[controller]")]
    public class EmployeeController : BaseApiController
    {
        private readonly IMapper _mapper;
        private readonly IEmployeeService _employeeService;

        public EmployeeController(
            ApplicationDbContext dbContext, 
            IMapper mapper,
            IEmployeeService employeeService) : base(dbContext)
        {
            _mapper = mapper;
            _employeeService = employeeService;
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

        [HttpPost]
        public async Task<IActionResult> Post(EmployeePostModel model, CancellationToken cancellationToken)
        {
            if (model == null)
            {
                return BadRequest($"{nameof(model)} is null");
            }

            //[ApiController] makes the validation https://docs.microsoft.com/en-us/aspnet/core/web-api/?view=aspnetcore-2.2#automatic-http-400-responses

            var entity = _employeeService.CreateEmployee(model, DbContext);

            await DbContext.SaveChangesAsync(cancellationToken);

            return CreatedAtAction(nameof(Get), _mapper.Map<EmployeeModel>(entity));
        }
    }
}
