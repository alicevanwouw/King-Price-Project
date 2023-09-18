using King_Price_Assessment.Data;
using King_Price_Assessment.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            return Json(GetGroups());
        }

        //Retrieve number of users in each group
        [HttpGet]
        public ActionResult GetUserCountForGroups()
        {

            Dictionary<string, int> usersCount = _context.Groups
                   .ToDictionary(x => x.Name, x => x.Users.Count);

            return Json(usersCount);
        }

        public List<Group> GetGroups()
        {
            return _context.Groups
                        .Include(x => x.Users)
                        .Include(x => x.Permissions)
                        .ToList();
        }

    }
}
