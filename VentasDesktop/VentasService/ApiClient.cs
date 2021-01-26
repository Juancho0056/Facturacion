using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VentasModel.Entities.BaseEntities;

namespace VentasService
{
    public abstract class ApiClient
    {

        private static void InitializeClient(HttpClient client)
        {
            client.BaseAddress = new Uri(Global.vg_api);
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }


        public static async Task<dynamic> Get(
           string requestUri, CancellationToken cancellationToken = new CancellationToken())
        {
            cancellationToken.ThrowIfCancellationRequested();
            using (var client = new HttpClient())
            {
                InitializeClient(client);
                try
                {
                    if (Global.vg_token != null)
                        client.DefaultRequestHeaders.Add("Authorization", "Bearer " + Global.vg_token);
                    HttpResponseMessage response = await client.GetAsync(requestUri, cancellationToken);
                    return response;
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }
        
        public static async Task<dynamic> Post(string requestUri, dynamic data,
             CancellationToken cancellationToken = new CancellationToken())
        {
            cancellationToken.ThrowIfCancellationRequested();
            var errors = new List<BaseErrorDto>();
            using (var client = new HttpClient())
            {
                InitializeClient(client);
                try
                {
                    if (Global.vg_token != null)
                        client.DefaultRequestHeaders.Add("Authorization", "Bearer " + Global.vg_token);
                    string jsonString = JsonConvert.SerializeObject(data);
                    var httpContent = new StringContent(jsonString, Encoding.UTF8, "application/json");
                    var response = await client.PostAsync(requestUri, httpContent);
                    return response;
                }
                catch (Exception e)
                {
                    throw e;
                }
            }

        }

        public static async Task<dynamic> Delete(string uri, dynamic dyn,
            CancellationToken cancellationToken = new CancellationToken())
        {
            cancellationToken.ThrowIfCancellationRequested();
            using (var client = new HttpClient())
            {
                InitializeClient(client);
                try
                {
                    if (Global.vg_api != null)
                        client.DefaultRequestHeaders.Add("Authorization", "Bearer " + Global.vg_api);
                    string jsonString = JsonConvert.SerializeObject(dyn);
                    HttpRequestMessage request = new HttpRequestMessage
                    {
                        Content = new StringContent(jsonString, Encoding.UTF8, "application/json"),
                        Method = HttpMethod.Delete,
                        RequestUri = CreateUri(uri)
                    };
                    var response = await client.SendAsync(request);
                    return response;
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }
        
        public static async Task<dynamic> Patch(string uri, dynamic dyn, CancellationToken cancellationToken = new CancellationToken())
        {
            cancellationToken.ThrowIfCancellationRequested();
            using (var client = new HttpClient())
            {
                InitializeClient(client);
                try
                {
                    if (Global.vg_api != null)
                        client.DefaultRequestHeaders.Add("Authorization", "Bearer " + Global.vg_api);
                    string jsonString = JsonConvert.SerializeObject(dyn);
                    var httpContent = new StringContent(jsonString, Encoding.UTF8, "application/json");
                    var method = new HttpMethod("PATCH");
                    var request = new HttpRequestMessage(method, CreateUri(uri))
                    {
                        Content = httpContent
                    };
                    var response = await client.SendAsync(request);
                    return response;
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }
        public async static Task<dynamic> Put(string requestUri, dynamic dyn, CancellationToken cancellationToken = new CancellationToken())
        {
            cancellationToken.ThrowIfCancellationRequested();
            using (var client = new HttpClient())
            {
                InitializeClient(client);
                try
                {
                    if (Global.vg_api != null)
                        client.DefaultRequestHeaders.Add("Authorization", "Bearer " + Global.vg_api);

                    string jsonString = JsonConvert.SerializeObject(dyn);
                    var httpContent = new StringContent(jsonString, Encoding.UTF8, "application/json");
                    var response = await client.PutAsync(requestUri, httpContent);
                    return response;
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }
        public static async Task<dynamic> GetAll(string uri,
                    CancellationToken cancellationToken = new CancellationToken())
        {
            cancellationToken.ThrowIfCancellationRequested();
            using (var client = new HttpClient())
            {
                InitializeClient(client);
                try
                {
                    //if (Global.vg_api != null)
                    //    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + Global.vg_api);
                    HttpResponseMessage response = await client.GetAsync(
                        uri, cancellationToken);
                    return response;
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }
        private static Uri CreateUri(string uri)
        {
            return string.IsNullOrEmpty(uri) ? null : new Uri(uri, UriKind.RelativeOrAbsolute);
        }
    }
}
