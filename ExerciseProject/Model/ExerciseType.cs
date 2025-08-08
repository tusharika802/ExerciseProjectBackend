using System.ComponentModel.DataAnnotations;

namespace ExerciseProject.Model
{
    public class ExerciseType
    {
        public int ExerciseTypeId { get; set; }
        [Required]
        public string ExerciseTypeName { get; set; }

        public ICollection<ExerciseName> Exercises { get; set; }

    }
}
