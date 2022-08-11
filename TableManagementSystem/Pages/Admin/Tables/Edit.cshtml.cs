using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TableManagementLibrary.Data;
using TableManagementLibrary.Interface;
using TableManagementLibrary.Models;

namespace TableManagementSystem.Pages.Admin.Tables
{
    [Authorize]
    public class EditModel : PageModel
    {
        private readonly ITables _tables;

        public EditModel(ITables tables)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            tables result = await _tables.GetTableByTableName(tables.TableName);
            if (result == null)
            {
                ModelState.AddModelError(string.Empty, "Table already exists");
                return Page();
            }

            try
            {
                await _tables.UpdateAsync(tables);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_tables.tableExists(tables.TableId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }


    }
}
