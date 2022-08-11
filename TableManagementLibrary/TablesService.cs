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
    public class TablesService: ITables
    {
        private readonly TableManagementLibrary.Data.ApplicationDbContext _context;

        public TablesService(TableManagementLibrary.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// get table list
        /// </summary>
        /// <returns></returns>
        public async Task<IList<tables>> GetTableList()
        {

           var tables = await _context.Tables.ToListAsync();

            return tables;
        }

        /// <summary>
        /// Get drop down list
        /// </summary>
        /// <returns></returns>
        public SelectList GetTableDDL()
        {

            var list = new SelectList(_context.Tables, "TableId", "Table");

            return list;
        }

        /// <summary>
        /// get record by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<tables> GetTableById(int? id)
        {
            return await _context.Tables.FirstOrDefaultAsync(m => m.TableId == id);
   
        }

        

        /// <summary>
        /// get record by table name
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public async Task<tables> GetTableByTableName(string tableName)
        {
            return await _context.Tables.FirstOrDefaultAsync(
                m => m.TableName.Trim().ToLower() == tableName.Trim().ToLower());

        }

        /// <summary>
        /// create record
        /// </summary>
        /// <param name="tables"></param>
        /// <returns></returns>
        public async Task<bool> CreateAsync(tables tables)
        {
            _context.Tables.Add(tables);
            await _context.SaveChangesAsync();
            return true;
        }

        /// <summary>
        /// update record
        /// </summary>
        /// <param name="tables"></param>
        /// <returns></returns>
        public async Task<bool> UpdateAsync(tables tables)
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
        public async Task<bool> DeleteAsysn(tables tables)
        {
            _context.Tables.Remove(tables);
            await _context.SaveChangesAsync();
            return true;
        }

        /// <summary>
        /// record exists
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool tableExists(int id)
        {
            return _context.Tables.Any(e => e.TableId == id);
        }

    }
}
