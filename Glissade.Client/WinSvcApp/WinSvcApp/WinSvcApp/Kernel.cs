using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;
using System.Reflection;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace WinSvcApp {
   public class Kernel {
        public static int Initialize(string[] args) {
            int exitCode = -1;
            if (Environment.UserInteractive) {
                if (args.Length == 0) {
                    var service = new WinService();
                    service.StartInternal();
                    Console.ReadKey();
                    service.StopInternal();
                    Console.ReadKey();
                    exitCode = 0;
                } else {
                    string arg = args[0].ToLowerInvariant();

                    switch (arg) {
                        case "i":
                        case "/i":
                        case "-i":
                            exitCode = InstallSvc();
                            break;
                        case "u":
                        case "/u":
                        case "-u":
                            exitCode = UninstallSvc();
                            break;
                        default:
                            exitCode = 1;
                            break;
                    }
                }
            } else {
                ServiceBase.Run(new WinService());
                exitCode = 0;
            }

            return exitCode;
        }

        private static int InstallSvc() {
            try {
                ManagedInstallerClass.InstallHelper(new[] { Assembly.GetExecutingAssembly().Location });
            } catch (Exception ex) {
                if (ex.InnerException != null && ex.InnerException.GetType() == typeof(Win32Exception)) {
                    var wex = (Win32Exception)ex.InnerException;
                    Console.WriteLine(@"Error(0x{0:X}): Service already installed!", wex.ErrorCode);
                    return wex.ErrorCode;
                }

                Console.WriteLine(ex.ToString());
                return -1;
            }

            return 0;
        }

        private static int UninstallSvc() {
            try {
                ManagedInstallerClass.InstallHelper(new[] { "/u", Assembly.GetExecutingAssembly().Location });
            } catch (Exception ex) {
                if (ex.InnerException != null && ex.InnerException.GetType() == typeof(Win32Exception)) {
                    var wex = (Win32Exception)ex.InnerException;
                    Console.WriteLine(@"Error(0x{0:X}): Service not installed!", wex.ErrorCode);
                    return wex.ErrorCode;
                }

                Console.WriteLine(ex.ToString());
                return -1;
            }

            return 0;
        }
    }
}
