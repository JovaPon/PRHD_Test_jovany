using Newtonsoft.Json;
using PRHD_FULL.Data;
using PRHD_FULL.Modelos;
using PRHD_FULL.Modelos.Dto;
using PRHD_FULL.Repository.IRepository;
using PRHD_Lib;
using System.Linq.Expressions;

namespace PRHD_FULL.Repository
{
    public class LaboratoryTestRepositorio : Repositorio<LaboratoryTest>, ILaboratoryTestRepositorio
    {
        private readonly ApplicationDbContext _db;

        public LaboratoryTestRepositorio(ApplicationDbContext db) :base(db)
        {
            _db = db;
        }

        //Metodo, actualiza e inserta la informacion a la tabla LaboratoryTest
        public async Task Insert(List<LaboratoryTest> entidad)
        {
            //await _db.BulkInsertAsync(entidad.ToList());

            await _db.BulkInsertAsync(entidad.ToList(), options =>
            {
                options.InsertIfNotExists = true;
                options.ColumnPrimaryKeyExpression = enti => enti.OrderTestId;
            });

            //await dbSet.AddAsync(entidad);

            //await Grabar();

        }
        //Metodo, realiza la logica para la comunicacion con el front end
        public async Task<List<SampleCDateDto>> GetSampleCases(Expression<Func<LaboratoryTest, bool>>? filtro = null)
        {
            try
            {

               var modelo = await ObtenerTodos();

                var mod = modelo.Where(x => DS.Fpositive.Contains(x.OrderTestResult))
                                .GroupBy(n => new { n.SampleCollectedDate })
                                    .Select(c => new
                                    {

                                        Samplecollectetdate = c.Key.SampleCollectedDate,

                                        TotalcasesMolecular = c.Where(z => z.OrderTestType == DS.TypeM).Count(),

                                        TotalcasesAntigens = c.Where(z => z.OrderTestType == DS.TypeA).Count(),

                                        Totalcases = c.Count()

                                    })
                                    .OrderByDescending(e => e.Samplecollectetdate).ToList();

                var b = JsonConvert.SerializeObject(mod);
                List<SampleCDateDto> cases = JsonConvert.DeserializeObject<List<SampleCDateDto>>(b);

                return cases;

            }
            catch (Exception ex)
            {
                List<SampleCDateDto> a = new List<SampleCDateDto>();
                return a;
            }
        }
    }
}
