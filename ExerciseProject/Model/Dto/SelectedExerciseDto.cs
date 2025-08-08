using System.ComponentModel.DataAnnotations;

namespace ExerciseProject.Model.Dto
{
    public class SelectedExerciseDto
    {
        public int ExerciseNameId { get; set; }
        public string ExerciseNamee { get; set; }

        [Required(ErrorMessage = "Exercise Code is required")]
        [Range(1000, 9999, ErrorMessage = "Exercise Code must be a 4-digit number")]
        public long ExerciseCode { get; set; }
        public int ExerciseTypeId { get; set; }
        public string ExerciseTypeName { get; set; }
    }
}
