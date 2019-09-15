FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["Hotsapp.Api/Hotsapp.Api.csproj", "Hotsapp.Api/"]
COPY ["FirebaseApi/Hotsapp.Firebase.csproj", "FirebaseApi/"]
COPY ["Hotsapp.Data/Hotsapp.Data.csproj", "Hotsapp.Data/"]
COPY ["Hotsapp.Payment/Hotsapp.Payment.csproj", "Hotsapp.Payment/"]
RUN dotnet restore "Hotsapp.Api/Hotsapp.Api.csproj"
COPY . .
WORKDIR "/src/Hotsapp.Api"
RUN dotnet build "Hotsapp.Api.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Hotsapp.Api.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Hotsapp.Api.dll"]