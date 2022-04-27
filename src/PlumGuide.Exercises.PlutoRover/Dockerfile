#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/PlumGuide.Exercises.PlutoRover/PlumGuide.Exercises.PlutoRover.csproj", "src/PlumGuide.Exercises.PlutoRover/"]
COPY ["src/PlumGuide.Exercises.PlutoRover.SDK/PlumGuide.Exercises.PlutoRover.SDK.csproj", "src/PlumGuide.Exercises.PlutoRover.SDK/"]
RUN dotnet restore "src/PlumGuide.Exercises.PlutoRover/PlumGuide.Exercises.PlutoRover.csproj"
COPY . .
WORKDIR "/src/src/PlumGuide.Exercises.PlutoRover"
RUN dotnet build "PlumGuide.Exercises.PlutoRover.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PlumGuide.Exercises.PlutoRover.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PlumGuide.Exercises.PlutoRover.dll"]