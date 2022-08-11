using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TableManagementLibrary.Models;

namespace TableManagementLibrary.Interface
{
   public interface ITablePosition
    {
        /// <summary>
        /// get table position list
        /// </summary>
        /// <returns></returns>
         Task<IList<tablePosition>> GetTablePositionList();

        /// <summary>
        /// Get drop down list
        /// </summary>
        /// <returns></returns>
        SelectList GetTablePositionDDL();

        /// <summary>
        /// get record by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
         Task<tablePosition> GetTablePositionById(int? id);

        /// <summary>
        /// get record by name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        Task<tablePosition> GetTablePositionByName(string name);

        /// <summary>
        /// create record
        /// </summary>
        /// <param name="tables"></param>
        /// <returns></returns>
        Task<bool> CreateAsync(tablePosition tables);

        /// <summary>
        /// update record
        /// </summary>
        /// <param name="tables"></param>
        /// <returns></returns>
        Task<bool> UpdateAsync(tablePosition tables);

        /// <summary>
        /// delete record
        /// </summary>
        /// <param name="tables"></param>
        /// <returns></returns>
        Task<bool> DeleteAsysn(tablePosition tables);

        /// <summary>
        /// record exists
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool tablePositisonExists(int id);



    }
}
