using CoursesManageApp.Abstractions.Services.Base;
using CoursesManageApp.Abstractions.Services.Interfaces;
using CoursesManageApp.Database.Data;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CoursesManageApp.Implementation.Services
{
    public sealed class CoursesService : ServiceBase, ICoursesService
    {
        public CoursesService(CoursesDatabaseContext databaseContext) : base(databaseContext)
        {
        }

        public async Task<Course> GetCourseById(int id)
        {
            return await DbContext.Courses.Include(c => c.CourseTime).FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Course[]> GetCourses()
        {
            return await DbContext.Courses.Include(c => c.CourseTime).ToArrayAsync();
        }

        public async Task CreateCourse(Course course)
        {
            DbContext.Courses.Add(course);

            await DbContext.SaveChangesAsync();
        }

        public async Task<bool> EditCourse(Course updatedCourse)
        {
            var course = await DbContext.Courses.Include(c => c.CourseTime).FirstOrDefaultAsync(c => c.Id == updatedCourse.Id);

            if (course == null) return false;

            course.Cost = updatedCourse.Cost;
            course.Name = updatedCourse.Name;
            course.CourseTime.CourseDay = updatedCourse.CourseTime.CourseDay;
            course.CourseTime.StartTime = updatedCourse.CourseTime.StartTime;
            course.CourseTime.EndTime = updatedCourse.CourseTime.EndTime;

            await DbContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteCourse(int id)
        {
            var course = await DbContext.Courses.Include(c => c.CourseTime).FirstOrDefaultAsync(c => c.Id == id);

            if (course == null) return false;

            DbContext.Courses.Remove(course);

            await DbContext.SaveChangesAsync();

            return true;
        }
    }
}
