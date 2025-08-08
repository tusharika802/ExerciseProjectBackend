using ExerciseProject.Data;
using ExerciseProject.Model;
using ExerciseProject.Model.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExerciseProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SelectedExerciseController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SelectedExerciseController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSelectedExercises()
        {
            var data = await _context.SelectedExercises
                .Include(x => x.ExerciseName)
                .ThenInclude(x => x.ExerciseType)
                .ToListAsync();

            var result = data.Select(s => new
            {
                s.Id,
                s.ExerciseNameId,
                s.ExerciseName.ExerciseNamee,
                s.ExerciseName.ExerciseCode,
                s.ExerciseName.ExerciseTypeId,
                s.ExerciseName.ExerciseType.ExerciseTypeName
            });

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> PostSelectedExercise(SelectedExerciseDto dto)
        {
            var exerciseName = await _context.ExerciseNames
                .Include(en => en.ExerciseType)
                .FirstOrDefaultAsync(en => en.ExerciseNameId == dto.ExerciseNameId);

            if (exerciseName == null)
            {
                return NotFound($"ExerciseName with ID {dto.ExerciseNameId} not found.");
            }

            var selected = new SelectedExercise
            {
                ExerciseNameId = exerciseName.ExerciseNameId,
                ExerciseName = exerciseName
            };

            _context.SelectedExercises.Add(selected);
            await _context.SaveChangesAsync();

            var responseDto = new SelectedExerciseDto
            {
                ExerciseNameId = exerciseName.ExerciseNameId,
                ExerciseNamee = exerciseName.ExerciseNamee,
                ExerciseCode = exerciseName.ExerciseCode,
                ExerciseTypeId = exerciseName.ExerciseTypeId,
                ExerciseTypeName = exerciseName.ExerciseType?.ExerciseTypeName
            };

            return Ok(new
            {
                Message = "SelectedExercise saved successfully.",
                SelectedExerciseId = selected.Id,
                ExerciseDetails = responseDto
            });
        }
    }
}
