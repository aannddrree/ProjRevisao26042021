using Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class ClientDB : IClientDB
    {

        public bool Insert(Client client)
        {
            bool status = false;

            string sql = string.Format(Client.INSERT, client.Name, client.Telephone);

            using (var connection = new DB())
            {
                status = connection.ExecQuery(sql);
            }
            return status;
        }

        public bool Update(Client client)
        {
            bool status = false;

            string sql = string.Format(Client.UPDATE, client.Name, client.Telephone, client.Id);

            using (var connection = new DB())
            {
                status = connection.ExecQuery(sql);
            }
            return status;
        }

        public bool Delete(int id)
        {
            bool status = false;

            string sql = string.Format(Client.DELETE, id);

            using (var connection = new DB())
            {
                status = connection.ExecQuery(sql);
            }
            return status;
        }

        public List<Client> SelectAll()
        {
            string sql = Client.SELECTALL;
            List<Client> clients;

            using(var connection = new DB())
            {
                clients = TransformSQLDataReaderToList(connection.ExecQueryReturn(sql));
            }
            return clients;
        }

        public Client SelectById(int id)
        {
            string sql = string.Format(Client.SELECTBYID, id);
            Client client;

            using (var connection = new DB())
            {
                client = TransformSQLDataReaderToList(connection.ExecQueryReturn(sql))[0];
            }
            return client;
        }

        private List<Client> TransformSQLDataReaderToList(SqlDataReader returnData)
        {
            var clients = new List<Client>();

            while (returnData.Read())
            {
                var item = new Client()
                {
                    Id = int.Parse(returnData["id"].ToString()),
                    Name = returnData["name"].ToString(),
                    Telephone = returnData["telephone"].ToString()
                };

                clients.Add(item);
            }
            return clients;
        }
    }
}
