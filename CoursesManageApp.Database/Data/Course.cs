namespace CoursesManageApp.Database.Data
{
    public partial class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Cost { get; set; }

        public virtual CourseTime CourseTime { get; set; }
    }
}
