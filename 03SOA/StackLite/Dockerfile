# In dockerfile, we provide commands to build images

# Image is a filesystem that contains the application and all its dependency
# We are building this filesystem layer by layer
# To Start off, we "download" our SDK

# FROM keyword sets our base image to build our own image upon
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ENV ASPNETCORE_URLS=http://+:5000
# Now we have the ability to compile and run .NET 6 applications
# Next, I'm going to set my workdirectory to execute all my subsequent COPY, ADD, CMD, ENTRYPOINT, and RUN commands on
WORKDIR /app

# Once my work directory is set, i'm going to copy my source code over
# Copy everything in my StackLite SOA demo, over to app folder
COPY . .

# We restore and build our application
RUN dotnet clean StackLite.sln
RUN dotnet publish WebAPI --configuration Release -o ./publish
# WORKDIR /app/publish

# When the user docker run, execute this command

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS run

WORKDIR /app

COPY --from=build /app/publish .

CMD ["dotnet", "WebAPI.dll"]
