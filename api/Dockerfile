
FROM microsoft/dotnet:2.2-sdk AS build-env
WORKDIR /app

# copy everything and build the project
COPY . ./
RUN dotnet restore Host/*.csproj
RUN dotnet publish Host/*.csproj -c Release -o out

# build runtime image
FROM microsoft/dotnet:2.2-runtime
WORKDIR /app
COPY --from=build-env /app/Host/out ./
ENTRYPOINT ["dotnet", "Host.dll"]