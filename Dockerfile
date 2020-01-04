FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["MSProductsBackEnd/MSProductsBackEnd.API.csproj", "MSProductsBackEnd/"]
RUN dotnet restore "MSProductsBackEnd/MSProductsBackEnd.API.csproj"
COPY . .
WORKDIR "/src/MSProductsBackEnd"
RUN dotnet build "MSProductsBackEnd.api.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "MSProductsBackEnd.api.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "MSProductsBackEnd.dll"]