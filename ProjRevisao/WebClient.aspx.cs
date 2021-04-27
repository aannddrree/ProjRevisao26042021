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
    public partial class WebClient : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadGrid();
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            Client client = new Client()
            {
                Name = TxtName.Text,
                Telephone = TxtTelephone.Text,
                Id = string.IsNullOrEmpty(HFId.Value) ? 0 : int.Parse(HFId.Value)
            };

            var db = new ClientDB();

            if (client.Id == 0)
            {
                if (db.Insert(client))
                {
                    LblMSG.Text = "Registro Inserido!";
                }
                else
                {
                    LblMSG.Text = "Erro ao inserir registro";
                }
            }
            else
            {
                if (db.Update(client))
                {
                    LblMSG.Text = "Registro Atualizado!";
                }
                else
                {
                    LblMSG.Text = "Erro ao atualizar registro";
                }
            }
            LoadGrid();
        }

        private void LoadGrid()
        {
            GVClient.DataSource = new ClientDB().SelectAll();
            GVClient.DataBind();
        }

        protected void GVClient_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            var row = GVClient.Rows[index];

            Client client = new Client()
            {
                Id = int.Parse(row.Cells[0].Text),
                Name = row.Cells[1].Text,
                Telephone = row.Cells[2].Text
            };

            var db = new ClientDB();

            if (e.CommandName == "EXCLUIR")
            {
                db.Delete(client.Id);
                LoadGrid();
            }
            else if (e.CommandName == "ALTERAR")
            {
                TxtName.Text = client.Name;
                TxtTelephone.Text = client.Telephone;
                HFId.Value = client.Id.ToString();
            }
        }

        protected void BtnNovo_Click(object sender, EventArgs e)
        {
            TxtName.Text = "";
            TxtTelephone.Text = "";
            HFId.Value = "0";
            TxtName.Focus();
        }
    }
}