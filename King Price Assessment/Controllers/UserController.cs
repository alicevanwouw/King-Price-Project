using King_Price_Assessment.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Collections;
using System.Globalization;

namespace King_Price_Assessment.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
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
            return Json(_context.Users.ToList());
        }

        //Retrieve user count
        [HttpGet]
        public ActionResult GetUserCount()
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
            var model = await _context.Users.FirstOrDefaultAsync(item => item.Id.Equals(Guid.Parse(id)));
            if (model == null)
                return StatusCode(409, "User not found");

            var _values = JsonConvert.DeserializeObject<IDictionary>(values);

            PopulateUserModel(model, _values);

            if (!TryValidateModel(model))
                return BadRequest(GetFullErrorMessage(ModelState));

            await _context.SaveChangesAsync();
            return Ok();
        }

        //Add a new user
        [HttpPost]
        public async Task<IActionResult> Post(string values)
        {
            var model = new User();
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateUserModel(model, valuesDict);

            if (!TryValidateModel(model))
                return BadRequest(GetFullErrorMessage(ModelState));

            var result = _context.Users.Add(model);
            await _context.SaveChangesAsync();

            return Json(result.Entity);
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
            string GROUPS = nameof(Models.User.Groups);

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

            //TO-DO deal with this
            //if (values.Contains(GROUPS))
            //{
            //    model.Groups = Convert.ToString(values[GROUPS]);
            //}

        }

        private string GetFullErrorMessage(ModelStateDictionary modelState)
        {
            var messages = new List<string>();

            foreach (var entry in modelState)
            {
                foreach (var error in entry.Value.Errors)
                    messages.Add(error.ErrorMessage);
            }

            return String.Join(" ", messages);
        }
    }
}
