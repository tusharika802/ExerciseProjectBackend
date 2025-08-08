using ExerciseProject.Data;
using ExerciseProject.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExerciseProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExerciseTypeController : ControllerBase

    {
        private readonly ApplicationDbContext _context;
        public ExerciseTypeController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<ExerciseTypeDto>>> GetExerciseTypes()
        {
            var result = await _context.ExerciseTypes
                .Include(et => et.Exercises)
                .Select(et => new ExerciseTypeDto
                {
                    ExerciseTypeId = et.ExerciseTypeId,
                    ExerciseTypeName = et.ExerciseTypeName,
                    Exercises = et.Exercises.Select(e => new ExerciseNameDto
                    {
                        ExerciseNameId = e.ExerciseNameId,
                        ExerciseNamee = e.ExerciseNamee,
                        ExerciseCode = e.ExerciseCode,
                        IsActive = e.IsActive,
                        ExerciseTypeId = e.ExerciseTypeId,
                        ExerciseTypeName = et.ExerciseTypeName,
                        DateAdded = e.DateAdded
                    }).ToList()
                })
                .ToListAsync();

            return Ok(result);
        }


    }



}
