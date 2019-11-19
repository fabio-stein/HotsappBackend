FROM gcr.io/hotsapp/yowsup AS dev

FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
COPY --from=dev / /
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["Hotsapp.Connector/Hotsapp.Connector.csproj", "Hotsapp.Connector/"]
COPY ["Hotsapp.Data/Hotsapp.Data.csproj", "Hotsapp.Data/"]
RUN dotnet restore "Hotsapp.Connector/Hotsapp.Connector.csproj"
COPY . .
WORKDIR "/src/Hotsapp.Connector"
RUN dotnet build "Hotsapp.Connector.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Hotsapp.Connector.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
COPY --from=build /src/Assets /app/Assets

ENV LANG C.UTF-8
ENV LC_ALL C.UTF-8

ENTRYPOINT ["dotnet", "Hotsapp.Connector.dll"]