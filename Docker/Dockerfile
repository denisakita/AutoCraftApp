FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

COPY . .
RUN dotnet restore

RUN dotnet build  "presentation/presentation.csproj" -c Release

FROM build AS publish
WORKDIR /app/presentation
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=publish /app/presentation/out ./
EXPOSE 8080
EXPOSE 8081
ENTRYPOINT ["dotnet", "presentation.dll"]