FROM mcr.microsoft.com/dotnet/aspnet:6.0

COPY api/ App/

EXPOSE 80

WORKDIR /App

ENTRYPOINT ["dotnet","RockApi.dll"]