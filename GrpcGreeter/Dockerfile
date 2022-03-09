FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["GrpcGreeter/GrpcGreeter.csproj", "GrpcGreeter/"]
RUN dotnet restore "GrpcGreeter/GrpcGreeter.csproj"
COPY . .
WORKDIR "/src/GrpcGreeter"
RUN dotnet build "GrpcGreeter.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GrpcGreeter.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GrpcGreeter.dll"]
