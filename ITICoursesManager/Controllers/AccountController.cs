using System.Security.Claims;
using System.Threading.Tasks;
using ITICoursesManager.Models;
using ITICoursesManager.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ITICoursesManager.Controllers;

public class AccountController : Controller
{
    private readonly UserManager<AppUser> _userManager;
    private readonly SignInManager<AppUser> _signInManager;

    public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }
    [HttpGet]
    public IActionResult Register(RegisterVM userVM)
    {
        return View("Register", userVM);
    }

    public async Task<IActionResult> SaveRegister(RegisterVM userVM)
    {
        if(ModelState.IsValid)
        {
            AppUser user = new AppUser();
            user.UserName = userVM.UserName;
            //user.PasswordHash = userVM.Password;
            user.Address = userVM.Address;

            IdentityResult result = await _userManager.CreateAsync(user,userVM.Password);

            if(result.Succeeded)
            {
                await _signInManager.SignInAsync(user, isPersistent: false);

                return RedirectToAction("ShowAll", controllerName: "Instructor");
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                goto returnToRegister;
            }

        }
    returnToRegister:
        return View("Register", userVM);
    }

    public IActionResult Login()
    {
        return View("Login");
    }

    [HttpPost]
    public async Task<IActionResult> SaveLogin(LoginVM userVM)
    {
        if (ModelState.IsValid)
        {
            AppUser? user = await _userManager.FindByNameAsync(userVM.Username);
            if (user is not null)
            {
                if(await _userManager.CheckPasswordAsync(user,userVM.Password))
                {
                    List<Claim> claims = new List<Claim>();
                    claims.Add(new Claim("Address", user.Address));

                    await _signInManager.SignInWithClaimsAsync(user,userVM.RememberMe, claims);
                    return RedirectToAction("ShowAll", "Instructor");
                }
            }

            ModelState.AddModelError("", "Username or Password is wrong");
        }
        return View("Login", userVM);
    }

    public async Task<IActionResult> SignOutAsync()
    {
        await _signInManager.SignOutAsync();
        return View("Login");

    }
}
