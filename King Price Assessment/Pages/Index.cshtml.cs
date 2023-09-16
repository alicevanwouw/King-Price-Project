using King_Price_Assessment.Controllers;
using King_Price_Assessment.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace King_Price_Assessment.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private UserController _userController;
    private GroupController _groupController;

    public List<User> Users = new List<User>();
    public List<UserGroup> Groups = new List<UserGroup>();
    public int UserCount = 0;

    public IndexModel(ILogger<IndexModel> logger, UserController userController, GroupController groupController)
    {
        _logger = logger;
        _userController = userController;
        _groupController = groupController;
    }

    public async Task<IActionResult> OnGet()
    {
        var actionResult = _userController.Get();
        var actionResultGroup = _groupController.Get();
        var actionResultUserCount = _userController.GetUserCount();

        if (actionResult is JsonResult && actionResultGroup is JsonResult)
        {
            Users = (List<Models.User>)((JsonResult)actionResult).Value;
            UserCount = (int)((JsonResult)actionResultUserCount).Value;

            //Groups = (List<UserGroup>)((JsonResult)actionResultGroup).Value;

            return Page();
        }
        else
        {
            return actionResult;
        }
    }

    //public void OnGet()
    //{

    //}
}
