
using Happy_Company_Warehouse.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Happy_Company_Warehouse.DataAccess.IRepository
{
    public interface IUnitOfWork: IDisposable
    {
      IGenericRepository<Warehouse> Warehouses { get; }
      IGenericRepository<Item> Items { get; }
 
       
        Task<int>  Complete();
    }
}
