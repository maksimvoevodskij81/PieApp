# Build stage
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env
WORKDIR /PieApp
COPY . ./
RUN dotnet restore
RUN dotnet publish -c Release -o out

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /PieApp
COPY --from=build-env /PieApp/out .
ENTRYPOINT ["dotnet", "PieApp.dll"]
