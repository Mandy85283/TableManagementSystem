using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TableManagementLibrary.Data;
using TableManagementLibrary.Interface;
using TableManagementLibrary.Models;

namespace TableManagementSystem.Pages.Admin.TablesPosition
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly ITablePosition _tables;

        public CreateModel(ITablePosition tables)
        {
            _tables = tables;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public tablePosition tablePosition { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            tablePosition result = await _tables.GetTablePositionByName(tablePosition.Position);
            if (result != null)
            {
                ModelState.AddModelError(string.Empty, "Table position already exists");
                return Page();
            }

            await _tables.CreateAsync(tablePosition);

            return RedirectToPage("./Index");
        }
    }
}
