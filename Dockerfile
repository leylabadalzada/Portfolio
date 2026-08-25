FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY ["Portfolio.Core/Portfolio.Core.csproj", "Portfolio.Core/"]
COPY ["Portfolio.Data/Portfolio.Data.csproj", "Portfolio.Data/"]
COPY ["Portfolio.Service/Portfolio.Service.csproj", "Portfolio.Service/"]
COPY ["Portfolio.Web/Portfolio.Web.csproj", "Portfolio.Web/"]

RUN dotnet restore "Portfolio.Web/Portfolio.Web.csproj"

COPY . .

RUN dotnet publish "Portfolio.Web/Portfolio.Web.csproj" -c Release -o /app/publish --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final

WORKDIR /app
COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "Portfolio.Web.dll"]