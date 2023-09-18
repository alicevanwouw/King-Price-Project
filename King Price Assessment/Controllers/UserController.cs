using King_Price_Assessment.Data;
using King_Price_Assessment.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections;
using System.Globalization;

namespace King_Price_Assessment.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    public class UserController : Controller
    {
        private UserManagementContext _context;
        private DatabaseInitializer _databaseInitializer;

        public UserController(UserManagementContext context, GroupController groupController, DatabaseInitializer databaseInitializer)
        {
            _context = context;
            _databaseInitializer = databaseInitializer;
            _databaseInitializer = databaseInitializer;

            //very hacky... add some data to the databse if there is none
            _context.Database.EnsureCreated();

            if (!context.Users.Any())
            {
                _databaseInitializer.Initialize();
            }


        }

        //Retrieve all users
        [HttpGet]
        public IActionResult Get()
        {
            return Json(_context.Users.Include(x => x.Groups).ToList());
        }

        //Retrieve user count
        [HttpGet]
        public ActionResult GetUserCount()
        {
            return Json(_context.Users.Count());
        }

        //Update a users details
        [HttpPut]
        public async Task<IActionResult> Put(string id, string values)
        {
            var user = await _context.Users
                .Include(u => u.Groups)
                .FirstOrDefaultAsync(u => u.Id.Equals(Guid.Parse(id)));

            if (user == null)
                     return StatusCode(409, "User not found");

            user.Groups.Clear();
            SetUserGroups(user, values);

            await _context.SaveChangesAsync();
            return Ok();

        }

        //Add a new user
        [HttpPost]
        public async Task<IActionResult> Post(string values)
        {
            var user = new User();
            user.Id = Guid.NewGuid();
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateUserModel(user, valuesDict);

            user.Groups = new List<Group>();
            SetUserGroups(user, values);

            var result = _context.Users.Add(user);
            var newId = result.Entity.Id;
            await _context.SaveChangesAsync();

            return Json(newId);
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
                .Where(x => x.Id.Equals(Guid.Parse(id)))
                .FirstOrDefault();
        }

        private void PopulateUserModel(User model, IDictionary values)
        {
            string ID = nameof(Models.User.Id);
            string FIRST_NAME = nameof(Models.User.FirstName);
            string SURNAME = nameof(Models.User.Surname);
            string EMAIL = nameof(Models.User.Email);
            string PHONE_NUMBER = nameof(Models.User.PhoneNumber);

            if (values.Contains(ID))
            {
                model.Id = Guid.Parse(values[ID].ToString());
            }

            if (values.Contains(FIRST_NAME))
            {
                model.FirstName = Convert.ToString(values[FIRST_NAME]);
            }

            if (values.Contains(SURNAME))
            {
                model.Surname = Convert.ToString(values[SURNAME]);
            }

            if (values.Contains(EMAIL))
            {
                model.Email = Convert.ToString(values[EMAIL]);
            }
            if (values.Contains(PHONE_NUMBER))
            {
                model.PhoneNumber = Convert.ToString(values[PHONE_NUMBER]);
            }

        }

        private void SetUserGroups(User user, string values)
        {
            var dictionary = JsonConvert.DeserializeObject<IDictionary>(values);
            var groupIds = Convert.ToString(dictionary[nameof(Models.User.Groups)]).Split(",");
            var availableGroups = _context.Groups.ToList();

            foreach (var gId in groupIds)
            {
                user.Groups.Add(availableGroups.First(g => g.Id.Equals(Guid.Parse(gId))));
            }
        }
    }
}
