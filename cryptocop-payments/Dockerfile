FROM mcr.microsoft.com/dotnet/core/sdk:2.2

LABEL maintainer="Sindri Mar Ingason"


COPY . /app
WORKDIR /app
RUN dotnet restore
ENTRYPOINT [ "dotnet", "run" ]