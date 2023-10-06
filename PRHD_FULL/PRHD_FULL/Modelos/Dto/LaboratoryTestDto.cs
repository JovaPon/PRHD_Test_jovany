using System.ComponentModel.DataAnnotations;

namespace PRHD_FULL.Modelos.Dto
{
    public class LaboratoryTestDto
    {
        [Required]
        public string OrderTestId { get; set; }
        [Required]
        public string PatientId { get; set; }
        [Required]
        public string OrderTestType { get; set; }
        [Required]
        public DateTime SampleCollectedDate { get; set; }

        [Required]
        public string OrderTestResult { get; set; }
    }
}
