# PokeShake API

PokeShake is an ASP.NET Core Web API that fetches Pokémon flavor text (from https://pokeapi.co/) and translates it into Shakespearean English (using https://funtranslations.com/api/shakespeare)

---

## Features
- Fetch First English Pokémon flavor text description  
- Translates it into Shakespeare-style English

---

## Getting Started

### Prerequisites
- [.NET 9 SDK](https://dotnet.microsoft.com/en-us/download)
- [Docker](https://www.docker.com/) (optional, for containerized run)

---

## Quick Start (do this first)
Clone the repository and enter the folder:

```bash
git clone https://github.com/Mariabroe/PokeShakeApi.git
cd PokeShakeApi
```

___

### Run locally (without Docker)

```bash
dotnet restore
dotnet build
dotnet run --project src/PokeShakeApi
```

The API will start on: <http://localhost:5000/swagger>


___

## Run with Docker

```bash
docker build -t pokeshakeapi .

docker run -p 5050:8080 pokeshakeapi

```
Open http://localhost:5050/swagger to explore the API.

___

## Project structure

<pre>
PokeShakeApi
├── src
│   └── PokeShakeApi          # Main Web API
│       ├── Controllers
│       ├── DTO
│       ├── Helpers
│       ├── Models
│       ├── Services
│       ├── GlobalUsings.cs
│       └── Program.cs
├── tests
│   └── PokeShakeApi.Tests    # Unit tests (xUnit)
├── Dockerfile
├── .dockerignore
└── PokeShakeApi.sln
</pre>

___

## Run test

To run all tests (in this case I only have that one)

```bash
dotnet test
```







