using King_Price_Assessment.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace King_Price_Assessment.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private UserController _userController;

    public IndexModel(ILogger<IndexModel> logger, UserController userController)
    {
        _logger = logger;
        _userController = userController;
    }

    public void OnGet()
    {

    }
}
