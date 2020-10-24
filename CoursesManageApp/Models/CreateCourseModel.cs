using CoursesManageApp.Shared.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace CoursesManageApp.Models
{
    public class CreateCourseModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Cost { get; set; }
        [Required]
        public TimeSpan StartTime { get; set; }
        [Required]
        public TimeSpan EndTime { get; set; }
        [Required]
        public CourseDay CourseDay { get; set; }
    }
}
