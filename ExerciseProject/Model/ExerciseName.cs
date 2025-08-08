using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ExerciseProject.Model
{
    public class ExerciseName
    {
        public int ExerciseNameId { get; set; }
        public string ExerciseNamee { get; set; }
        public DateTime DateAdded { get; set; } = DateTime.Today;
        [Range(1000, 9999, ErrorMessage = "Exercise Number must be a 4-digit number")]

        public long ExerciseCode { get; set; }
        public bool IsActive { get; set; } = true;
        
        public int ExerciseTypeId { get; set; }

        [ForeignKey("ExerciseTypeId")]
     
        public ExerciseType? ExerciseType { get; set; }
    }
}

