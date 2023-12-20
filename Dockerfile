# Build Stage
FROM mcr.microsoft.com/dotnet/sdk:8.0-alpine AS build
WORKDIR /source
COPY . . 

# Add the PostgreSQL connection string as an environment variable
ENV ConnectionStrings__Default "Server=172.17.0.2;Port=5432;Database=cinema;User Id=postgres;Password=Melon@123;"

RUN dotnet restore "FilmsAPI-V2.csproj" --disable-parallel
RUN dotnet publish "FilmsAPI-V2.csproj" -c release -o /app --no-restore

# Serve Stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0-alpine 
WORKDIR /app
COPY --from=build /app ./

EXPOSE 5000

ENTRYPOINT [ "dotnet", "FilmsAPI-V2.dll"]
