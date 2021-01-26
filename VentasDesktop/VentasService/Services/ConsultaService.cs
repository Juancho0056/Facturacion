

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Threading.Tasks;
using VentasService.Models.BaseModel;
using VentasService.Models.BaseModel.Error;

namespace VentasService.Services
{
    public class ConsultaService: VentasService.Models.ApiClient<DataTable>
    {
        private static ConsultaService instancia;
        public static ConsultaService getInstancia()
        {
            if (instancia == null)
            {
                instancia = new ConsultaService();
            }
            return instancia;
        }

        public async Task<EnumerableResponse<DataTable>> GetConsultaDataTable(string busqueda, string table, string tipo, int page, int limit,
            CancellationToken cancellationToken = new CancellationToken())
        {
            var errors = new List<BaseResponseDto>();
            cancellationToken.ThrowIfCancellationRequested();
            try
            {
                var response = await EnumerableResponseDataTable(await Get(string.Format("api/Consulta/GetAll?tabla={0}&tipo={1}&busqueda={2}&page={3}&limit={4}",
                    table, tipo, busqueda, page, limit)));
                if (response.ErrorCode == 200) 
                {
                    dynamic data = (JObject)JsonConvert.DeserializeObject(response.jObject, (typeof(JObject)));
                    response.Data = (DataTable)JsonConvert.DeserializeObject(data["data"].ToString(), (typeof(DataTable)));
                    response.Count = data["count"] != null ? Convert.ToInt32(data["count"].ToString()) : 0;
                    response.Pages = data["pages"] != null ? Convert.ToInt32(data["pages"].ToString()) : 0;
                }
                return response;
            }
            catch (Exception e)
            {
                errors.Add(BaseResponseDto.create(Clase, e.Message));
                return EnumerableResponse<DataTable>.create(500, errors);
            }
        }

        //public async Task<ResponseDto<DataTable>> GetConsultaDataTable(string busqueda, string table, string tipo, int page, int limit,
        //    string authToken = null,
        //    CancellationToken cancellationToken = new CancellationToken())
        //{
        //    cancellationToken.ThrowIfCancellationRequested();
        //    try
        //    {
        //        var response = await ApiClient.Get(string.Format("api/Consulta/GetAll?tabla={0}&tipo={1}&busqueda={2}&page={3}&limit={4}",
        //            table, tipo, busqueda, page, limit));
        //        var prueba = await response.Content.ReadAsStringAsync();
        //        var result = new ResponseDto<DataTable>();
        //        dynamic data = (JObject)JsonConvert.DeserializeObject(await response.Content.ReadAsStringAsync(), (typeof(JObject)));
        //        result.Count = data["count"] != null ? Convert.ToInt32(data["count"].ToString()) : 0;
        //        result.Pages = data["pages"] != null ? Convert.ToInt32(data["pages"].ToString()) : 0;
        //        result.Data = (DataTable)JsonConvert.DeserializeObject(data["data"].ToString(), (typeof(DataTable)));
        //        return result;
        //    }
        //    catch (Exception e)
        //    {
        //        return null;
        //    }
        //}
    }
}
