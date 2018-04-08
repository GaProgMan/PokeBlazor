# Stage 1: Compile and publish the source code
FROM microsoft/aspnetcore-build:2.1.300-preview1 AS builder
WORKDIR /app
COPY *.sln ./
COPY PokeBlazor.Client ./PokeBlazor.Client
COPY PokeBlazor.Server ./PokeBlazor.Server
COPY PokeBlazor.Shared ./PokeBlazor.Shared
RUN dotnet publish --configuration Release --output /app/out

# Stage 2: Copies the published code out to published image
FROM microsoft/aspnetcore-nightly:2.0.6
WORKDIR /app

COPY --from=builder /app/out .

# Super hack to work around https://github.com/aspnet/Blazor/issues/376
RUN mv -n wwwroot/* PokeBlazor.Client/dist
RUN rm -rf wwwroot/

ENTRYPOINT ["dotnet", "PokeBlazor.Server.dll"]