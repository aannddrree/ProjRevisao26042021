using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Client
    {
        public const string INSERT = "INSERT INTO TB_CLIENT (name, telephone) values ('{0}','{1}')";
        public const string UPDATE = "UPDATE TB_CLIENT SET name = '{0}', telephone = '{1}' WHERE id = {2}";
        public const string DELETE = "DELETE FROM TB_CLIENT WHERE id = {0}";
        public const string SELECTALL = "SELECT id, name, telephone FROM TB_CLIENT";
        public const string SELECTBYID = "SELECT id, name, telephone FROM TB_CLIENT WHERE id = {0}";

        public int Id { get; set; }

        public string Name { get; set; }

        public string Telephone { get; set; }
    }
}
