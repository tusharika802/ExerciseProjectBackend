using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExerciseProject.Model
{
    public class SelectedExercise
    {

        public int Id { get; set; }
        public int ExerciseNameId { get; set; }

        [ForeignKey(nameof(ExerciseNameId))]
        public ExerciseName ExerciseName { get; set; }

    }
}
