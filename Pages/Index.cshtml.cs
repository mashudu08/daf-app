﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using ST10115884_MashuduLuvhengo_POE_TASK1.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ST10115884_MashuduLuvhengo_POE_TASK1.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;

        }

        public void OnGet()
        {

            if (HttpContext.Session.TryGetValue("isLoggedIn", out byte[] result))
            {
                ViewData["isLoggedIn"] = BitConverter.ToBoolean(result, 0);

                if(HttpContext.Session.TryGetValue("isAdmin", out byte[] res))
                {
                    ViewData["isAdmin"] = BitConverter.ToBoolean(res, 0);
                }
                
            }
            else
            {
                ViewData["isLoggedIn"] = false;
                ViewData["isAdmin"] = false;
            }
        }
    }
}
