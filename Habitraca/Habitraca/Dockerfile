

#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
#ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Habitraca/Habitraca/Habitraca.csproj", "Habitraca/"]
COPY ["Habitraca/Habitraca.Common/Habitraca.Common.csproj", "Habitraca.Common/"]
COPY ["Habitraca/Habitraca.Persistence/Habitraca.Persistence.csproj", "Habitraca.Persistence/"]
COPY ["Habitraca/Habitraca.Application/Habitraca.Application.csproj", "Habitraca.Application/"]
COPY ["Habitraca/Habitraca.Domain/Habitraca.Domain.csproj", "Habitraca.Domain/"]  
RUN dotnet restore "Habitraca/Habitraca/Habitraca.csproj"
COPY . .
WORKDIR "/src/Habitraca"
RUN dotnet build "Habitraca/Habitraca.csproj" -c Release -o /app/build

FROM build AS publish
#ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Habitraca/Habitraca.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Habitraca.dll"]