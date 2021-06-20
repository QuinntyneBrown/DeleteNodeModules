using CommandLine;
using MediatR;
using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace DeleteNodeModules.Core
{
    internal class Default
    {
        [Verb("default")]
        internal class Request : IRequest<Unit>
        {
            [Option('d', Required = false)]
            public string Directory { get; set; } = System.Environment.CurrentDirectory;
        }

        internal class Handler : IRequestHandler<Request, Unit>
        {
            public async Task<Unit> Handle(Request request, CancellationToken cancellationToken)
            {
                try
                {
                    var arguments = "FOR /d /r . %d in (node_modules) DO @IF EXIST \"%d\" rimraf \"%d\"";

                    Console.WriteLine($"Directory: {request.Directory}");
                    Console.WriteLine("Running");
                    Console.WriteLine(arguments);

                    var process = new Process
                    {
                        StartInfo = new ProcessStartInfo
                        {
                            WindowStyle = ProcessWindowStyle.Normal,
                            FileName = "cmd.exe",
                            Arguments = $"/C {arguments}",
                            WorkingDirectory = request.Directory
                        }
                    };

                    process.Start();

                    process.WaitForExit();

                    Console.WriteLine("Done!");

                    return new();
                }
                catch (Exception e)
                {
                    Console.Write(e.Message);

                    throw e;
                }

            }
        }
    }
}
