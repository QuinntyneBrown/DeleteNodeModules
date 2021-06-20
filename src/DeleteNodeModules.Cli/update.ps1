dotnet tool uninstall -g DeleteNodeModules.Cli
dotnet pack
dotnet tool install --global --add-source ./nupkg DeleteNodeModules.Cli