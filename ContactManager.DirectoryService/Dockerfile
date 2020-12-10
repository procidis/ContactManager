#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
ENV ASPNETCORE_ENVIRONMENT Development
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["ContactManager.DirectoryService/ContactManager.DirectoryService.csproj", "ContactManager.DirectoryService/"]
COPY ["ContactManager.ModelLayer/ContactManager.ModelLayer.csproj", "ContactManager.ModelLayer/"]
COPY ["ContactManager.Persistence/ContactManager.Persistence.csproj", "ContactManager.Persistence/"]
COPY ["ContactManager.CommonServices/ContactManager.CommonServices.csproj", "ContactManager.CommonServices/"]
COPY ["ContactManager.Core/ContactManager.Core.csproj", "ContactManager.Core/"]
RUN dotnet restore "ContactManager.DirectoryService/ContactManager.DirectoryService.csproj"
COPY . .
WORKDIR "/src/ContactManager.DirectoryService"
RUN dotnet build "ContactManager.DirectoryService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ContactManager.DirectoryService.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ContactManager.DirectoryService.dll"]
