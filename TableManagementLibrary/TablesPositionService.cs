using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TableManagementLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using TableManagementLibrary.Interface;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace TableManagementLibrary
{
    public class TablesPositionService: ITablePosition
    {
        private readonly TableManagementLibrary.Data.ApplicationDbContext _context;

        public TablesPositionService(TableManagementLibrary.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Get table position list
        /// </summary>
        /// <returns></returns>
        public async Task<IList<tablePosition>> GetTablePositionList()
        {

           var tables = await _context.tablePosition.ToListAsync();

            return tables;
        }

        /// <summary>
        /// Get drop down list
        /// </summary>
        /// <returns></returns>

        public SelectList GetTablePositionDDL()
        {

            var list = new SelectList(_context.tablePosition, "TablePositionId", "Position");

            return list;
        }

        /// <summary>
        /// get record by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<tablePosition> GetTablePositionById(int? id)
        {
            return await _context.tablePosition.FirstOrDefaultAsync(m => m.TablePositionId == id);
   
        }

        /// <summary>
        /// get record by name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<tablePosition> GetTablePositionByName(string name)
        {
            return await _context.tablePosition.FirstOrDefaultAsync(
                m => m.Position.Trim().ToLower() == name.Trim().ToLower());

        }

        /// <summary>
        /// create record
        /// </summary>
        /// <param name="tables"></param>
        /// <returns></returns>
        public async Task<bool> CreateAsync(tablePosition tables)
        {
            _context.tablePosition.Add(tables);
            await _context.SaveChangesAsync();
            return true;
        }

        /// <summary>
        /// update record
        /// </summary>
        /// <param name="tables"></param>
        /// <returns></returns>
        public async Task<bool> UpdateAsync(tablePosition tables)
        {
            _context.Attach(tables).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }

        /// <summary>
        /// delete record
        /// </summary>
        /// <param name="tables"></param>
        /// <returns></returns>
        public async Task<bool> DeleteAsysn(tablePosition tables)
        {
            _context.tablePosition.Remove(tables);
            await _context.SaveChangesAsync();
            return true;
        }

        /// <summary>
        /// record exists
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool tablePositisonExists(int id)
        {
            return _context.tablePosition.Any(e => e.TablePositionId == id);
        }

    }
}
