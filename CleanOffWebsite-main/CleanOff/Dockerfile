FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["CleanOffWebsite/CleanOff/CleanOff.csproj", "CleanOffWebsite/CleanOff/"]
RUN dotnet restore "CleanOff/CleanOff.csproj"
COPY . .
WORKDIR "/src/CleanOff"
RUN dotnet build "CleanOff.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CleanOff.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CleanOff.dll"]
