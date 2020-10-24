using System;

namespace CoursesManageApp.Models
{
    public class CourseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Cost { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public string Day { get; set; }
    }
}
