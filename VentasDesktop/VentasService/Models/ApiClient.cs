using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VentasService.Models.BaseModel;
using VentasService.Models.BaseModel.Error;

namespace VentasService.Models
{
    public abstract class ApiClient<TData>
    {

        protected string Clase = "";

        protected static void InitializeClient(HttpClient client)
        {
            client.BaseAddress = new Uri(Global.vg_api);
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }
        public async Task<HttpResponseMessage> GetAll(string uri,
                   CancellationToken cancellationToken = new CancellationToken())
        {
            cancellationToken.ThrowIfCancellationRequested();
            using (var client = new HttpClient())
            {
                InitializeClient(client);
                try
                {
                    if (Global.vg_token != null)
                        client.DefaultRequestHeaders.Add("Authorization", "Bearer " + Global.vg_token);
                    HttpResponseMessage response = await client.GetAsync(
                        uri, cancellationToken);
                    return response;
                }
                catch (Exception e)
                {
                    StringContent message = new StringContent(e.Message.ToString());   
                    return new HttpResponseMessage() { StatusCode = HttpStatusCode.InternalServerError, Content = message };
                }
            }
        }

        public async Task<HttpResponseMessage> Get(string uri, CancellationToken cancellationToken = new CancellationToken())
        {
            cancellationToken.ThrowIfCancellationRequested();
            using (var client = new HttpClient())
            {
                InitializeClient(client);
                try
                {
                    if (Global.vg_token != null)
                        client.DefaultRequestHeaders.Add("Authorization", "Bearer " + Global.vg_token);
                    HttpResponseMessage response = await client.GetAsync(uri, cancellationToken);
                    return response;
                }
                catch (Exception e)
                {
                    StringContent message = new StringContent(e.Message.ToString());
                    return new HttpResponseMessage() { StatusCode = HttpStatusCode.InternalServerError, Content = message };
                }
            }
        }
        public static async Task<dynamic> Post(string requestUri, dynamic data,
             CancellationToken cancellationToken = new CancellationToken())
        {
            cancellationToken.ThrowIfCancellationRequested();
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
                    StringContent message = new StringContent(e.Message.ToString());
                    return new HttpResponseMessage() { StatusCode = HttpStatusCode.InternalServerError, Content = message };
                }
            }

        }

        public async Task<dynamic> Delete(string uri, dynamic dyn,
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
                    StringContent message = new StringContent(e.Message.ToString());
                    return new HttpResponseMessage() { StatusCode = HttpStatusCode.InternalServerError, Content = message };
                }
            }
        }
        public async Task<dynamic> Patch(string uri, dynamic dyn, CancellationToken cancellationToken = new CancellationToken())
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
                    StringContent message = new StringContent(e.Message.ToString());
                    return new HttpResponseMessage() { StatusCode = HttpStatusCode.InternalServerError, Content = message };
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
                    StringContent message = new StringContent(e.Message.ToString());
                    return new HttpResponseMessage() { StatusCode = HttpStatusCode.InternalServerError, Content = message };
                }
            }
        }
        public async Task<Response<TData>> Response(HttpResponseMessage response)
        {
            var errors = new List<BaseResponseDto>();
            try
            {
                if (response.IsSuccessStatusCode)
                {
                    if (!string.IsNullOrEmpty(await response.Content.ReadAsStringAsync()))
                    {
                        errors.Add(BaseResponseDto.create("", ""));
                        return Response<TData>.create(200, errors, await response.Content.ReadAsStringAsync());
                    }
                    if (response.StatusCode.Equals(HttpStatusCode.NoContent))
                    {
                        return Response<TData>.create(204, errors, null);
                    }
                    return Response<TData>.create(Convert.ToInt32(response.StatusCode.ToString()),
                        errors, null);
                }
                if (response.StatusCode != HttpStatusCode.OK 
                    && response.StatusCode != HttpStatusCode.InternalServerError)
                {
                    if (!string.IsNullOrEmpty(await response.Content.ReadAsStringAsync()))
                    {
                        JObject jObject = JObject.Parse(await response.Content.ReadAsStringAsync());
                        var values = VentasService.Util.JObjectExtensions.ToDictionary(jObject);
                        foreach (var error in values)
                        {
                            errors.Add(BaseResponseDto.create(error.Key, error.Value));
                        }
                        return Response<TData>.create(Convert.ToInt32(response.StatusCode.ToString()), errors);
                    }
                    errors.Add(BaseResponseDto.create(Clase, "Error consultando registro"));
                    return Response<TData>.create(500, errors);
                }
                errors.Add(BaseResponseDto.create(Clase, "Error no identificado"));
                return Response<TData>.create(500, errors);
            }
            catch (Exception e)
            {
                errors.Add(BaseResponseDto.create(Clase, e.Message));
                return Response<TData>.create(500, errors);
            }
        }
        public async Task<EnumerableResponse<List<TData>>> EnumerableResponse(HttpResponseMessage response)
        {
            var errors = new List<BaseResponseDto>();
            try
            {
                if (response.IsSuccessStatusCode)
                {
                    if (!string.IsNullOrEmpty(await response.Content.ReadAsStringAsync()))
                    {
                        errors.Add(BaseResponseDto.create("", ""));
                        return EnumerableResponse<List<TData>>.create(200, errors, await response.Content.ReadAsStringAsync());
                    }
                    if (response.StatusCode.Equals(HttpStatusCode.NoContent))
                    {
                        return EnumerableResponse<List<TData>>.create(204, errors, null);
                    }
                    return EnumerableResponse<List<TData>>.create(Convert.ToInt32(response.StatusCode.ToString()),
                        errors, null);
                }
                if (response.StatusCode != HttpStatusCode.OK
                    && response.StatusCode != HttpStatusCode.InternalServerError)
                {
                    if (!string.IsNullOrEmpty(await response.Content.ReadAsStringAsync()))
                    {
                        JObject jObject = JObject.Parse(await response.Content.ReadAsStringAsync());
                        var values = VentasService.Util.JObjectExtensions.ToDictionary(jObject);
                        foreach (var error in values)
                        {
                            errors.Add(BaseResponseDto.create(error.Key, error.Value));
                        }
                        return EnumerableResponse<List<TData>>.create(Convert.ToInt32(response.StatusCode.ToString()), errors);
                    }
                    errors.Add(BaseResponseDto.create(Clase, "Error consultando registro"));
                    return EnumerableResponse<List<TData>>.create(500, errors);
                }
                errors.Add(BaseResponseDto.create(Clase, "Error no identificado"));
                return EnumerableResponse<List<TData>>.create(500, errors);
            }
            catch (Exception e)
            {
                errors.Add(BaseResponseDto.create(Clase, e.Message));
                return EnumerableResponse<List<TData>>.create(500, errors);
            }
        }
        public async Task<EnumerableResponse<TData>> EnumerableResponseDataTable(HttpResponseMessage response)
        {
            var errors = new List<BaseResponseDto>();
            try
            {
                if (response.IsSuccessStatusCode)
                {
                    if (!string.IsNullOrEmpty(await response.Content.ReadAsStringAsync()))
                    {
                        errors.Add(BaseResponseDto.create("", ""));
                        return EnumerableResponse<TData>.create(200, errors, await response.Content.ReadAsStringAsync());
                    }
                    if (response.StatusCode.Equals(HttpStatusCode.NoContent))
                    {
                        return EnumerableResponse<TData>.create(204, errors, null);
                    }
                    return EnumerableResponse<TData>.create(Convert.ToInt32(response.StatusCode.ToString()),
                        errors, null);
                }
                if (response.StatusCode != HttpStatusCode.OK
                    && response.StatusCode != HttpStatusCode.InternalServerError)
                {
                    if (!string.IsNullOrEmpty(await response.Content.ReadAsStringAsync()))
                    {
                        JObject jObject = JObject.Parse(await response.Content.ReadAsStringAsync());
                        var values = VentasService.Util.JObjectExtensions.ToDictionary(jObject);
                        foreach (var error in values)
                        {
                            errors.Add(BaseResponseDto.create(error.Key, error.Value));
                        }
                        return EnumerableResponse<TData>.create(Convert.ToInt32(response.StatusCode.ToString()), errors);
                    }
                    errors.Add(BaseResponseDto.create(Clase, "Error consultando registro"));
                    return EnumerableResponse<TData>.create(500, errors);
                }
                errors.Add(BaseResponseDto.create(Clase, "Error no identificado"));
                return EnumerableResponse<TData>.create(500, errors);
            }
            catch (Exception e)
            {
                errors.Add(BaseResponseDto.create(Clase, e.Message));
                return EnumerableResponse<TData>.create(500, errors);
            }
        }
        private  Uri CreateUri(string uri)
        {
            return string.IsNullOrEmpty(uri) ? null : new Uri(uri, UriKind.RelativeOrAbsolute);
        }
    }
}
