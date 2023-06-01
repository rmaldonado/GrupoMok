using Application.DTO;
using Common.Models;

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TransversalCommon.Interfaces;

namespace TransversalCommon
{
    public class RestClient : IRestClient
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly IAppLogger _Logger;
        public RestClient(IAppLogger logger, IHttpClientFactory clientFactory)
        {
            _Logger = logger;
            _clientFactory = clientFactory;

        }

        public async Task<RestEntity> PostAsync(string uri, dynamic requestGenerate, List<DataItem>? listHeader = null)
        {
            RestEntity restEntity = new RestEntity();
            string idTransaction = string.Empty;
            try
            {
                var client = _clientFactory.CreateClient();
             

                var jsonParameters = JsonConvert.SerializeObject(requestGenerate);
                var content = new StringContent(jsonParameters, Encoding.UTF8, "application/json");
                var result = await client.PostAsync(uri, content);

                var statusCode = result.StatusCode;
                restEntity.StatusCode = Convert.ToInt32(statusCode);
                restEntity.ResultContent = result.Content.ReadAsStringAsync().Result;
            }
            catch (Exception e)
            {
                _Logger.LogError(e, "PostAsync");
                restEntity.ResultContent = e.Message;
            }
            return restEntity;
        }

        public async Task<RestEntity> GetAsync(string uri)
        {
            RestEntity restEntity = new();
            try
            {
                var client = _clientFactory.CreateClient();
                var result = await client.GetAsync(uri);
                var statusCode = result.StatusCode;
                restEntity.StatusCode = Convert.ToInt32(statusCode);
                restEntity.ResultContent = result.Content.ReadAsStringAsync().Result;
            }
            catch (Exception e)
            {
                _Logger.LogError(e, "GetAsync");
                restEntity.ResultContent = e.Message;
            }
            return restEntity;
        }



        public async Task<RestEntity> PostAsyncWithHeaders(string uri, List<HeaderRest> headers, dynamic request)
        {
            RestEntity restEntity = new RestEntity();
            try
            {
                var client = _clientFactory.CreateClient();
                var jsonParameters = JsonConvert.SerializeObject(request);
                var content = new StringContent(jsonParameters, Encoding.UTF8, "application/json");

                headers?.ForEach(x => client.DefaultRequestHeaders.Add(x.Name, x.Value));

                //Key Header*********
                client.DefaultRequestHeaders.Add("KeyPublic", "VErethUtraQuxas57wuMuquprADrAHAb");
                //Key Header*********

                var result = await client.PostAsync(uri, content);
                var statusCode = result.StatusCode;
                restEntity.StatusCode = Convert.ToInt32(statusCode);
                restEntity.ResultContent = result.Content.ReadAsStringAsync().Result;
            }
            catch (Exception e)
            {
                _Logger.LogError(e, "PostAsyncWithHeaders");
                restEntity.ResultContent = e.Message;
            }
            return restEntity;
        }



        public async Task<RestEntity> GetAsync(string uri, List<DataItem>? listHeader = null)
        {
            RestEntity restEntity = new RestEntity();
            string idTransaction = string.Empty;
            try
            {
                var client = _clientFactory.CreateClient();

                if (listHeader != null)
                {
                    idTransaction = listHeader.Find(delegate (DataItem item) { return item.Name == "transactionId"; }).Value;
                    client.DefaultRequestHeaders.Add("transactionId", idTransaction);
                }

                var result = await client.GetAsync(uri);
                var statusCode = result.StatusCode;
                restEntity.StatusCode = Convert.ToInt32(statusCode);
                restEntity.ResultContent = result.Content.ReadAsStringAsync().Result;
            }
            catch (Exception e)
            {
                _Logger.LogError(e, "GetAsync");
                restEntity.ResultContent = e.Message;
            }
            return restEntity;
        }

        public class HeaderRest
        {
            public string Name { get; set; }
            public string Value { get; set; }
        }

    }
}