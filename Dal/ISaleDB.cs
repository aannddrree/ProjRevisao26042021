using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    interface ISaleDB
    {
        bool Insert(Sale sale);
        bool Update(Sale sale);
        bool Delete(int id);
        Sale SelectById(int id);
        List<Sale> SelectAll();
    }
}
