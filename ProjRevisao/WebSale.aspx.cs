using Dal;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjRevisao
{
    public partial class WebSale : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadGrid();
            LoadClient();
            LoadProduct();
        }

        protected void BtnSalvar_Click(object sender, EventArgs e)
        {
            Sale sale = new Sale()
            {
                Description = TxtDescription.Text,
                Client = new Client() { Id = int.Parse(DDLClient.SelectedValue)},
                Product = new Product() { Id = int.Parse(DDLProduct.SelectedValue) },
            };

            var db = new SaleDB();

            if (db.Insert(sale))
            {
                LblMSG.Text = "Registro Inserido!";
            }
            else
            {
                LblMSG.Text = "Erro ao Inserir Registro";
            }
        }

        public void LoadClient()
        {
            DDLClient.DataSource = new ClientDB().SelectAll();
            DDLClient.DataTextField = "Name";
            DDLClient.DataValueField = "Id";
            DDLClient.DataBind();
        }

        public void LoadProduct()
        {
            DDLProduct.DataSource = new ProductDB().SelectAll();
            DDLProduct.DataTextField = "Name";
            DDLProduct.DataValueField = "Id";
            DDLProduct.DataBind();
        }

        private void LoadGrid()
        {
            GVSale.DataSource = new SaleDB().SelectAll();
            GVSale.DataBind();
        }
    }
}