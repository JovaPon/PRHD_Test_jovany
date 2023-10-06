using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PRHD_FULL.Modelos
{
    public class LaboratoryTest
    {

        [Required]
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string OrderTestId { get; set; }
        [Required]
        public string PatientId { get; set;}
        [Required]
        public string OrderTestType { get; set; }
        [Required]
        public DateTime SampleCollectedDate { get; set;}

        [Required]
        public string OrderTestResult{ get; set;}

    }
}
