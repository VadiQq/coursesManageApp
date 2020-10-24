using System.Threading.Tasks;
using CoursesManageApp.Database.Data;

namespace CoursesManageApp.Abstractions.Services.Interfaces
{
    public interface ICoursesService
    {
        Task CreateCourse(Course course);
        Task<bool> DeleteCourse(int id);
        Task<bool> EditCourse(Course updatedCourse);
        Task<Course> GetCourseById(int id);
        Task<Course[]> GetCourses();
    }
}