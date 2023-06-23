FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /app
EXPOSE 8080

# Copy the .NET API project files to the working directory
COPY "Reactivities.API.sln" "Reactivities.API.sln" 
COPY "API/API.csproj"  "API/API.csproj"
COPY "Application/Application.csproj"  "Application/Application.csproj"
COPY "Persistence/Persistence.csproj"  "Persistence/Persistence.csproj"
COPY "Domain/Data.csproj"  "Domain/Data.csproj"
COPY "Infrastructure/Infrastructure.csproj"  "Infrastructure/Infrastructure.csproj"

RUN dotnet restore "Reactivities.API.sln"


#copy everything else build
COPY . .
WORKDIR /app

RUN dotnet publish -c Release -o out


FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app
COPY --from=build /app/out .
EXPOSE 80
ENTRYPOINT ["dotnet", "API.dll"]
