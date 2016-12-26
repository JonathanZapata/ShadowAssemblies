using Nancy;
using Nancy.Hosting.Self;
using System;

namespace NancyShadowAssemblies.Implementation
{
    [Serializable]
    public class ServicioManual
    {
        public void ArracarServicio()
        {
            HostConfiguration hostConfigs = new HostConfiguration();
            hostConfigs.UrlReservations.CreateAutomatically = true;
            using (var host = new NancyHost(new Uri("http://localhost:12345"), new DefaultNancyBootstrapper(), hostConfigs))
            {
                host.Start();

                Console.WriteLine("Now listening, have fun!");

                Console.ReadLine();
            }
        }
    }
}
