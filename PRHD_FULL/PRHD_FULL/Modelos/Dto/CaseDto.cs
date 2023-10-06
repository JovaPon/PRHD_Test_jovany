using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PRHD_FULL.Modelos.Dto
{
    public class CaseDto
    {
       

        [Required]
        public string PatientId { get; set; }
        [Required]
        public DateTime EarliestPosiƟveOrderTestSampleCollectedDate { get; set; }
        [Required]
        public string EarliestPosiƟveOrderTestType { get; set; }

        [Required]
        public int OrderTestCount { get; set; }
    }
}
