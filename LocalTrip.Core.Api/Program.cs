using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;

namespace LocalTrip.Core.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //CreateHostBuilder(args).Build().Run();
            CurrentDirectoryHelpers.SetCurrentDirectory();

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .MinimumLevel.Override("Serilog", LogEventLevel.Information)
                .WriteTo.File("Logs/LogFrom_ProgramMain.txt")
                .CreateLogger();
            try
            {
                CreateWebHostBuilder(args).Build().Run();
                
                Log.Logger.Information("Information:blabla");
            }
            catch (Exception ex)
            {
                Log.Logger.Error("Main handled an exception: " + ex.Message);
               
            }
        }
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseKestrel(o => {
                    o.Limits.KeepAliveTimeout = TimeSpan.FromMinutes(30);
                });
        
        /*
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });*/
    }
    internal class CurrentDirectoryHelpers
        {
            internal const string AspNetCoreModuleDll = "aspnetcorev2_inprocess.dll";
    
            [System.Runtime.InteropServices.DllImport("kernel32.dll")]
            private static extern IntPtr GetModuleHandle(string lpModuleName);
    
            [System.Runtime.InteropServices.DllImport(AspNetCoreModuleDll)]
            private static extern int http_get_application_properties(ref IISConfigurationData iiConfigData);
    
            [System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential)]
            private struct IISConfigurationData
            {
                public IntPtr pNativeApplication;
                [System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.BStr)]
                public string pwzFullApplicationPath;
                [System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.BStr)]
                public string pwzVirtualApplicationPath;
                public bool fWindowsAuthEnabled;
                public bool fBasicAuthEnabled;
                public bool fAnonymousAuthEnable;
            }
    
            public static void SetCurrentDirectory()
            {
                try
                {
                    // Check if physical path was provided by ANCM
                    var sitePhysicalPath = Environment.GetEnvironmentVariable("ASPNETCORE_IIS_PHYSICAL_PATH");
                    if (string.IsNullOrEmpty(sitePhysicalPath))
                    {
                        // Skip if not running ANCM InProcess
                        if (GetModuleHandle(AspNetCoreModuleDll) == IntPtr.Zero)
                        {
                            return;
                        }
    
                        IISConfigurationData configurationData = default(IISConfigurationData);
                        if (http_get_application_properties(ref configurationData) != 0)
                        {
                            return;
                        }
    
                        sitePhysicalPath = configurationData.pwzFullApplicationPath;
                    }
    
                    Environment.CurrentDirectory = sitePhysicalPath;
                }
                catch
                {
                    // ignore
                }
            }
        }
}