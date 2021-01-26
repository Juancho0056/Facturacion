using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using VentasModel.Entities;
using VentasModel.Entities.BaseEntities;

namespace VentasService.Services
{
    public class UsuarioService
    {
        private static UsuarioService instancia;

        public static UsuarioService getInstancia()
        {
            if (instancia == null)
            {
                instancia = new UsuarioService();
            }
            return instancia;
        }

        private UsuarioService()
        {

        }
        private static void InitializeClient(HttpClient client)
        {
            client.BaseAddress = new Uri(Global.vg_api);
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }


        public async Task<UsuarioDto> Login(string username, string password, 
            CancellationToken cancellationToken = new CancellationToken())
        {
            cancellationToken.ThrowIfCancellationRequested();
            var errors = new List<BaseErrorDto>();
            try
            {
                var response = await ApiClient.Post("api/Auth/login", new { username = username, password = password });
                if (response.IsSuccessStatusCode)
                {
                    if (!string.IsNullOrEmpty(await response.Content.ReadAsStringAsync()))
                    {
                        JObject jObject = JObject.Parse(await response.Content.ReadAsStringAsync());
                        var user = (JObject)jObject["user"];
                        errors.Add(BaseErrorDto.create("Usuario", ""));
                        return UsuarioDto.create(UsuarioDto.create((JObject)user["data"]), errors, 200);
                    }
                    return UsuarioDto.create(UsuarioDto.create(), errors, Convert.ToInt32(response.StatusCode.ToString()));
                }
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    if (!string.IsNullOrEmpty(await response.Content.ReadAsStringAsync()))
                    {
                        JObject jObject = JObject.Parse(await response.Content.ReadAsStringAsync());
                        var values = VentasService.Util.JObjectExtensions.ToDictionary(jObject);
                        foreach (var error in values)
                        {
                            errors.Add(BaseErrorDto.create(error.Key, error.Value));
                        }
                        return UsuarioDto.create(errors, 400);
                    }
                    errors.Add(BaseErrorDto.create("Usuario", "Error consultando registro"));
                    return UsuarioDto.create(errors, 500);
                }
            }
            catch (UriFormatException er)
            {
                errors.Add(BaseErrorDto.create("Usuario", er.Message));
                return UsuarioDto.create(errors, 500);
            }
            catch (Exception e)
            {
                errors.Add(BaseErrorDto.create("Usuario", e.Message));
                return UsuarioDto.create(errors, 500);
            }
            return null;
        }
    }
}
