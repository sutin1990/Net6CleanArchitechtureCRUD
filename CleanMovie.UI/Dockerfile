#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
RUN dotnet dev-certs https
COPY ["CleanMovie.UI/CleanMovie.UI.csproj", "CleanMovie.UI/"]
COPY ["CleanMovie.Domain/CleanMovie.Domain.csproj", "CleanMovie.Domain/"]
RUN dotnet restore "CleanMovie.UI/CleanMovie.UI.csproj"
COPY . .
WORKDIR "/src/CleanMovie.UI"
RUN dotnet build "CleanMovie.UI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CleanMovie.UI.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /root/.dotnet/corefx/cryptography/x509stores/my/* /root/.dotnet/corefx/cryptography/x509stores/my/
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CleanMovie.UI.dll"]