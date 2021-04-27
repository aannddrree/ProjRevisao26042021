using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    interface IClientDB
    {
        bool Insert(Client client);
        bool Update(Client client);
        bool Delete(int id);
        Client SelectById(int id);
        List<Client> SelectAll();
    }
}
