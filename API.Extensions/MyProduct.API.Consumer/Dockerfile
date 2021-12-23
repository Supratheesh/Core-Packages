#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["MyProduct.API.Consumer/MyProduct.API.Consumer.csproj", "MyProduct.API.Consumer/"]
RUN dotnet restore "MyProduct.API.Consumer/MyProduct.API.Consumer.csproj"
COPY . .
WORKDIR "/src/MyProduct.API.Consumer"
RUN dotnet build "MyProduct.API.Consumer.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MyProduct.API.Consumer.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MyProduct.API.Consumer.dll"]