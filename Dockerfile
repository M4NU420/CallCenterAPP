# Etapa 1: build del proyecto
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copiar todo el proyecto
COPY . .

# Restaurar dependencias y compilar
RUN dotnet restore
RUN dotnet publish -c Release -o out

# Etapa 2: runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/out ./

# Exponer el puerto del backend
EXPOSE 8080

ENTRYPOINT ["dotnet", "CallCenterBackend.dll"]
