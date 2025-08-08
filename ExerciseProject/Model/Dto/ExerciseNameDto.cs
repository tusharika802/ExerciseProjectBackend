using System.ComponentModel.DataAnnotations;

namespace ExerciseProject.DTOs
{
    public class ExerciseNameDto
    {
        public int ExerciseNameId { get; set; }
        [Required(ErrorMessage = "Exercise Name is required")]
        public string ExerciseNamee { get; set; }

        [Required(ErrorMessage = "Exercise Code is required")]
        [Range(1000, 9999, ErrorMessage = "Exercise Code must be a 4-digit number")]
        public long ExerciseCode { get; set; }

        public bool IsActive { get; set; } = true;

        [Required(ErrorMessage = "Exercise Type ID is required")]
        public int ExerciseTypeId { get; set; }
        public string ExerciseTypeName { get; set; }

        [Required(ErrorMessage = "Date Added is required")]
        [DataType(DataType.Date)]
        public DateTime DateAdded { get; set; }

    }
}
