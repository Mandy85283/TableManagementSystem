using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TableManagementLibrary.Models;

namespace TableManagementLibrary.Interface
{
   public interface IFlowers
    {
        /// <summary>
        /// get flower list
        /// </summary>
        /// <returns></returns>
         Task<IList<flowers>> GetFlowersList();

        /// <summary>
        /// Get drop down list
        /// </summary>
        /// <returns></returns>
        SelectList GetFlowersDDL();

        /// <summary>
        /// get record by name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        Task<flowers> GetFlowerByName(string name);

        /// <summary>
        /// get record by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
         Task<flowers> GetFlowerById(int id);

        /// <summary>
        /// create record
        /// </summary>
        /// <param name="flowers"></param>
        /// <returns></returns>
        Task<bool> CreateAsync(flowers flowers);

        /// <summary>
        /// update record
        /// </summary>
        /// <param name="flowers"></param>
        /// <returns></returns>
        Task<bool> UpdateAsync(flowers flowers);

        /// <summary>
        /// delete record
        /// </summary>
        /// <param name="flowers"></param>
        /// <returns></returns>
        Task<bool> DeleteAsysn(flowers flowers);

        /// <summary>
        /// record exists
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool flowersExists(int id);



    }
}
