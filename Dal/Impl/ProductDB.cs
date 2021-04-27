using Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class ProductDB : IProductDB
    {

        public bool Insert(Product product)
        {
            bool status = false;

            string sql = string.Format(Product.INSERT, product.Name);

            using (var connection = new DB())
            {
                status = connection.ExecQuery(sql);
            }
            return status;
        }

        public bool Update(Product product)
        {
            bool status = false;

            string sql = string.Format(Product.UPDATE, product.Name, product.Id);

            using (var connection = new DB())
            {
                status = connection.ExecQuery(sql);
            }
            return status;
        }

        public bool Delete(int id)
        {
            bool status = false;

            string sql = string.Format(Product.DELETE, id);

            using (var connection = new DB())
            {
                status = connection.ExecQuery(sql);
            }
            return status;
        }

        public List<Product> SelectAll()
        {
            string sql = Product.SELECTALL;
            List<Product> products;

            using (var connection = new DB())
            {
                products = TransformSQLDataReaderToList(connection.ExecQueryReturn(sql));
            }
            return products;
        }

        public Product SelectById(int id)
        {
            string sql = string.Format(Product.SELECTBYID, id);
            Product product;

            using (var connection = new DB())
            {
                product = TransformSQLDataReaderToList(connection.ExecQueryReturn(sql))[0];
            }
            return product;
        }

        private List<Product> TransformSQLDataReaderToList(SqlDataReader returnData)
        {
            var products = new List<Product>();

            while (returnData.Read())
            {
                var item = new Product()
                {
                    Id = int.Parse(returnData["id"].ToString()),
                    Name = returnData["name"].ToString()
                };

                products.Add(item);
            }
            return products;
        }
    }
}
