using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Models;

namespace Web.Services.Projetos
{
    
        public interface IProjetoService
        {
            Task<ObservableCollection<Projeto>> GetProjetosAsync();

            Task<Projeto> GetProjetoAsync(int id);

            Task<int> PostProjetoAsync(Projeto c);

            Task<int> PutProjetoAsync(Projeto c);

            Task<int> DeleteProjetoAsync(int projetoId);
        }

    
}
