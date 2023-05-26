# builds our image using dotnet's sdk
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /source
COPY *.csproj ./webapp/
WORKDIR /source/webapp
RUN dotnet restore
COPY . /source/webapp/
WORKDIR /source/webapp
RUN dotnet publish -c release -o /app --no-restore

# runs it using aspnet runtime
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build /app ./
ENTRYPOINT ["dotnet", "SEP-App.dll"]
EXPOSE 80
