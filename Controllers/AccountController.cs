using Microsoft.AspNetCore.Mvc;
using ChatboxApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace ChatboxApp.Controllers
{
    public class AccountController : Controller
    {
        private static readonly List<User> Users = new List<User>
        {
            new User { Id = 1, Username = "User1", Email = "user1@example.com", Password = "Pass@1234" },
            new User { Id = 2, Username = "User2", Email = "user2@example.com", Password = "Test@5678" },
            new User { Id = 3, Username = "User3", Email = "user3@example.com", Password = "Qwerty@2023" },
            new User { Id = 4, Username = "User4", Email = "user4@example.com", Password = "Secure#4567" },
            new User { Id = 5, Username = "User5", Email = "user5@example.com", Password = "Alpha!7890" },
            new User { Id = 6, Username = "User6", Email = "user6@example.com", Password = "Bravo@3210" },
            new User { Id = 7, Username = "User7", Email = "user7@example.com", Password = "Charlie#123" },
            new User { Id = 8, Username = "User8", Email = "user8@example.com", Password = "Delta@456" },
            new User { Id = 9, Username = "User9", Email = "user9@example.com", Password = "Echo#789" },
            new User { Id = 10, Username = "User10", Email = "user10@example.com", Password = "Foxtrot!000" }
        };

        // Helper method to validate the user
        private bool IsValidUser(string email, string password)
        {
            return Users.Any(u => u.Email.Equals(email, System.StringComparison.OrdinalIgnoreCase) && u.Password == password);
        }

        // GET: Login
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        // POST: Login
        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // Check if the user is valid using the IsValidUser method
            if (IsValidUser(model.Email, model.Password))
            {
                return RedirectToAction("Landing", "Home"); // Redirect to Landing page if valid
            }

            // If credentials are invalid
            ModelState.AddModelError(string.Empty, "Invalid email or password");
            return View(model);
        }

        // GET: Register
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        // POST: Register
        [HttpPost]
        public IActionResult Register(User model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            TempData["Success"] = "Registration successful!";
            return RedirectToAction("Login");
        }
    }
}
