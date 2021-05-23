#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["src/services/FVI.Funcionarios.API/FVI.Funcionarios.API.csproj", "src/services/FVI.Funcionarios.API/"]
RUN dotnet restore "src/services/FVI.Funcionarios.API/FVI.Funcionarios.API.csproj"
COPY . .
WORKDIR "/src/src/services/FVI.Funcionarios.API"
RUN dotnet build "FVI.Funcionarios.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FVI.Funcionarios.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FVI.Funcionarios.API.dll"]