﻿FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["ApiMarketHub/src/EndPoints/MarketHub.Api/MarketHub.Api.csproj", "ApiMarketHub/src/EndPoints/MarketHub.Api/"]
RUN dotnet restore "ApiMarketHub/src/EndPoints/MarketHub.Api/MarketHub.Api.csproj"
COPY . .
WORKDIR "/src/ApiMarketHub/src/EndPoints/MarketHub.Api"
RUN dotnet build "MarketHub.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MarketHub.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MarketHub.Api.dll"]