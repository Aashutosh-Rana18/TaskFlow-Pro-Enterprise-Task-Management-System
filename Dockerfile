# Base image for runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

# Build image
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["TaskFlowPro.API/TaskFlowPro.API.csproj", "TaskFlowPro.API/"]
COPY ["TaskFlowPro.Application/TaskFlowPro.Application.csproj", "TaskFlowPro.Application/"]
COPY ["TaskFlowPro.Domain/TaskFlowPro.Domain.csproj", "TaskFlowPro.Domain/"]
COPY ["TaskFlowPro.Infrastructure/TaskFlowPro.Infrastructure.csproj", "TaskFlowPro.Infrastructure/"]
RUN dotnet restore "TaskFlowPro.API/TaskFlowPro.API.csproj"

COPY . .
WORKDIR "/src/TaskFlowPro.API"
RUN dotnet build "TaskFlowPro.API.csproj" -c Release -o /app/build

# Publish
FROM build AS publish
RUN dotnet publish "TaskFlowPro.API.csproj" -c Release -o /app/publish

# Final runtime image
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TaskFlowPro.API.dll"]
