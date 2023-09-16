using King_Price_Assessment.Models;
using Microsoft.AspNetCore.Mvc;

namespace King_Price_Assessment.Controllers
{
    public class GroupController : Controller
    {
        private UserManagementContext _context;

        public GroupController(UserManagementContext context)
        {
            _context = context;
        }

        //Get all Groups
        [HttpGet]
        public IActionResult Get()
        {
            return Json(_context.Groups
                .Select(x => x.Name)
                .Distinct().ToList());
        }
    }
}
