using System;
using System.Threading;

using Nancy;
using Nancy.Hosting.Self;

namespace NancyShadowAssemblies.Implementation {
    class Program {
        static void Main( string[] args ) {
            int contador = 3, cont = 1;
            HostConfiguration hostConfigs = new HostConfiguration();
            hostConfigs.UrlReservations.CreateAutomatically = true;
            using ( var host = new NancyHost(new Uri("http://localhost:12345"), new DefaultNancyBootstrapper(), hostConfigs) ) {
                host.Start();
                while (cont <= contador)
                {
                    Console.WriteLine("Now listening, have fun!");
                    cont++;
                    Thread.Sleep(5000);
                }
                
                Console.ReadLine();
            }
        }
    }
}
