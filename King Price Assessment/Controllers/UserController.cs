using King_Price_Assessment.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Globalization;

namespace King_Price_Assessment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private UserManagementContext _context;

        public UserController(UserManagementContext context)
        {
            _context = context;
        }

        //Retrieve all users
        [HttpGet]
        public IActionResult Get()
        {
            return Json(_context.Users.Select(x => x).ToList());
        }

        //Retrieve user count
        [HttpGet]
        public async Task<IActionResult> GetUserCount()
        {
            return Json(_context.Users.Count());
        }

        //Retrieve number of users in each group
        [HttpGet]
        public async Task<IActionResult> GetUserCountForGroups()
        {
            var users = _context.Users.Select(x => x).ToList();

            return Json(users);
        }

        //Update a users details
        [HttpPut]
        public async Task<IActionResult> Put(string id, string values)
        {
            var user = GetUser(id);

            if(user == null)
                return StatusCode(409, "User not found");

            return Ok();
        }

        //Add a new user
        [HttpPost]
        public async Task<IActionResult> Post(string values)
        {
            return Ok();
        }

        //Delete a user
        [HttpDelete]
        public async Task<IActionResult> Delete(string id)
        {
            var user = GetUser(id);

            if (user == null)
                return StatusCode(409, "User not found");

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return Ok();
        }

        //Find a user with the specified id
        private User GetUser(string id)
        {
            return _context.Users
                .Select(x => x)
                .Where(x => x.Id.Equals(id))
                .FirstOrDefault();
        }

        private void PopulateUserModel(User model, IDictionary values)
        {
            string ID = nameof(Models.User.Id);
            string FIRST_NAME = nameof(Models.User.FirstName);
            string SURNAME = nameof(Models.User.Surname);
            string IMAGE = nameof(Models.User.Image);
            string GROUPS = nameof(Models.User.Groups);

            if (values.Contains(ID))
            {
                model.Id = Convert.ToString(values[ID]);
            }

            if (values.Contains(FIRST_NAME))
            {
                model.FirstName = Convert.ToString(values[FIRST_NAME]);
            }

            if (values.Contains(SURNAME))
            {
                model.Surname = Convert.ToString(values[SURNAME]);
            }

            if (values.Contains(IMAGE))
            {
                model.Image = Convert.ToString(values[IMAGE]);
            }

            //TO-DO deal with this
            //if (values.Contains(GROUPS))
            //{
            //    model.Groups = Convert.ToString(values[GROUPS]);
            //}

        }
    }
}
