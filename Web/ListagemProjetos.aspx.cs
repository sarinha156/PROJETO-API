using Library.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web.Services.Projetos;

namespace Web
{
    public partial class ListagemProjetos : System.Web.UI.Page
    {
        private IProjetoService pService = new ProjetoService();
        protected async Task CarregarProjetos()
        {
            ObservableCollection<Projeto> listaProjetos = await pService.GetProjetosAsync();
            gvProjetos.DataSource = listaProjetos.ToList();
            gvProjetos.DataBind();
        }

        protected async Task SalvarProjeto()
        {
            Projeto p = new Projeto();
            p.Id = !string.IsNullOrEmpty(txtId.Text) ? Convert.ToInt32(txtId.Text) : 0;
            p.Nome = txtNomeProjeto.Text;
            p.Sala = txtSala.Text;
            p.Turma = txtTurma.Text;
            p.Orientadores = txtOrientadores.Text;

            if (string.IsNullOrEmpty(txtId.Text))
            {
                p.Id = await pService.PostProjetoAsync(p);
                if (p.Id > 0)
                    lblMensagem.Text = string.Format("Projeto Id {0} Salvo com sucesso", p.Id);
            }
            else
            {
                int linhasAfetadas = await pService.PutProjetoAsync(p);

                if (linhasAfetadas != 0)
                    lblMensagem.Text = "Projeto atualizado com sucesso.";
            }
        }

        protected async Task ObterPorId()
        {
            int numero = Convert.ToInt32(gvProjetos.SelectedValue);
            Projeto p = await pService.GetProjetoAsync(numero);

            txtId.Text = p.Id.ToString();
            txtNomeProjeto.Text = p.Nome;
            txtTurma.Text = p.Turma;
            txtSala.Text = p.Sala;
            txtOrientadores.Text = p.Orientadores;
        }

        protected async Task Excluir()
        {
            int id = Convert.ToInt32(txtId.Text);
            int linhaAfetadas = await pService.DeleteProjetoAsync(id);

            if (linhaAfetadas > 0)
                lblMensagem.Text = "Projeto excluído com Sucesso";
        }

        protected void Page_Load(object sender, EventArgs e)
        {   
            if (!Page.IsPostBack)
            {
                RegisterAsyncTask(new PageAsyncTask(CarregarProjetos));
            }
        }

        protected void gvProjetos_SelectedIndexChanged(object sender, EventArgs e)
        {
            RegisterAsyncTask(new PageAsyncTask(ObterPorId));
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            RegisterAsyncTask(new PageAsyncTask(SalvarProjeto));
            RegisterAsyncTask(new PageAsyncTask(CarregarProjetos));
        }

        protected void btnExcluir_Click(object sender, EventArgs e)
        {
            RegisterAsyncTask(new PageAsyncTask(Excluir));
            RegisterAsyncTask(new PageAsyncTask(CarregarProjetos));
        }

        
    }
}