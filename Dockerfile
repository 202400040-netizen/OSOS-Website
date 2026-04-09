FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app
COPY OSOS_Website/*.csproj ./OSOS_Website/
RUN dotnet restore OSOS_Website/OSOS_Website.csproj
COPY . .
RUN dotnet publish OSOS_Website/OSOS_Website.csproj -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/out .
EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080
ENTRYPOINT ["dotnet", "OSOS_Website.dll"]
