# syntax=docker/dockerfile:1
# FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
# WORKDIR /app

# # Copy csproj and restore as distinct layers
# COPY *.csproj ./
# RUN dotnet restore

# # Copy everything else and build
# COPY . .
# RUN dotnet publish -c Release -o out


# # Build runtime image
# FROM mcr.microsoft.com/dotnet/aspnet:6.0
# WORKDIR /app
# EXPOSE 80
# COPY --from=build-env /app/out .
# ENTRYPOINT ["dotnet", "CleanMovie.API.dll"]



# FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
# COPY *.csproj ./
# RUN dotnet restore "CleanMovie.API.csproj"
# COPY . .
# RUN dotnet build "CleanMovie.API.csproj" -c Release -o out


# RUN dotnet publish "CleanMovie.API.csproj" -c Release -o out


# FROM mcr.microsoft.com/dotnet/aspnet:6.0
# WORKDIR /app
# EXPOSE 80
# COPY --from=build-env /app/out .
# ENTRYPOINT ["dotnet", "CleanMovie.API.dll"]


FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

# Copy everything
COPY ["CleanMovie.API/CleanMovie.API.csproj","CleanMovie.API/"]
COPY ["CleanMovie.Application/CleanMovie.Application.csproj","CleanMovie.Application/"]
COPY ["CleanMovie.Domain/CleanMovie.Domain.csproj","CleanMovie.Domain/"]
COPY ["CleanMovie.Infrastructure/CleanMovie.Infrastructure.csproj","CleanMovie.Infrastructure/"]

# Restore as distinct layers
RUN dotnet restore "CleanMovie.API/CleanMovie.API.csproj"
# Build and publish a release
COPY . .
WORKDIR "/src/CleanMovie.API"
RUN dotnet build "CleanMovie.API.csproj" -c Release -o /app
# COPY CleanMovie.Application/. ./CleanMovie.Application/
# COPY CleanMovie.Domain/. ./CleanMovie.Domain/
# COPY CleanMovie.Infrastructure/. ./CleanMovie.Infrastructure/
FROM build AS publish
RUN dotnet publish "CleanMovie.API.csproj" -c Release -o /app

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime
WORKDIR /app
EXPOSE 80
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "CleanMovie.API.dll"]