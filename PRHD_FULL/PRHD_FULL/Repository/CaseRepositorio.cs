using PRHD_FULL;
using PRHD_FULL.Data;
using PRHD_FULL.Modelos;
using PRHD_FULL.Modelos.Dto;
using PRHD_FULL.Repository.IRepository;
using PRHD_Lib;


using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace PRHD_FULL.Repository
{
    public class CaseRepositorio : Repositorio<Case>, ICaseRepositorio
    {

        private readonly ApplicationDbContext _db;

        public CaseRepositorio(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        //Metodo, realiza la logica para la tabla de case
        public async Task<List<Case>> GetAllCases(List<LaboratoryTest> modelo)
        {
            try
            {

                var mod = modelo.Where(x => DS.Fpositive.Contains(x.OrderTestResult))
                                .GroupBy(n => new { n.PatientId })
                                    .Select(c => new
                                    {

                                        PatientId = c.Key.PatientId,

                                        EarliestPosiƟveOrderTestSampleCollectedDate = c.Select(d => d.SampleCollectedDate).
                                        OrderByDescending(z => z).FirstOrDefault(),

                                        EarliestPosiƟveOrderTestType = c.Select(d => d.OrderTestType).FirstOrDefault(),

                                        OrderTestCount = c.Count()

                                    })
                                    .OrderByDescending(e => e.OrderTestCount).ToList();

                var b = JsonConvert.SerializeObject(mod);
                List<Case> cases = JsonConvert.DeserializeObject<List<Case>>(b);

                return cases;
                
            }
            catch (Exception ex) 
            {
                List<Case> a = new List<Case>();
                return a;
            }
        }
        //Metodo, insert y update
        public async Task InsertCase(List<LaboratoryTest> modelo)
        {

            await _db.BulkMergeAsync(await GetAllCases(modelo), options =>
            {
                options.ColumnPrimaryKeyExpression = enti => enti.PatientId;
            });
        }


        
    }
}
