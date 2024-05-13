FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env
WORKDIR /app
EXPOSE 80
EXPOSE 443
EXPOSE 5000

COPY ./R2EShop.API/*.csproj ./R2EShop.API/
COPY ./R2EShop.Domain/*.csproj ./R2EShop.Domain/
RUN dotnet restore ./R2EShop.API/*.csproj
RUN dotnet restore ./R2EShop.Domain/*.csproj

COPY . ./

RUN dotnet build ./R2EShop.Domain/*.csproj -c Release
RUN dotnet build ./R2EShop.API/*.csproj -c Release

RUN dotnet publish ./R2EShop.API/*.csproj -c Release -o out

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS final-env
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "R2EShop.API.dll"]