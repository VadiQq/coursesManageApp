using CoursesManageApp.Shared.Enums;
using System;

namespace CoursesManageApp.Database.Data
{
    public partial class CourseTime
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public CourseDay CourseDay { get; set; }
        public virtual Course Course { get; set; }
    }
}
