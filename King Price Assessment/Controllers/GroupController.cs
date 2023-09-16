using King_Price_Assessment.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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
            List<Group> groups = _context.Groups
                                      .GroupBy(x => x.Name)
                                      .Select(x=> x.FirstOrDefault()).ToList();
            return Json(groups);
        }
    }
}
