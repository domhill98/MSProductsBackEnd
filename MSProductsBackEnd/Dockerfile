FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["MSProductsBackEnd/MSProductsBackEnd.API.csproj", "MSProductsBackEnd/"]
COPY ["AzureDBConn/MSProductsBackEnd.Data.csproj", "AzureDBConn/"]
RUN dotnet restore "MSProductsBackEnd/MSProductsBackEnd.API.csproj"
COPY . .
WORKDIR "/src/MSProductsBackEnd"
RUN dotnet build "MSProductsBackEnd.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MSProductsBackEnd.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MSProductsBackEnd.API.dll"]