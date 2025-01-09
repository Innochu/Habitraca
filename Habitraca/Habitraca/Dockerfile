# Base image to run the app
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

# Build image to compile and restore dependencies
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

# Copy the .csproj files into their respective folders (relative to the build context)
COPY ["Habitraca/Habitraca.csproj", "Habitraca/"]
COPY ["Habitraca/Habitraca.Common/Habitraca.Common.csproj", "Habitraca.Common/"]
COPY ["Habitraca/Habitraca.Persistence/Habitraca.Persistence.csproj", "Habitraca.Persistence/"]
COPY ["Habitraca/Habitraca.Application/Habitraca.Application.csproj", "Habitraca.Application/"]
COPY ["Habitraca/Habitraca.Domain/Habitraca.Domain.csproj", "Habitraca.Domain/"]

# Run dotnet restore to restore dependencies
RUN dotnet restore "Habitraca/Habitraca.csproj"

# Copy the rest of the source code into the container
COPY . .

# Set the working directory to the project directory
WORKDIR "/src/Habitraca"

# Build the project in Release mode
RUN dotnet build "Habitraca/Habitraca.csproj" -c Release -o /app/build

# Publish the app to a specific directory
FROM build AS publish
RUN dotnet publish "Habitraca/Habitraca.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Final image to run the app
FROM base AS final
WORKDIR /app

# Copy the published output from the build image
COPY --from=publish /app/publish .

# Set the entry point for the application
ENTRYPOINT ["dotnet", "Habitraca.dll"]
