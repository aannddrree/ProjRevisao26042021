using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Sale
    {

        public const string INSERT = "INSERT INTO TB_SALE (description, idClient, idProduct) values ('{0}', {1}, {2})";
        public const string UPDATE = "UPDATE TB_SALE SET description = '{0}', idClient = {1}, idProduct = {2} WHERE id = {3}";
        public const string DELETE = "DELETE FROM TB_SALE WHERE id = {0}";

        public const string SELECTALL = "SELECT S.id, S.idClient, C.name nameClient, S.idProduct, P.name nameProduct, description FROM TB_SALE S, TB_CLIENT C, TB_PRODUCT P WHERE S.idClient = C.id AND P.id = S.idProduct";
        public const string SELECTBYID = "SELECT S.id, S.idClient, C.name nameClient, S.idProduct, P.name nameProduct, description FROM TB_SALE S, TB_CLIENT C, TB_PRODUCT P WHERE S.idClient = C.id AND P.id = S.idProduct AND S.id = {0}";


        public int Id { get; set; }

        public Client Client { get; set; }

        public Product Product { get; set; }

        public string Description { get; set; }
    }
}
