FROM microsoft/aspnetcore:1.1
ARG source
WORKDIR /app
EXPOSE 80
#COPY ${source:-bin/Debug/netcoreapp1.1/publish} .
COPY ${source:-obj/Docker/publish} .
ENTRYPOINT ["dotnet", "WebApp.dll"]
