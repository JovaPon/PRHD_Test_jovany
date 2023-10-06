using PRHD_FULL.Modelos;
using PRHD_FULL.Modelos.Dto;
using System.Linq.Expressions;

namespace PRHD_FULL.Repository.IRepository
{
    public interface ILaboratoryTestRepositorio : IRepositorio<LaboratoryTest>
    {
        Task Insert(List<LaboratoryTest> entidad);
        Task<List<SampleCDateDto>> GetSampleCases(Expression<Func<LaboratoryTest, bool>>? filtro = null);
    }
}
