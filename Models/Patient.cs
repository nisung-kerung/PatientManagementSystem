using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PatientManagementSystem.Models
{
    public class Patient
    {
        [Key]
        public string Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string City { get; set; }

        [Range(1, 120)]
        public int Age { get; set; }

        [Required]
        [RegularExpression("male|female|others", ErrorMessage = "Gender must be male, female, or others.")]
        public string Gender { get; set; }

        [Range(0.1, double.MaxValue)]
        public float Height { get; set; }

        [Range(0.1, double.MaxValue)]
        public float Weight { get; set; }

        [NotMapped]
        public float BMI => (float)Math.Round(Weight / (Height * Height), 2);

        [NotMapped]
        public string Verdict
        {
            get
            {
                if (BMI < 18.5) return "Underweight";
                if (BMI < 25) return "Normal";
                if (BMI < 30) return "Normal";
                return "Obese";
            }
        }
    }
}
