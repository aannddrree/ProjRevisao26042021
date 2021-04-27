using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Product
    {

        public const string INSERT = "INSERT INTO TB_PRODUCT (name) values ('{0}')";
        public const string UPDATE = "UPDATE TB_PRODUCT SET name = '{0}' WHERE id = {1}";
        public const string DELETE = "DELETE FROM TB_PRODUCT WHERE id = {0}";
        public const string SELECTALL = "SELECT id, name FROM TB_PRODUCT";
        public const string SELECTBYID = "SELECT id, name FROM TB_PRODUCT WHERE id = {0}";
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
