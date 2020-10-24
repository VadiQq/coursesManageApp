using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CoursesManageApp.Models;
using CoursesManageApp.Database.Data;
using System.Linq;
using CoursesManageApp.Abstractions.Services.Interfaces;

namespace CoursesManageApp.Controllers
{

    public class CoursesController : Controller
    {
        private readonly ICoursesService _coursesService;

        public CoursesController(ICoursesService coursesService)
        {
            _coursesService = coursesService;
        }

        [HttpGet]
        public async Task<IActionResult> CoursesList()
        {
            var courses = await _coursesService.GetCourses();

            var coursesModel = courses.Select(course => new CourseModel
            {
                Id = course.Id,
                Name = course.Name,
                Cost = course.Cost,
                Day = course.CourseTime.CourseDay.ToString(),
                EndTime = course.CourseTime.EndTime,
                StartTime = course.CourseTime.StartTime
            }).ToArray();

            return View(courses);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCourseModel model)
        {
            var course = new Course
            {
                Cost = model.Cost,
                Name = model.Name,
                CourseTime = new CourseTime
                {
                    CourseDay = model.CourseDay,
                    StartTime = model.StartTime,
                    EndTime = model.EndTime
                }
            };

            await _coursesService.CreateCourse(course);

            return RedirectToAction("CoursesList");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var course = await _coursesService.GetCourseById(id);

            if (course == null) return BadRequest();

            return View(new EditCourseModel
            {
                Id = course.Id,
                Cost = course.Cost,
                Name = course.Name,
                CourseDay = course.CourseTime.CourseDay,
                EndTime = course.CourseTime.EndTime,
                StartTime = course.CourseTime.StartTime
            });
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditCourseModel model)
        {
            var updatedCourse = new Course
            {
                Cost = model.Cost,
                Name = model.Name,
                Id = model.Id,
                CourseTime = new CourseTime
                {
                    CourseDay = model.CourseDay,
                    StartTime = model.StartTime,
                    EndTime = model.EndTime
                }
            };

            var result = await _coursesService.EditCourse(updatedCourse);

            if (!result) return BadRequest();

            return RedirectToAction("CoursesList");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _coursesService.DeleteCourse(id);

            if (!result) return BadRequest();

            return RedirectToAction("CoursesList");
        }
    }
}
