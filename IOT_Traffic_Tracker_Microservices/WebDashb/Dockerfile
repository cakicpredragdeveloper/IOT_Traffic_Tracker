#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
RUN apt-get update -yq \
    && apt-get install curl gnupg -yq \
    && curl -sL https://deb.nodesource.com/setup_10.x | bash \
    && apt-get install nodejs -yq
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["WebDashb/WebDashb.csproj", "WebDashb/"]
RUN dotnet restore "WebDashb/WebDashb.csproj"
COPY . .
WORKDIR "/src/WebDashb"
RUN dotnet build "WebDashb.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WebDashb.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebDashb.dll"]