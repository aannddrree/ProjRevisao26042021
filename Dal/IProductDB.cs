using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    interface IProductDB
    {
        bool Insert(Product product);
        bool Update(Product product);
        bool Delete(int id);
        Product SelectById(int id);
        List<Product> SelectAll();
    }
}
