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
    public class PermisosService: VentasService.Models.ApiClient<PermisosDto>
    {
        private static PermisosService instancia;
        public static PermisosService getInstancia()
        {
            if (instancia == null)
            {
                instancia = new PermisosService();
            }
            return instancia;
        }

        private PermisosService()
        {

        }
        public async Task<EnumerableResponse<List<PermisosDto>>> GetPermisosPagina(int? padre, 
            CancellationToken cancellationToken = new CancellationToken())
        {
            var errors = new List<BaseResponseDto>();
            cancellationToken.ThrowIfCancellationRequested();
            try
            {
                var response = await EnumerableResponse(await GetAll(string.Format("api/Permiso/PermisosPagina?Pagina={0}", padre)));
                var data = new List<PermisosDto>();
                if (response.ErrorCode == 200) 
                {
                    dynamic jObject = (JObject)JsonConvert.DeserializeObject(response.jObject, (typeof(JObject)));
                    foreach (JObject json in ((JArray)jObject["data"]).Children<JObject>())
                    {
                        data.Add(PermisosDto.create(json));
                    }
                }
                response.Data = data;
                return response;
            }
            catch (Exception e)
            {
                errors.Add(BaseResponseDto.create(Clase, e.Message));
                return EnumerableResponse<List<PermisosDto>>.create(500, errors);
            }
        }
        public async Task<Response<PermisosDto>> CreatePermiso(PermisosDto permiso,
            CancellationToken cancellationToken = new CancellationToken())
        {
            var errors = new List<BaseResponseDto>();
            cancellationToken.ThrowIfCancellationRequested();
            try
            {
                var response = await Response(await Post("api/Permiso/create",permiso));
                var data = new List<PermisosDto>();
                if (response.ErrorCode == 200)
                {
                    dynamic jObject = (JObject)JsonConvert.DeserializeObject(response.jObject, (typeof(JObject)));
                    data.Add(PermisosDto.create(jObject));
                }
                response.Data = data;
                return response;
            }
            catch (Exception e)
            {
                errors.Add(BaseResponseDto.create(Clase, e.Message));
                return Response<PermisosDto>.create(500, errors);
            }
        }
        public async Task<Response<PermisosDto>> UpdatePermiso(PermisosDto permiso,
            CancellationToken cancellationToken = new CancellationToken())
        {
            var errors = new List<BaseResponseDto>();
            cancellationToken.ThrowIfCancellationRequested();
            try
            {
                var response = await Response(await Patch("api/Permiso/update", permiso));
                var data = new List<PermisosDto>();
                if (response.ErrorCode == 200)
                {
                    dynamic jObject = (JObject)JsonConvert.DeserializeObject(response.jObject, (typeof(JObject)));
                    data.Add(PermisosDto.create(jObject));
                }
                response.Data = data;
                return response;
            }
            catch (Exception e)
            {
                errors.Add(BaseResponseDto.create(Clase, e.Message));
                return Response<PermisosDto>.create(500, errors);
            }
        }
        public async Task<Response<PermisosDto>> DeletePermiso(PermisosDto permiso,
            CancellationToken cancellationToken = new CancellationToken())
        {
            var errors = new List<BaseResponseDto>();
            cancellationToken.ThrowIfCancellationRequested();
            try
            {
                var response = await Response(await Delete("api/Permiso/delete", permiso));
                var data = new List<PermisosDto>();
                if (response.ErrorCode == 200)
                {
                    dynamic jObject = (JObject)JsonConvert.DeserializeObject(response.jObject, (typeof(JObject)));
                    data.Add(PermisosDto.create(jObject));
                }
                response.Data = data;
                return response;
            }
            catch (Exception e)
            {
                errors.Add(BaseResponseDto.create(Clase, e.Message));
                return Response<PermisosDto>.create(500, errors);
            }
        }
    }
}
