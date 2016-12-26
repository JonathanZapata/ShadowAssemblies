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
            AppDomainSetup setup = new AppDomainSetup
            {
                ShadowCopyFiles = "true" // This is key
            };

            domain = AppDomain.CreateDomain("Real AppDomain", null, setup);

            // Execute your real application in the new app domain
            int result = domain.ExecuteAssembly(
                "NancyShadowAssemblies.Implementation.exe",
                args
            );

            Console.WriteLine("Ha finalizado");

            Console.WriteLine("Resultado: " + result);
            return result;
        }
    }
}
