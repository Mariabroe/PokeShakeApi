# Stage 1: build
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# copy csproj and restore
COPY src/PokeShakeApi/PokeShakeApi.csproj src/PokeShakeApi/
RUN dotnet restore src/PokeShakeApi/PokeShakeApi.csproj

# copy everything else
COPY . .

# publish
RUN dotnet publish src/PokeShakeApi/PokeShakeApi.csproj -c Release -o /app/publish

# Stage 2: runtime
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "PokeShakeApi.dll"]
