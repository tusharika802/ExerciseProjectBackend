using ExerciseProject.Model;
using Microsoft.EntityFrameworkCore;

namespace ExerciseProject.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        public DbSet <ExerciseName> ExerciseNames { get; set; }
        public DbSet<ExerciseType> ExerciseTypes { get; set; }
        public DbSet<SelectedExercise> SelectedExercises { get; set; }


    }
}