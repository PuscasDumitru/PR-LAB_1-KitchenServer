

FROM mcr.microsoft.com/dotnet/core/runtime:3.1 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY ["Kitchen/Kitchen.csproj", "Kitchen/"]
RUN dotnet restore "Kitchen/Kitchen.csproj"
COPY . .
WORKDIR "/src/Kitchen"
RUN dotnet build "Kitchen.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Kitchen.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
EXPOSE 8000
ENTRYPOINT ["dotnet", "Kitchen.dll"]