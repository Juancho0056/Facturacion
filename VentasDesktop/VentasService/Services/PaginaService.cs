using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using VentasModel.Entities;
using VentasModel.Entities.BaseEntities;
using VentasService.Models.BaseModel;

namespace VentasService.Services
{
    public class PaginaService : VentasService.Models.ApiClient<PaginaDto>
    {
        private static PaginaService instancia;

        public static PaginaService getInstancia()
        {
            if (instancia == null)
            {
                instancia = new PaginaService();
            }
            return instancia;
        }

        private PaginaService()
        {

        }
        public async Task<EnumerableResponse<List<PaginaDto>>> GetAll(int id, int page, int limit,
            CancellationToken cancellationToken = new CancellationToken())
        {
            cancellationToken.ThrowIfCancellationRequested();
            try
            {
                var result = new EnumerableResponse<List<PaginaDto>>();
                var response = await EnumerableResponse(await GetAll(
                    string.Format("api/Pagina/GetAll?id={0}&page={1}&limit={2}", id, page, limit).ToString(), cancellationToken));
                var data = new List<PaginaDto>();
                
                if (response.ErrorCode == 200)
                {
                    //JObject jObject = JObject.Parse(await response.Content.ReadAsStringAsync());
                    //foreach (JObject json in ((JArray)jObject["data"]).Children<JObject>())
                    //{
                    //    data.Add(PaginaDto.create(json));
                    //}
                    dynamic jObject = (JObject)JsonConvert.DeserializeObject(response.jObject, (typeof(JObject)));
                    foreach (JObject json in ((JArray)jObject["data"]).Children<JObject>())
                    {
                        data.Add(PaginaDto.create(json));
                    }
                    result.Count = jObject["count"]!=null?Convert.ToInt32(jObject["count"].ToString()):0;
                    result.Pages = jObject["pages"] != null ? Convert.ToInt32(jObject["pages"].ToString()):0;
                    result.Total = jObject["total"] != null ? Convert.ToInt32(jObject["total"].ToString()):0;
                    return result;
                }
                return result;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public async Task<PaginaDto> GetPagina(int id, string authToken = null, CancellationToken cancellationToken = new CancellationToken())
        {
            cancellationToken.ThrowIfCancellationRequested();
            var errors = new List<BaseErrorDto>();
            try
            {
                HttpResponseMessage response = await ApiClient.Get(string.Format("api/Pagina/Get?id={0}", id), cancellationToken);
                if (response.IsSuccessStatusCode)
                {
                    if (!string.IsNullOrEmpty(await response.Content.ReadAsStringAsync()))
                    {
                        JObject jObject = JObject.Parse(await response.Content.ReadAsStringAsync());
                        errors.Add(BaseErrorDto.create("Pagina", ""));
                        return PaginaDto.create(PaginaDto.create(jObject), errors, 200);
                    }
                    if (response.StatusCode.Equals(HttpStatusCode.NoContent)) 
                    {
                        return PaginaDto.create(PaginaDto.create(), errors, Convert.ToInt32(204));   
                    }
                    return PaginaDto.create(PaginaDto.create(), errors, Convert.ToInt32(response.StatusCode.ToString()));
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
                        return PaginaDto.create(errors, Convert.ToInt32(response.StatusCode.ToString()));
                    }
                    errors.Add(BaseErrorDto.create("Pagina", "Error consultando registro"));
                    return PaginaDto.create(errors, 500);
                }
            }
            catch (Exception e)
            {
                errors.Add(BaseErrorDto.create("Pagina", e.Message));
                return PaginaDto.create(errors, 500);
            }
            return null;
        }
        
        public async Task<PaginaDto> Delete(int id,
            CancellationToken cancellationToken = new CancellationToken())
        {
            cancellationToken.ThrowIfCancellationRequested();
            var errors = new List<BaseErrorDto>();
            try
            {
                var dyn = new { Id = id};
                HttpResponseMessage response = await ApiClient.Delete("api/Pagina/Delete", dyn);
                if (response.IsSuccessStatusCode)
                {
                    if (!string.IsNullOrEmpty(await response.Content.ReadAsStringAsync()))
                    {
                        JObject jObject = JObject.Parse(await response.Content.ReadAsStringAsync());
                        errors.Add(BaseErrorDto.create("Pagina", "Registro eliminado exitosamente"));
                        return PaginaDto.create(PaginaDto.create(jObject), errors, 200);
                    }
                    return PaginaDto.create(PaginaDto.create(), errors, Convert.ToInt32(response.StatusCode.ToString()));
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
                        return PaginaDto.create(errors, 400);
                    }
                }
                errors.Add(BaseErrorDto.create("Pagina", "Error Eliminando registro"));
                return PaginaDto.create(errors, 500);
            }
            catch (Exception e)
            {
                errors.Add(BaseErrorDto.create("Pagina", e.Message));
                return PaginaDto.create(errors, 500);
            }
        }
        public async Task<PaginaDto> Update(PaginaDto pagina, string authToken = null, CancellationToken cancellationToken = new CancellationToken())
        {
            cancellationToken.ThrowIfCancellationRequested();
            var errors = new List<BaseErrorDto>();
            try
            {
                HttpResponseMessage response = await ApiClient.Patch("api/Pagina/Update", pagina, cancellationToken);
                if (response.IsSuccessStatusCode)
                {
                    if (!string.IsNullOrEmpty(await response.Content.ReadAsStringAsync()))
                    {
                        JObject jObject = JObject.Parse(await response.Content.ReadAsStringAsync());
                        errors.Add(BaseErrorDto.create("Pagina", "Registro actualizado exitosamente"));
                        return PaginaDto.create(PaginaDto.create(jObject), errors, 200);
                    }
                    return PaginaDto.create(PaginaDto.create(), errors, Convert.ToInt32(response.StatusCode.ToString()));
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
                        return PaginaDto.create(errors, 400);
                    }
                }
                errors.Add(BaseErrorDto.create("Pagina", "Error actualizando registro"));
                return PaginaDto.create(errors, 500);
            }
            catch (Exception e)
            {
                errors.Add(BaseErrorDto.create("Pagina", e.Message));
                return PaginaDto.create(errors, 500);
            }
            
        }
        public async Task<PaginaDto> GuardarPagina(PaginaDto pagina, string authToken = null, CancellationToken cancellationToken = new CancellationToken())
        {
            cancellationToken.ThrowIfCancellationRequested();
                try
                {
                    var response = await ApiClient.Post("api/Pagina/Create", pagina, cancellationToken);
                    var errors = new List<BaseErrorDto>();
                    if (response.IsSuccessStatusCode)
                    {
                        JObject jObject = JObject.Parse(await response.Content.ReadAsStringAsync());
                        errors.Add(BaseErrorDto.create("Pagina", "Registro almacenado exitosamente"));
                        return PaginaDto.create(PaginaDto.create(jObject), errors, 200);
                    }
                    if (response.StatusCode != HttpStatusCode.OK) 
                    {
                        JObject jObject = JObject.Parse(await response.Content.ReadAsStringAsync());      
                        var values = VentasService.Util.JObjectExtensions.ToDictionary(jObject);
                        foreach (var error in values) 
                        {
                            errors.Add(BaseErrorDto.create(error.Key, error.Value));
                        }
                        return PaginaDto.create(errors, response.StatusCode);
                    }
                    
                }
                catch (Exception e)
                {
                    throw e;
                }
            
            return null;

        }

        public async Task<PaginaDto> Get(int id,
            CancellationToken cancellationToken = new CancellationToken())
        {
            cancellationToken.ThrowIfCancellationRequested();
            
            try
            {
                HttpResponseMessage response =  await ApiClient.Get(string.Format("api/Pagina/Get?id={0}", id), cancellationToken);
                if (response.IsSuccessStatusCode) 
                {
                    JObject jObject = JObject.Parse(await response.Content.ReadAsStringAsync());
                    var errors = new List<BaseErrorDto>();
                    return PaginaDto.create(PaginaDto.create(jObject), errors, 200);
                }
                return null;
            }
            catch (Exception e)
            {
                throw e; ;
            }
        }
        
    }
}
