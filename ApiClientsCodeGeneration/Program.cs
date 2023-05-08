using SpaceApp.Dev.ApiToMobile.Converters.Android;
using SpaceApp.Dev.ApiToMobile.Settings;
using Microsoft.Extensions.Logging;
using SpaceApp.Dev.ApiToMobile;
using System.Diagnostics;
using Myffin.API.Responses;
using Myffin.API.Versioning;

namespace CodeGeneration.ApiClientsCodeGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            var outputDirectory = "output";
            if (Directory.Exists(outputDirectory))
            {
                try
                {
                    Directory.Delete(outputDirectory, true);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Невозможно очистить директорию {outputDirectory}: {ex}");
                }
            }
            using var loggerFactory =
              LoggerFactory.Create(builder => builder.AddConsole().SetMinimumLevel(LogLevel.Debug));
            new CodeGenerator(loggerFactory.CreateLogger<Program>()).Generate(new GeneratorSettings
            {
                Assembly = typeof(OperationStatus).Assembly,
                OutputDirectory = outputDirectory,
                DebugApiUrl = $"http://localhost/myffin.api/v{ApiVersionRangeAttribute.CurrentApiVersion}/",
                ReleaseApiUrl = $"http://localhost/myffin.api/v{ApiVersionRangeAttribute.CurrentApiVersion}/",
                AndroidPackage = new AndroidPackage("ru.myffin.experience.sal"),
                AndroidTrailingApiClientsPackage = new AndroidPackage("apiclients"),
                AndroidTrailingEnumsPackage = new AndroidPackage("enums"),
                IosApiClientsFolder = "ApiClients",
                IosEnumsFolder = "Enums",
                FlutterApiClientsFolder = "api_clients",
                FlutterEnumsFolder = "enums",
                FlutterPackageName = "sal",
                ApiClientMethodTypes = ApiClientMethodType.All
            });

            var pathToNewFiles = Path.Combine(outputDirectory, "Flutter");
            const string destinationPath = "D:\\Android\\Myffin.Experience.Flutter\\packages\\sal";

            var filesToRestore = new List<string> { "lib\\src\\api_clients\\network\\base_api_network_client.dart" };
            var filesToRestoreData = new Dictionary<string, string>();
            foreach (var relativePath in filesToRestore)
            {
                var fullPath = Path.Combine(destinationPath, relativePath);
                if (File.Exists(fullPath))
                {
                    filesToRestoreData[fullPath] = File.ReadAllText(fullPath);
                }
            }

            if (Directory.Exists(Path.Combine(destinationPath, "lib")))
            {
                Directory.Delete(Path.Combine(destinationPath, "lib"), true);
            }
            if (File.Exists(Path.Combine(destinationPath, "build.yaml")))
            {
                File.Delete(Path.Combine(destinationPath, "build.yaml"));
            }

            Directory.Move(Path.Combine(pathToNewFiles, "lib"), Path.Combine(destinationPath, "lib"));
            File.Move(Path.Combine(pathToNewFiles, "build.yaml"), Path.Combine(destinationPath, "build.yaml"));

            foreach (var fileData in filesToRestoreData)
            {
                File.WriteAllText(fileData.Key, fileData.Value);
            }

            Process.Start("explorer.exe", outputDirectory);
        }
    }
}