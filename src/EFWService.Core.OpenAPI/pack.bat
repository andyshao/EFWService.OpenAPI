echo 'start pack'
dotnet clean
dotnet restore
dotnet pack -c Release EFWService.Core.OpenAPI.csproj
pause