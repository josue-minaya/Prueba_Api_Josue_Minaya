#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["Prueba_Josue_Minaya/Prueba_Api_Josue_Minaya.csproj", "Prueba_Josue_Minaya/"]
RUN dotnet restore "Prueba_Josue_Minaya/Prueba_Api_Josue_Minaya.csproj"
COPY . .
WORKDIR "/src/Prueba_Josue_Minaya"
RUN dotnet build "Prueba_Api_Josue_Minaya.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Prueba_Api_Josue_Minaya.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Prueba_Api_Josue_Minaya.dll"]