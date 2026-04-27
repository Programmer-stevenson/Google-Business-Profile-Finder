# Build Stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /source

# Copy everything
COPY . .

# Explicitly restore and publish the specific project
RUN dotnet restore LeadHunterUI.csproj
RUN dotnet publish LeadHunterUI.csproj -c Release -o /app

# Run Stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app ./

# Permissions for SQLite
USER root
RUN chmod -R 777 /app

# Render Dynamic Port Binding
ENV ASPNETCORE_URLS=http://0.0.0.0:8080
EXPOSE 8080

ENTRYPOINT ["dotnet", "LeadHunterUI.dll"]
