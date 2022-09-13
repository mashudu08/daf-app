using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ST10115884_MashuduLuvhengo_POE_TASK1.Data;
using ST10115884_MashuduLuvhengo_POE_TASK1.Models;

namespace ST10115884_MashuduLuvhengo_POE_TASK1.Pages.User
{
    public class LoginModel : PageModel
    {
        private readonly ST10115884_MashuduLuvhengo_POE_TASK1.Data.DataAccess _context;

        public LoginModel(ST10115884_MashuduLuvhengo_POE_TASK1.Data.DataAccess context)
        {
            _context = context;
        }
     
        public IActionResult OnGet()
        {
            if (HttpContext.Session.TryGetValue("isLoggedIn", out byte[] result))
            {
                ViewData["isLoggedIn"] = BitConverter.ToBoolean(result, 0);

                if (HttpContext.Session.TryGetValue("isAdmin", out byte[] res))
                {
                    ViewData["isAdmin"] = BitConverter.ToBoolean(res, 0);
                }

            }
            else
            {
                ViewData["isLoggedIn"] = false;
                ViewData["isValid"] = true;
                ViewData["isAdmin"] = false;
            }
            return Page();
        }

        [BindProperty]
        public Users Users { get; set; }
        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            //_context.Users.Add(Users);
            //await _context.SaveChangesAsync();
            List<Users> users = new DataManager().loginUser(Users);

            // This will be the condition once you've made the column for email unique in the DB
            // if (users.Count == 1)
            if (users.Count >= 1)
            {
                HttpContext.Session.Set("isLoggedIn", BitConverter.GetBytes(true));
                HttpContext.Session.Set("isAdmin", BitConverter.GetBytes(true));
                return RedirectToPage("../Index");
            }
            else
            {
                ViewData["isLoggedIn"] = false;
                ViewData["isValid"] = false;
                return Page();
            }
        }
    }
}
