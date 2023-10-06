using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PRHD_FULL.Modelos;
using PRHD_FULL.Modelos.Dto;

namespace PRHD_FULL.Servicio.IServicio
{
    public interface IFiledataser
    {
        public Task<List<LaboratoryTestServiceDto>> GetService();
        //public Task GetService(string path);
    }
}
