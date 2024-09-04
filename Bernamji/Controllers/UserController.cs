using bernamji.Core.Entities;
using Bernamji.Application.Resources;
using Bernamji.Application.Services.Core;
using Microsoft.AspNetCore.Mvc;

namespace Bernamji.Controllers;
public class UserController : Controller
{
    public IActionResult Login()
    {
        return View();
    }

   
}
