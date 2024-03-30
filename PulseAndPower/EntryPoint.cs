using Vostok.Hosting;
using Vostok.Hosting.Setup;

namespace PulseAndPower;

public static class EntryPoint
{
    public static async Task Main()
    {
        var application = new PulseAndPowerApplication();
        var hostSettings = new VostokHostSettings(application, EnvironmentSetup);

        var host = new VostokHost(hostSettings);

        await host.WithConsoleCancellation().RunAsync();
    }

    private static void EnvironmentSetup(IVostokHostingEnvironmentBuilder builder)
    {
        builder
            .SetupApplicationIdentity(identityBuilder => identityBuilder
                .SetProject("PulseAndPower")
                .SetApplication("Api")
                .SetEnvironment("default")
                .SetInstance("single"))
            .DisableClusterConfig()
            .DisableHercules()
            .SetupLog(logBuilder => logBuilder.SetupConsoleLog())
            .SetPort(8888);
    }
}