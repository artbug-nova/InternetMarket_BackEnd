set Version=1
dotnet clean
dotnet restore
dotnet msbuild InternetMarket.csproj /p:Version=%version% /p:AssemblyVersion=%version%
dotnet msbuild InternetMarket.csproj /t:PackageRpm /p:Version=%version% /p:AssemblyVersion=%version%