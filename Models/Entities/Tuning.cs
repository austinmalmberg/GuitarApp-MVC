using System.ComponentModel.DataAnnotations;

namespace GuitarApp.Models.Entities
{
    public class Tuning
    {
        [Key]
        public int TuningID { get; set; }

        [Required]
        public string BaseTuning { get; set; }
    }
}