FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/VagProd.WebApi/VagProd.WebApi.csproj", "src/VagProd.WebApi/"]
COPY ["src/MagProduct.Core/MagProduct.Core.csproj", "src/MagProduct.Core/"]
COPY ["src/MagShared/MagShared.csproj", "src/MagShared/"]
COPY ["src/MagProduct.Application/MagProduct.Application.csproj", "src/MagProduct.Application/"]
COPY ["src/MagProd.Infrastructure/MagProd.Infrastructure.csproj", "src/MagProd.Infrastructure/"]
RUN dotnet restore "src/VagProd.WebApi/VagProd.WebApi.csproj"
COPY . .
WORKDIR "/src/src/VagProd.WebApi"
RUN dotnet build "./VagProd.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./VagProd.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "VagProd.WebApi.dll"]
