using CleanArchitecture.DataAccess.Contexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserRatingsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UserRatingsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await _context.ApplicationUsers.Take(10).ToListAsync();
            return Ok(data);
        }
    }

}
