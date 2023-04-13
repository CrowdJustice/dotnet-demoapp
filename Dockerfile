
# Base image is .NET Core runtime only (Linux)
FROM mcr.microsoft.com/dotnet/sdk:6.0-alpine

# Build dotnet-demoapp
WORKDIR /build

# Copy project source files
COPY src ./src

# Restore, build & publish
WORKDIR /build/src
RUN dotnet restore
RUN dotnet publish -c Release -o /app/out dotnet-demoapp.csproj

# Build poller
WORKDIR /build-poller
COPY poller/*.csproj .
RUN dotnet restore
COPY poller .
RUN dotnet publish -c Release -o /app --no-restore

# Seems as good a place as any
WORKDIR /app
COPY run.sh .

ENV ASPNETCORE_ENVIRONMENT Production
# This is critical for the Azure AD signin flow to work in Kubernetes and App Service
ENV ASPNETCORE_FORWARDEDHEADERS_ENABLED=true
