FROM mcr.microsoft.com/dotnet/core/runtime:3.1 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY ["Counter/Counter.csproj", "Counter/"]
RUN dotnet restore "Counter/Counter.csproj"
COPY . .
WORKDIR "/src/Counter"
RUN dotnet build "Counter.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Counter.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Counter.dll"]