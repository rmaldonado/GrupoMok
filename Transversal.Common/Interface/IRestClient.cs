using Application.DTO;
using Common.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using static TransversalCommon.RestClient;

namespace TransversalCommon.Interfaces
{
    public interface IRestClient
    {
        Task<RestEntity> PostAsync(string uri, dynamic requestGenerate, List<DataItem>? listHeader = null);
        Task<RestEntity> GetAsync(string uri);

        Task<RestEntity> GetAsync(string uri, List<DataItem>? listHeader = null);

        Task<RestEntity> PostAsyncWithHeaders(string uri, List<HeaderRest> headers, dynamic request);
       
    }
}
