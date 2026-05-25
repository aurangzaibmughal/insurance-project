# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy csproj and restore dependencies
COPY InsuranceManagementSystem/*.csproj ./InsuranceManagementSystem/
RUN dotnet restore "./InsuranceManagementSystem/InsuranceManagementSystem.csproj"

# Copy everything else and build
COPY InsuranceManagementSystem/. ./InsuranceManagementSystem/
WORKDIR "/src/InsuranceManagementSystem"
RUN dotnet build "InsuranceManagementSystem.csproj" -c Release -o /app/build

# Publish stage
FROM build AS publish
RUN dotnet publish "InsuranceManagementSystem.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
EXPOSE 8080
COPY --from=publish /app/publish .

# Set environment variables for Railway
ENV ASPNETCORE_URLS=http://+:8080
ENV ASPNETCORE_ENVIRONMENT=Production

ENTRYPOINT ["dotnet", "InsuranceManagementSystem.dll"]
