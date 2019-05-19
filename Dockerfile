# Build image
FROM mcr.microsoft.com/dotnet/core/sdk:3.0.100-preview4 AS builder

RUN curl -sL https://deb.nodesource.com/setup_10.x |  bash -
RUN apt-get install -y nodejs

WORKDIR /
COPY . ./

WORKDIR /
RUN dotnet publish --configuration Release -o out 

# Build runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.0.0-preview4
WORKDIR /bin
COPY --from=builder /out .
ENV ASPNETCORE_URLS="http://*:80"
ENTRYPOINT ["dotnet", "Bankaccounts.dll"]