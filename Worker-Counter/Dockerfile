#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/runtime:3.1-buster-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Worker-Counter/Worker-Counter.csproj", "Worker-Counter/"]
RUN dotnet restore "Worker-Counter/Worker-Counter.csproj"
COPY . .
WORKDIR "/src/Worker-Counter"
RUN dotnet build "Worker-Counter.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Worker-Counter.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Worker-Counter.dll"]