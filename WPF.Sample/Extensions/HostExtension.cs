using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace WPF.Sample.Extensions
{
    public static class HostExtension
    {
        public static void WriteFatalLog(this IHost host, Exception? e = null, string messageTemplate = "")
        {
            host.Services.GetRequiredService<ILogger>().Fatal(e, messageTemplate);
        }
    }
}
