

using PRHD_FULL.Modelos;
using PRHD_FULL.Modelos.Dto;
using PRHD_FULL.Repository;
using PRHD_FULL.Repository.IRepository;
using PRHD_FULL.Servicio;
using PRHD_FULL.Servicio.IServicio;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Headers;
using System.Web;
using AutoMapper.Internal;
using System.Net.Http;
using PRDH_FULL;
using AutoMapper;

namespace PRHD_FULL
{
    public class Filedata : IFiledata
    {
        private IFiledataser _file;
        private readonly IMapper _mapper;
        private readonly ILaboratoryTestRepositorio _lt;
        private readonly ICaseRepositorio _ca;

        public Filedata(IFiledataser File, IMapper Mapper, ILaboratoryTestRepositorio LT, ICaseRepositorio ca)
        {
           
            _file = File;
            _mapper = Mapper;
            _lt = LT;
            _ca = ca;
        }

        // metodo, ejecuta el metodoque realiza la peticion al servicio de HD y ejecuta al metodo InsertVal
        public async Task GetService(string path)
        {
            List<LaboratoryTestServiceDto> a = await _file.GetService();
            await InsertVal(a);

        }
        //Metodo, inserta y actualiza registros hacia las tablas LaboratoryTest y Case
        public async Task InsertVal(List<LaboratoryTestServiceDto> entidad)
        {
            List<LaboratoryTestDto> ent = _mapper.Map<List<LaboratoryTestDto>>(entidad);
            List<LaboratoryTest> modelo = _mapper.Map<List<LaboratoryTest>>(ent);
            await _lt.Insert(modelo);
            await _ca.InsertCase(modelo);
            //await _ca.InsertCase();


        }

    }
}
