#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
# RUN dotnet dev-certs https
COPY ["CleanMovie.API/CleanMovie.API.csproj", "CleanMovie.API/"]
COPY ["CleanMovie.Application/CleanMovie.Application.csproj", "CleanMovie.Application/"]
COPY ["CleanMovie.Domain/CleanMovie.Domain.csproj", "CleanMovie.Domain/"]
COPY ["CleanMovie.Infrastructure/CleanMovie.Infrastructure.csproj", "CleanMovie.Infrastructure/"]
COPY ["CleanMovie.LogUtility/CleanMovie.LogUtility.csproj","CleanMovie.LogUtility/"]
RUN dotnet restore "CleanMovie.API/CleanMovie.API.csproj"
COPY . .
WORKDIR "/src/CleanMovie.API"
RUN dotnet build "CleanMovie.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CleanMovie.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
#COPY --from=publish /root/.dotnet/corefx/cryptography/x509stores/my/* /root/.dotnet/corefx/cryptography/x509stores/my/
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CleanMovie.API.dll"]