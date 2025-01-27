using Microsoft.EntityFrameworkCore;

namespace my_tec_course.webapi.Contexts
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) :
        base(options)
        {

        }

        // add models here

    }
}
