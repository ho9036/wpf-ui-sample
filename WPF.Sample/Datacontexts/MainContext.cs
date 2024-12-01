using Microsoft.EntityFrameworkCore;

namespace WPF.Sample.Datacontexts
{
    public class MainContext(DbContextOptions<MainContext> options) : DbContext(options)
    {
    }
}
