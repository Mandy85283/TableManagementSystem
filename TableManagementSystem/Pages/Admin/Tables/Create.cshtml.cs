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

namespace TableManagementSystem.Pages.Admin.Tables
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly ITables _tables;

        public CreateModel(ITables tables)
        {
            _tables = tables;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public tables tables { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            tables result = await _tables.GetTableByTableName(tables.TableName);
            if (result!=null)
            {
                ModelState.AddModelError(string.Empty, "Table already exists");
                return Page();
            }
            await _tables.CreateAsync(tables);

            return RedirectToPage("./Index");
        }
    }
}
