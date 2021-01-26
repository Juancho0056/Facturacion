using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using VentasModel.Entities;
using VentasService.Models.BaseModel;
using VentasService.Models.BaseModel.Error;

namespace VentasService.Services
{
    public class MenuService: VentasService.Models.ApiClient<Menu>
    {
        private static MenuService instancia;
        public static MenuService getInstancia()
        {
            if (instancia == null)
            {
                instancia = new MenuService();
            }
            return instancia;
        }

        private MenuService()
        {

        }
        public async Task<EnumerableResponse<List<Menu>>> GetMenuUsuario(int? padre, string authToken = null, CancellationToken cancellationToken = new CancellationToken())
        {
            var errors = new List<BaseResponseDto>();
            cancellationToken.ThrowIfCancellationRequested();
            try
            {
                var response = await EnumerableResponse(await GetAll(string.Format("api/Menu/MenuUsuario?padre={0}",  padre)));
                var data = new List<Menu>();
                if (response.ErrorCode == 200) 
                {
                    dynamic jObject = (JObject)JsonConvert.DeserializeObject(response.jObject, (typeof(JObject)));
                    foreach (JObject json in ((JArray)jObject["data"]).Children<JObject>())
                    {
                        data.Add(Menu.create(json));
                    }
                }
                response.Data = data;
                return response;
            }
            catch (Exception e)
            {
                errors.Add(BaseResponseDto.create(Clase, e.Message));
                return EnumerableResponse<List<Menu>>.create(500, errors);
            }
        }

    }
}
