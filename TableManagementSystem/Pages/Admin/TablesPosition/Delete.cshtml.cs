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

namespace TableManagementSystem.Pages.Admin.TablesPosition
{
    [Authorize]
    public class DeleteModel : PageModel
    {
        private readonly ITablePosition _tables;

        public DeleteModel(ITablePosition tables)
        {
            _tables = tables;
        }

        [BindProperty]
        public tablePosition tablePosition { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            tablePosition = await _tables.GetTablePositionById(id);

            if (tablePosition == null)
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

            tablePosition = await _tables.GetTablePositionById(id);

            if (tablePosition != null)
            {

                await _tables.DeleteAsysn(tablePosition);
            }

            return RedirectToPage("./Index");
        }
    }
}
