# Stage 1: Compile and publish the source code
FROM microsoft/dotnet:2.1-sdk-stretch AS builder
WORKDIR /app
COPY *.sln ./
COPY PokeBlazor.Client ./PokeBlazor.Client
COPY PokeBlazor.Server ./PokeBlazor.Server
COPY PokeBlazor.Shared ./PokeBlazor.Shared

## restore onto a separate layer. That way, we have a single 
RUN dotnet restore

RUN dotnet publish --configuration Release --no-restore --output /app/out /p:PublishWithAspNetCoreTargetManifest="false"

# Stage 2: Copies the published code out to published image
FROM microsoft/dotnet:2.1-aspnetcore-runtime-alpine
WORKDIR /app
ENV ASPNETCORE_URLS http://+:5000

COPY --from=builder /app/out .

# Super hack to work around https://github.com/aspnet/Blazor/issues/376
RUN mv -n wwwroot/* PokeBlazor.Client/dist
RUN rm -rf wwwroot/

ENTRYPOINT ["dotnet", "PokeBlazor.Server.dll"]