
# Base image is .NET Core runtime only (Linux)
FROM mcr.microsoft.com/dotnet/sdk:6.0-alpine

WORKDIR /build

# Copy project source files
COPY src ./src

# Restore, build & publish
WORKDIR /build/src
RUN dotnet restore
RUN dotnet publish -c Release -o /app/out dotnet-demoapp.csproj

# Metadata in Label Schema format (http://label-schema.org)
LABEL org.label-schema.name    = ".NET Core Demo Web App" \
      org.label-schema.version = "1.5.0" \
      org.label-schema.vendor  = "Ben Coleman" \
      org.opencontainers.image.source = "https://github.com/benc-uk/dotnet-demoapp"

# Seems as good a place as any
WORKDIR /app
COPY run.sh .

ENV ASPNETCORE_ENVIRONMENT Production
# This is critical for the Azure AD signin flow to work in Kubernetes and App Service
ENV ASPNETCORE_FORWARDEDHEADERS_ENABLED=true
