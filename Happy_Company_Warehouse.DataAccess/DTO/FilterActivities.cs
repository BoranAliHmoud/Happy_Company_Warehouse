using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Happy_Company_Warehouse.DataAccess.DTO
{
    public class FilterActivities
    {

        public int pageIndex { get; set; } = 0;
        public int pageSize { get; set; } = 10;
        public string? Name { get; set; }
    }
}
