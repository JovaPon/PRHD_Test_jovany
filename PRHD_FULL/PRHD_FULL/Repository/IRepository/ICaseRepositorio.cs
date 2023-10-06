using PRHD_FULL.Modelos;
using PRHD_FULL.Modelos.Dto;

namespace PRHD_FULL.Repository.IRepository
{
    public interface ICaseRepositorio : IRepositorio<Case>
    {
        Task InsertCase(List<LaboratoryTest> modelo);
        Task<List<Case>> GetAllCases(List<LaboratoryTest> modelo);
    }
}
