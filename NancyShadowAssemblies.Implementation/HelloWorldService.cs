using System;

using Nancy;

namespace NancyShadowAssemblies.Implementation {
    public class HelloWorldService : NancyModule {

        public HelloWorldService() {

            Get["/"] = x => {
                return Response.AsText( "Hello World" );
            };

        }

    }
}
