FROM microsoft/aspnetcore-build:2.0 AS build-env

# DAVID - Configuration du proxy
ENV http_proxy "http://10.0.2.2:82/"
ENV https_proxy "https://10.0.2.2:82/"

# Set the working directory to /app
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY src/. ./
RUN dotnet restore

# build
RUN dotnet publish -c Release -o out

# Build runtime image
FROM microsoft/aspnetcore:2.0
WORKDIR /app
COPY --from=build-env /app/web/out .

ENV ASPNETCORE_URLS http://+:5000
EXPOSE 5000

ENTRYPOINT ["dotnet", "web.dll"]
