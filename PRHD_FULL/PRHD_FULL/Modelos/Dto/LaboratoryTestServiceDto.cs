using System.ComponentModel.DataAnnotations;

namespace PRHD_FULL.Modelos.Dto
{
    public class LaboratoryTestServiceDto
    {
        [Required]
        public string orderTestId { get; set; }
        [Required]
        public string patientId { get; set; }
        [Required]
        public string patientAgeRange { get; set; }
        [Required]
        public string patientSex { get; set; }
        [Required]
        public string patientRegion { get; set; }
        [Required]
        public string patientCity { get; set; }
        [Required]
        public string orderTestCategory { get; set; }
        [Required]

        public string orderTestType { get; set; }
        [Required]
        public DateTime sampleCollectedDate { get; set; }
        [Required]
        public DateTime resultReportDate { get; set; }
        [Required]
        public string orderTestResult { get; set; }
        [Required]

        public DateTime orderTestCreatedAt { get; set; }

 

    }
}
