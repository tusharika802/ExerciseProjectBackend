using ExerciseProject.DTOs;

public class ExerciseTypeDto
{
    public int ExerciseTypeId { get; set; }
    public string ExerciseTypeName { get; set; } = string.Empty;
    public List<ExerciseNameDto> Exercises { get; set; } = new();
}
