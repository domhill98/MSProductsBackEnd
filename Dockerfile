FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["ProductsBackEnd/ProductsBackEnd.csproj", "ProductsBackEnd/"]
RUN dotnet restore "ProductsBackEnd/ProductsBackEnd.csproj"
COPY . .
WORKDIR "/src/ProductsBackEnd"
RUN dotnet build "ProductsBackEnd.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "ProductsBackEnd.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "ProductsBackEnd.dll"]
