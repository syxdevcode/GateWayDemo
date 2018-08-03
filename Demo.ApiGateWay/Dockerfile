FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY Demo.ApiGateWay/Demo.ApiGateWay.csproj Demo.ApiGateWay/
RUN dotnet restore Demo.ApiGateWay/Demo.ApiGateWay.csproj
COPY . .
WORKDIR /src/Demo.ApiGateWay
RUN dotnet build Demo.ApiGateWay.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish Demo.ApiGateWay.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Demo.ApiGateWay.dll"]
