public class ExerciseOptionDto
{
    public int ExerciseNameId { get; set; }
    public string ExerciseNamee { get; set; }
    public long ExerciseCode { get; set; }
    public int ExerciseTypeId { get; set; }
    public string ExerciseTypeName { get; set; }  
    public string DisplayText => $"{ExerciseCode} - {ExerciseNamee}";
}
