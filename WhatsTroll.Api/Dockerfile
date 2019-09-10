FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["WhatsTroll.Api/WhatsTroll.Api.csproj", "WhatsTroll.Api/"]
COPY ["FirebaseApi/WhatsTroll.Firebase.csproj", "FirebaseApi/"]
COPY ["WhatsTroll.Data/WhatsTroll.Data.csproj", "WhatsTroll.Data/"]
COPY ["WhatsTroll.Payment/WhatsTroll.Payment.csproj", "WhatsTroll.Payment/"]
RUN dotnet restore "WhatsTroll.Api/WhatsTroll.Api.csproj"
COPY . .
WORKDIR "/src/WhatsTroll.Api"
RUN dotnet build "WhatsTroll.Api.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "WhatsTroll.Api.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "WhatsTroll.Api.dll"]