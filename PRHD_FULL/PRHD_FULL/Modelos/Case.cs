using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PRHD_FULL.Modelos
{
    public class Case
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CaseId { get; set; }

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
