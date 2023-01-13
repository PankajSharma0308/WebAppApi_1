#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["WebAppApi_1/WebAppApi_1.csproj", "WebAppApi_1/"]
RUN dotnet restore "WebAppApi_1/WebAppApi_1.csproj"
COPY . .
WORKDIR "/src/WebAppApi_1"
RUN dotnet build "WebAppApi_1.csproj" -c Release -o /app/build
# WORKDIR /app
CMD ["dotnet", "run", "--project", "../WebAppApi_1/"]


# FROM build AS publish
# RUN dotnet publish "WebAppApi_1.csproj" -c Release -o /app/publish /p:UseAppHost=false

# FROM base AS final
# WORKDIR /app
# COPY --from=publish /app/publish .
# ENTRYPOINT ["dotnet", "WebAppApi_1.dll"]
