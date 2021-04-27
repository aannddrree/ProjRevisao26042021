using Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class SaleDB : ISaleDB
    {

        public bool Insert(Sale sale)
        {
            bool status = false;

            string sql = string.Format(Sale.INSERT, sale.Description, sale.Client.Id, sale.Product.Id);

            using (var connection = new DB())
            {
                status = connection.ExecQuery(sql);
            }
            return status;
        }

        public bool Update(Sale sale)
        {
            bool status = false;

            string sql = string.Format(Sale.UPDATE, sale.Description, sale.Client.Id, sale.Product.Id, sale.Id);

            using (var connection = new DB())
            {
                status = connection.ExecQuery(sql);
            }
            return status;
        }

        public bool Delete(int id)
        {
            bool status = false;

            string sql = string.Format(Sale.DELETE, id);

            using (var connection = new DB())
            {
                status = connection.ExecQuery(sql);
            }
            return status;
        }

        public List<Sale> SelectAll()
        {
            string sql = Sale.SELECTALL;
            List<Sale> sales;

            using (var connection = new DB())
            {
                sales = TransformSQLDataReaderToList(connection.ExecQueryReturn(sql));
            }
            return sales;
        }

        public Sale SelectById(int id)
        {
            string sql = string.Format(Sale.SELECTBYID, id);
            Sale sale;

            using (var connection = new DB())
            {
                sale = TransformSQLDataReaderToList(connection.ExecQueryReturn(sql))[0];
            }
            return sale;
        }

        private List<Sale> TransformSQLDataReaderToList(SqlDataReader returnData)
        {
            var sales = new List<Sale>();

            while (returnData.Read())
            {
                var item = new Sale()
                {
                    Id = int.Parse(returnData["id"].ToString()),
                    Description = returnData["description"].ToString(),

                    Client = new Client() { 
                        Id = int.Parse(returnData["idClient"].ToString()), 
                        Name = returnData["nameClient"].ToString() 
                    },
                    Product = new Product() { 
                        Id = int.Parse(returnData["idProduct"].ToString()), 
                        Name = returnData["nameProduct"].ToString()
                    }
                };
                sales.Add(item);
            }
            return sales;
        }


    }
}
