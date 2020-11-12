FROM mcr.microsoft.com/dotnet/core/aspnet:2.1 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.1 AS build
WORKDIR /src
COPY ["UserProfile.API/UserProfile.API.csproj", "UserProfile.API/"]

RUN dotnet restore "UserProfile.API/UserProfile.API.csproj"
COPY . .
WORKDIR "/src/UserProfile.API"
RUN dotnet build "UserProfile.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "UserProfile.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "UserProfile.API.dll"]