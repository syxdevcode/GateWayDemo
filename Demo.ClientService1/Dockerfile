FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY Demo.ClientService1/Demo.ClientService1.csproj Demo.ClientService1/
RUN dotnet restore Demo.ClientService1/Demo.ClientService1.csproj
COPY . .
WORKDIR /src/Demo.ClientService1
RUN dotnet build Demo.ClientService1.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish Demo.ClientService1.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Demo.ClientService1.dll"]
