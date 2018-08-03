FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY Demo.ProductService/Demo.ProductService.csproj Demo.ProductService/
RUN dotnet restore Demo.ProductService/Demo.ProductService.csproj
COPY . .
WORKDIR /src/Demo.ProductService
RUN dotnet build Demo.ProductService.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish Demo.ProductService.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Demo.ProductService.dll"]
