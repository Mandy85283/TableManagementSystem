using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TableManagementLibrary.Data;
using TableManagementLibrary.Interface;
using TableManagementLibrary.Models;

namespace TableManagementSystem.Pages.Admin.Tables
{
    [Authorize]
    public class DeleteModel : PageModel
    {
        private readonly ITables _tables;

        public DeleteModel(ITables tables)
        {
            _tables = tables;
        }

        [BindProperty]
        public tables tables { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            tables = await _tables.GetTableById(id);

            if (tables == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            tables = await _tables.GetTableById(id);

            if (tables != null)
            {

                await _tables.DeleteAsysn(tables);
            }

            return RedirectToPage("./Index");
        }
    }
}
