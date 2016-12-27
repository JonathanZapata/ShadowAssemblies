using System;
using System.Diagnostics;
using System.IO;
using System.Windows;

namespace NancyShadowAssemblies {
    class Program {
        private static AppDomain domain;

        static int Main( string[] args ) {
            //Para probar con el bloqueo del EXE
            //Process.Start(@"C:\Users\TOSHIBA\Source\Repos\ShadowAssemblies\NancyShadowAssemblies\bin\x86\Debug\NancyShadowAssemblies.Implementation.exe");
            //return 1;

            //Para probar sin el bloqueo del exe
            Console.WriteLine("Hola");
            var cachePath = Path.Combine(AppDomain.CurrentDomain.SetupInformation.ApplicationBase, "ShadowCopyCache");
            var pluginPath = Path.Combine(AppDomain.CurrentDomain.SetupInformation.ApplicationBase, "Plugins");
            if (!Directory.Exists(cachePath))
            {
                Directory.CreateDirectory(cachePath);
            }

            if (!Directory.Exists(pluginPath))
            {
                Directory.CreateDirectory(pluginPath);
            }
            int result = 0, cont = 1;

            AppDomainSetup setup = new AppDomainSetup
            {
                CachePath = cachePath,
                ShadowCopyFiles = "true", // This is key
                //ShadowCopyDirectories = pluginPath
            };

            while (cont <= 3)
            {
                domain = AppDomain.CreateDomain("Real AppDomain", null, setup);

                result = domain.ExecuteAssembly(
                "NancyShadowAssemblies.Implementation.exe",
                args
                );
                cont++;
            }

            Console.WriteLine("Ha finalizado");

            Console.WriteLine("Resultado: " + result);
            return result;
        }
    }
}
