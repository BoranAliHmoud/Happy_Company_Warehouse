using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Happy_Company_Warehouse.DataAccess.Data;
using Happy_Company_Warehouse.DataAccess.IRepository;
using Happy_Company_Warehouse.Model;

namespace Happy_Company_Warehouse.Repository
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public  IGenericRepository<Warehouse> Warehouses { get; private set; }
        public  IGenericRepository<Item> Items { get; private set; }
         public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;

            Warehouses =new  GenericRepository<Warehouse>(_context);
            Items = new  GenericRepository<Item>(_context);
         }

        public async Task<int> Complete()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
