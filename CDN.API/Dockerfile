# Use Microsoft's official build .NET image.
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

# Set the working directory in the container
WORKDIR /source

# Copy csproj and restore as distinct layers
COPY *.csproj .
RUN dotnet restore

# Copy everything else and build app
COPY . .
RUN dotnet publish -c release -o /app --no-restore

# Final stage/image
FROM mcr.microsoft.com/dotnet/aspnet:6.0

# Set the working directory in the container
WORKDIR /app

# Copy the build app from the build stage
COPY --from=build /app .

# Open port 80 for the application.
EXPOSE 80

# Run the app
ENTRYPOINT ["dotnet", "CDN.API.dll"]
