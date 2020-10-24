using CoursesManageApp.Database.Data;

namespace CoursesManageApp.Abstractions.Services.Base
{
    public abstract class ServiceBase
    {
        protected CoursesDatabaseContext DbContext { get; private set; }

        public ServiceBase(CoursesDatabaseContext dbContext)
        {
            DbContext = dbContext;
        }
    }
}
