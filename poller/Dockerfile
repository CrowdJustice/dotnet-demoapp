FROM mcr.microsoft.com/dotnet/sdk:6.0-alpine
WORKDIR /source

# copy csproj and restore as distinct layers
COPY *.csproj .
RUN dotnet restore

# copy and publish app and libraries
COPY . .
RUN dotnet publish -c Release -o /app --no-restore

# copy the cron config into the right place
COPY poller/crontab /var/spool/cron/crontabs/root
RUN chmod 644 /var/spool/cron/crontabs/root

# set the current working directory
WORKDIR /app
ENTRYPOINT ["crond", "-l", "2", "-f"]
