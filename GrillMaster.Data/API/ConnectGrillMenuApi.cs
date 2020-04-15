using RestSharp;
using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text;

namespace GrillMaster.Data
{
    public class ConnectGrillMenuApi : IApi
    {
        private readonly RestClient _client;
        private readonly string _apiUrl;
        public ConnectGrillMenuApi(string apiUrl)
        {
            _apiUrl = apiUrl ?? throw new ArgumentNullException(nameof(apiUrl));
            _client = new RestClient(apiUrl);
        }

        /// <summary>
        /// Gets the JSON response from MenuAPI
        /// </summary>
        /// <returns></returns>
        public List<GrillMenuData> GetGrillMenuData()
        {            
            var request = new RestRequest(Method.GET);
            var response = _client.Execute(request);
            return JsonConvert.DeserializeObject<List<GrillMenuData>>(response.Content);
        }
    }
}
