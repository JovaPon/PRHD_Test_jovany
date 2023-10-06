using System.ComponentModel.DataAnnotations;
namespace PRHD_FULL.Modelos.Dto
{
    public class SampleCDateDto
    {
        [Required]
        public DateTime Samplecollectetdate { get; set; }
        public int Totalcases { get; set; }
        public int TotalcasesAntigens { get; set; }
        public int TotalcasesMolecular { get; set; }
    }
}
