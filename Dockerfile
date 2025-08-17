# Stage 1: build
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# copy csproj and restore
COPY src/PokeShakes.Api/PokeShakes.Api.csproj src/PokeShakes.Api/
RUN dotnet restore src/PokeShakes.Api/PokeShakes.Api.csproj

# copy everything else
COPY . .

# publish
RUN dotnet publish src/PokeShakes.Api/PokeShakes.Api.csproj -c Release -o /app/publish

# Stage 2: runtime
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "PokeShakes.Api.dll"]
