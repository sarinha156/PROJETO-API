using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Services
{
    interface IRequest
    {
        Task<TResult> GetAsync<TResult>(string uri);

        Task<int> PostAsync<TResult>(string uri, TResult data);

        Task<int> PutAsync<TResult>(string uri, TResult data);

        Task<int> DeleteAsync(string uri);
    }
}
