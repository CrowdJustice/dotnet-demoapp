
# Base image is .NET Core runtime only (Linux)
FROM mcr.microsoft.com/dotnet/aspnet:6.0-alpine

WORKDIR /build

# Copy project source files
COPY src ./src

# Restore, build & publish
WORKDIR /build/src
RUN dotnet restore
RUN dotnet publish --no-restore --configuration Release

# Metadata in Label Schema format (http://label-schema.org)
LABEL org.label-schema.name    = ".NET Core Demo Web App" \
      org.label-schema.version = "1.5.0" \
      org.label-schema.vendor  = "Ben Coleman" \
      org.opencontainers.image.source = "https://github.com/benc-uk/dotnet-demoapp"

# Seems as good a place as any
WORKDIR /app

RUN pwd
RUN ls /build/src/bin/Release/net6.0/publish/
RUN ls .
# Copy already published binaries (from build stage image)
COPY /build/src/bin/Release/net6.0/publish/ .

# Expose port 5000 from Kestrel webserver
EXPOSE 80

# Tell Kestrel to listen on port 5000 and serve plain HTTP
ENV ASPNETCORE_URLS http://*:80
ENV ASPNETCORE_ENVIRONMENT Production
# This is critical for the Azure AD signin flow to work in Kubernetes and App Service
ENV ASPNETCORE_FORWARDEDHEADERS_ENABLED=true

# Run the ASP.NET Core app
ENTRYPOINT dotnet dotnet-demoapp.dll