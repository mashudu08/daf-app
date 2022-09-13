using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ST10115884_MashuduLuvhengo_POE_TASK1.Data;
using ST10115884_MashuduLuvhengo_POE_TASK1.Models;

namespace ST10115884_MashuduLuvhengo_POE_TASK1.Pages.Donations
{
    public class GoodsModel : PageModel
    {
        private readonly ST10115884_MashuduLuvhengo_POE_TASK1.Data.DataAccess _context;

        public GoodsModel(ST10115884_MashuduLuvhengo_POE_TASK1.Data.DataAccess context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Goods Goods { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            bool isSaved = false;
            DataManager dm = new DataManager();
            if (dm.openConnection())
            {
                isSaved = dm.donateGoods(Goods);
            }
            else
            {
                return Page();

            }

            if (isSaved)
            {
                return RedirectToPage("./Goods");
            }
            else
            {
                return Page();
            }
            //_context.Goods.Add(Goods);
            //await _context.SaveChangesAsync();

            //return RedirectToPage("./Index");
        }
    }
}
