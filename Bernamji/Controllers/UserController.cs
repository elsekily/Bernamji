using Microsoft.AspNetCore.Mvc;

namespace Bernamji.Controllers;
public class UserController : Controller
{
    public IActionResult Login()
    {
        return View();
    }

   
}
