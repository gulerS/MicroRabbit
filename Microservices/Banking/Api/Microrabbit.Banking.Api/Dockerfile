#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Microservices/Banking/Api/Microrabbit.Banking.Api/Microrabbit.Banking.Api.csproj", "Microservices/Banking/Api/Microrabbit.Banking.Api/"]
COPY ["Infra.IoC/MikroRabbit.Infra.IoC/MikroRabbit.Infra.IoC.csproj", "Infra.IoC/MikroRabbit.Infra.IoC/"]
COPY ["Infra.Bus/MikroRabbit.Infra.Bus/MikroRabbit.Infra.Bus.csproj", "Infra.Bus/MikroRabbit.Infra.Bus/"]
COPY ["Domain/MicroRabbit.Domain.Core/MicroRabbit.Domain.Core.csproj", "Domain/MicroRabbit.Domain.Core/"]
COPY ["Microservices/Banking/Data/Microrabbit.Banking.Data/Microrabbit.Banking.Data.csproj", "Microservices/Banking/Data/Microrabbit.Banking.Data/"]
COPY ["Microservices/Banking/Domain/Microrabbit.Banking.Domain/Microrabbit.Banking.Domain.csproj", "Microservices/Banking/Domain/Microrabbit.Banking.Domain/"]
COPY ["Microservices/Transfer/Data/MicroRabbit.Transfer.Data/MicroRabbit.Transfer.Data.csproj", "Microservices/Transfer/Data/MicroRabbit.Transfer.Data/"]
COPY ["Microservices/Transfer/Domain/Microrabbit.Transfer.Domain/Microrabbit.Transfer.Domain.csproj", "Microservices/Transfer/Domain/Microrabbit.Transfer.Domain/"]
COPY ["Microservices/Transfer/Application/Microrabbit.Transfer.Application/Microrabbit.Transfer.Application.csproj", "Microservices/Transfer/Application/Microrabbit.Transfer.Application/"]
COPY ["Microservices/Banking/Application/Microrabbit.Banking.Application/Microrabbit.Banking.Application.csproj", "Microservices/Banking/Application/Microrabbit.Banking.Application/"]
RUN dotnet restore "Microservices/Banking/Api/Microrabbit.Banking.Api/Microrabbit.Banking.Api.csproj"
COPY . .
WORKDIR "/src/Microservices/Banking/Api/Microrabbit.Banking.Api"
RUN dotnet build "Microrabbit.Banking.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Microrabbit.Banking.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Microrabbit.Banking.Api.dll"]
