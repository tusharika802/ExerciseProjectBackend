using ExerciseProject.Data;
using ExerciseProject.DTOs;
using ExerciseProject.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExerciseProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExerciseNameController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ExerciseNameController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet("grouped")]
        public async Task<ActionResult<IEnumerable<ExerciseTypeGroupDto>>> GetGroupedExercises()
        {
            var groupedData = await _context.ExerciseNames
                .Include(e => e.ExerciseType)
                .GroupBy(e => new { e.ExerciseTypeId, e.ExerciseType.ExerciseTypeName })
                .Select(g => new ExerciseTypeGroupDto
                {
                    ExerciseTypeId = g.Key.ExerciseTypeId,
                    ExerciseTypeName = g.Key.ExerciseTypeName,
                    Exercises = g.Select(x => new ExerciseOptionDto
                    {
                        ExerciseNameId = x.ExerciseNameId,
                        ExerciseNamee = x.ExerciseNamee,
                        ExerciseCode = x.ExerciseCode,
                        ExerciseTypeId = x.ExerciseTypeId,
                        ExerciseTypeName = g.Key.ExerciseTypeName
                    }).ToList()
                })
                .ToListAsync();

            return Ok(groupedData);
        }




        [HttpGet]
        public async Task<ActionResult<IEnumerable<ExerciseNameDto>>> GetExerciseNames()
        {
            var exercises = await _context.ExerciseNames
                .Include(e => e.ExerciseType)
                .Select(e => new ExerciseNameDto
                {
                    ExerciseNameId = e.ExerciseNameId,
                    ExerciseNamee = e.ExerciseNamee,
                    ExerciseCode = e.ExerciseCode,
                    IsActive = e.IsActive,
                    ExerciseTypeId = e.ExerciseTypeId,
                    ExerciseTypeName = e.ExerciseType != null ? e.ExerciseType.ExerciseTypeName : "",
                    DateAdded = e.DateAdded,
                })
                .ToListAsync();

            return Ok(exercises);
        }

        [HttpPost]
        public async Task<IActionResult> CreateExerciseName([FromBody] ExerciseNameDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var exerciseTypeExists = await _context.ExerciseTypes.AnyAsync(et => et.ExerciseTypeId == dto.ExerciseTypeId);
            if (!exerciseTypeExists)
                return BadRequest($"ExerciseTypeId {dto.ExerciseTypeId} does not exist.");

            var exerciseName = new ExerciseName
            {
                ExerciseNameId = dto.ExerciseNameId,
                ExerciseNamee = dto.ExerciseNamee,
                ExerciseCode = dto.ExerciseCode,
                IsActive = dto.IsActive,
                ExerciseTypeId = dto.ExerciseTypeId, 
                DateAdded = DateTime.Today
            };

            _context.ExerciseNames.Add(exerciseName);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetExerciseNames), new { id = exerciseName.ExerciseNameId }, dto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateExerciseName(int id, [FromBody] ExerciseNameDto dto)
        {
            var existing = await _context.ExerciseNames.FindAsync(id);
            if (existing == null) return NotFound();

            var exerciseTypeExists = await _context.ExerciseTypes.AnyAsync(et => et.ExerciseTypeId == dto.ExerciseTypeId);
            if (!exerciseTypeExists)
                return BadRequest($"ExerciseTypeId {dto.ExerciseTypeId} does not exist.");

            existing.ExerciseNamee = dto.ExerciseNamee;
            existing.ExerciseCode = dto.ExerciseCode;
            existing.IsActive = dto.IsActive;
            existing.ExerciseTypeId = dto.ExerciseTypeId;
            existing.DateAdded = dto.DateAdded;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExerciseName(int id)
        {
            var exercise = await _context.ExerciseNames.FindAsync(id);
            if (exercise == null) return NotFound();

            _context.ExerciseNames.Remove(exercise);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
