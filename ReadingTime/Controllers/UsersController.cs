using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ReadingTime.Data;
using ReadingTime.Models;
//using ReadingTimee.Tweeter;

namespace ReadingTime.Controllers
{
    
    public class UsersController : Controller
    {
        private readonly ReadingTimeContext _context;

        public UsersController(ReadingTimeContext context)
        {
            _context = context;
        }

        //============================================================================//



        //============================================================================//


        //============================================================================//
        // GET: Users/Register
        public IActionResult Register()
        {
            return View();
        }

        // POST: Users/Register
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register([Bind("Id,UserName,Password")] User user)
        {
            if (ModelState.IsValid)
            {
                //Check if user exists
                var q = _context.User.FirstOrDefault(u => u.UserName == user.UserName);

                if (q == null)
                {
                    _context.Add(user);
                    await _context.SaveChangesAsync();

                    var u = _context.User.FirstOrDefault(u => u.UserName == user.UserName && u.Password == user.Password);

                    Signin(u);

                    return RedirectToAction(nameof(Index), "Home");
                }
                else
                {
                    ViewData["Error"] = "Choose difrent UserName.";
                }
            }
            return View(user);


            




        }
        //============================================================================//

        //============================================================================//
        // GET: Users/Login
        public IActionResult Login()
        {
            return View();
        }

        // POST: Users/Login
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login([Bind("Id,UserName,Password")] User user)
        {
            if (ModelState.IsValid)
            {
                //Check if user exists
                var q = _context.User.FirstOrDefault(u => u.UserName == user.UserName && u.Password == user.Password);

                if (q != null)
                {

                    //HttpContext.Session.SetString("username", q.UserName);
                    Signin(q);
                    return RedirectToAction(nameof(Index), "Home");
                  
                }
                ViewData["Error"] = "Username and/or password are incorrect.";
               
            }
            return View(user);
        }

        //============================================================================//

        private async void Signin(User account)
        {
            var claims = new List<Claim> 
            {
                new Claim(ClaimTypes.Name, account.UserName), 
                new Claim(ClaimTypes.Role, account.Type.ToString()), 
            }; 
            var claimsIdentity = new ClaimsIdentity(
                claims, CookieAuthenticationDefaults.AuthenticationScheme);
            
            var authProperties = new AuthenticationProperties
            {
                //ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(10)
            };
            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                authProperties);
        }

        public static string APIkey = "gYaJskaR04CU1P8xcDn8KDqVM";

        public static string APIsecretKey = "qbdQdWUkL7HXntM3lVyQZokaMAiVsA3jYW5z3Hu1WwelJUNw57";

        public static string BearerToken = "AAAAAAAAAAAAAAAAAAAAAMPAVgEAAAAAS2PR%2BuICfWx5hVdH%2BKfg2Sfkzns%3DdycvgMD0joY5zYirObY2rPmk78UKojjXKX5CLzF65cP7LAY4Mo";

        public static string AccessToken = "1434235654045507586-jIdRD3Pi0jOsDhmOBhj4yYICiBpr4p";

        public static string AccessTokenSecret = "XujmwDOk9MCGkVdyO4gdku5Sf6t3V9W52N5H4UGGAc3Hz";


       // Tweetinvi.Auth.SetUserCredentials(APIkey, APIsecretKey, AccessToken, AccessTokenSecret);

        //============================================================================//

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }

        //============================================================================//


        /*

        // GET: Users
        public async Task<IActionResult> Index()
        {
            return View(await _context.User.ToListAsync());
        }

        // GET: Users/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.User
                .FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }


        // GET: Users/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.User.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserName,Password,BookId,Type")] User user)
        {
            if (id != user.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(user);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.User
                .FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var user = await _context.User.FindAsync(id);
            _context.User.Remove(user);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserExists(int id)
        {
            return _context.User.Any(e => e.Id == id);
        }
        */
    }
}
