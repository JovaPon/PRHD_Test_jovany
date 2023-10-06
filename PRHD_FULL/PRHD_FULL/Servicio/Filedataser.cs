

using PRHD_FULL.Modelos;
using PRHD_FULL.Modelos.Dto;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Headers;
using System.Web;
using AutoMapper.Internal;
using System.Net.Http;
using PRHD_FULL.Servicio.IServicio;
using PRHD_Lib;

namespace PRHD_FULL.Servicio
{
    public class Filedataser : IFiledataser
    {
        public IHttpClientFactory _httpClient { get; set; }
        List<LaboratoryTestServiceDto> DataTest { get; set; }

        private string? _LabTestUrl;
        //IHttpClientFactory httpClient
        public Filedataser(IHttpClientFactory httpClient, IConfiguration configuration)
        {
            DataTest = new();
            _httpClient = httpClient;
            _LabTestUrl = configuration.GetValue<string>("ServiceUrls:API_URL");
        }


        //Metodo, realiza la peticion al servidor de HD 
        public async Task<List<LaboratoryTestServiceDto>> GetService()
        {
            var da = DateTimeOffset.Parse(DS.SCStartDate).UtcDateTime;
            var db = DateTimeOffset.Parse(DS.SCEndDate).UtcDateTime;
            var dc = DateTimeOffset.Parse(DS.CStartDate).UtcDateTime;
            var dd = DateTimeOffset.Parse(DS.CEndtDate).UtcDateTime;

            try
            {
                var client = _httpClient.CreateClient("PRHD");
                HttpRequestMessage message = new HttpRequestMessage();
                message.Headers.Add("Accept", "application/json");


                //-------------------
                var builder = new UriBuilder(_LabTestUrl); ////////////add url
                var query = HttpUtility.ParseQueryString(builder.Query);
                query["OrderTestId"] = "";
                query["OrderTestCategory"] = DS.OrderTestCategory.ToString();///
                query["OrderTestType"] = DS.TypeM.ToString();
                query["SampleCollectedStartDate"] = da.ToString("o");
                query["SampleCollectedEndDate"] = db.ToString("o");
                query["CreatedAtStartDate"] = dc.ToString("o");
                query["CreatedAtEndDate"] = dd.ToString("o");

                builder.Query = query.ToString();
                string url = builder.ToString();     //   
                message.RequestUri = new Uri(url);
                //-------------------

                message.Method = HttpMethod.Get;

                HttpResponseMessage apiResponse = null;
                apiResponse = await client.SendAsync (message);
                //var apiResponse = await client.GetAsync(url);
                if (apiResponse.IsSuccessStatusCode)
                {

                    var apiContent = await apiResponse.Content.ReadAsStringAsync();
                    //List<LaboratoryTestServiceDto>? response = JsonConvert.DeserializeObject<List<LaboratoryTestServiceDto>>(apiContent);
                    DataTest = JsonConvert.DeserializeObject<List<LaboratoryTestServiceDto>>(apiContent);
                    return DataTest;
                }

                return DataTest;
            
            }
            catch (Exception ex)
            {
                return DataTest;
            }

        }

    }
}
