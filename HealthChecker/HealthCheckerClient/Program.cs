namespace HealthCheckerClient
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Grpc.Health.V1;
    using Grpc.Net.Client;
    using global::Grpc.Core;

    class Program
    {
        static async Task Main(string[] args)
        {
            AppContext.SetSwitch(
                "System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);

            Channel channel = new Channel("healthchecker:5000",
                                          ChannelCredentials.Insecure);

            Health.HealthClient client = new Health.HealthClient(channel);

            while (true)
            {
                try
                {
                    var watch = System.Diagnostics.Stopwatch.StartNew();

                    HealthCheckResponse response = await client.CheckAsync(new HealthCheckRequest()
                    {
                        Service = "healthchecker"
                    });

                    watch.Stop();
                    Console.WriteLine("gRPC call to Healthchecker Server took " + watch.ElapsedMilliseconds + "ms");

                    response.Status.ToString();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message + " " + ex.StackTrace);
                }

                System.Threading.Thread.Sleep(1000);
            }
        }
    }
}
