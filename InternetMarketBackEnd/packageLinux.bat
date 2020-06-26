set version=0.1
dotnet clean
dotnet restore
dotnet msbuild InternetMarketBackEnd.csproj /p:Version=%version% /p:AssemblyVersion=%version%
dotnet msbuild InternetMarketBackEnd.csproj /t:PackageRpm /p:Version=%version% /p:AssemblyVersion=%version%