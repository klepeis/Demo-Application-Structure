FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["Customer.GraphQL/Customer.GraphQL.csproj", "Customer.GraphQL/"]
RUN dotnet restore "Customer.GraphQL/Customer.GraphQL.csproj"
COPY . .
WORKDIR "/src/Customer.GraphQL"
RUN dotnet build "Customer.GraphQL.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Customer.GraphQL.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Customer.GraphQL.dll"]