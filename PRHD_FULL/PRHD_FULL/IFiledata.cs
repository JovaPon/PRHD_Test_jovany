using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PRHD_FULL.Modelos;
using PRHD_FULL.Modelos.Dto;

namespace PRDH_FULL
{
    public interface IFiledata
    {
        //public Task<List<LaboratoryTestServiceDto>>  GetService();
        public Task GetService(string path);

        Task InsertVal(List<LaboratoryTestServiceDto> entidad);
    }
}
