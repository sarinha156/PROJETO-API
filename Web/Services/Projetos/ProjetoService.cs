using Library.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Web.Services.Projetos
{
    public class ProjetoService : IProjetoService
    {
        private readonly IRequest _request;
        private const string ApiUrlBase = "http://quiteriaetec.somee.com/api/Projetos";

        public ProjetoService()
        {
            _request = new Request();
        }

        public async Task<ObservableCollection<Projeto>> GetProjetosAsync()
        {

            ObservableCollection<Projeto> Projetos = await
                _request.GetAsync<ObservableCollection<Projeto>>(ApiUrlBase);

            return Projetos;
        }

        public async Task<Projeto> GetProjetoAsync(int id)
        {
            string urlComplementar = string.Format("/{0}", id);
            return await _request.GetAsync<Projeto>(ApiUrlBase + urlComplementar);
        }

        public async Task<int> PostProjetoAsync(Projeto c)
        {
            return await _request.PostAsync(ApiUrlBase, c);
        }

        public async Task<int> PutProjetoAsync(Projeto c)
        {
            var result = await _request.PutAsync(ApiUrlBase, c);
            return result;
        }

        public async Task<int> DeleteProjetoAsync(int ProjetoID)
        {
            string urlComplementar = string.Format("/{0}", ProjetoID);
            return await _request.DeleteAsync(ApiUrlBase + urlComplementar);
        }
    }
}