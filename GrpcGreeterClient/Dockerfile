FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["GrpcGreeterClient/GrpcGreeterClient.csproj", "GrpcGreeterClient/"]
RUN dotnet restore "GrpcGreeterClient/GrpcGreeterClient.csproj"
COPY . .
WORKDIR "/src/GrpcGreeterClient"
RUN dotnet build "GrpcGreeterClient.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GrpcGreeterClient.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GrpcGreeterClient.dll"]
