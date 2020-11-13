FROM mcr.microsoft.com/dotnet/core/sdk:2.2

LABEL maintainer="Sindri Mar Ingason"

ENV ASPNETCORE_URLS=http://+:5672

COPY . /app
WORKDIR /app
RUN dotnet restore
ENTRYPOINT [ "dotnet", "run" ]