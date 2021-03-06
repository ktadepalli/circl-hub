FROM mcr.microsoft.com/dotnet/core/sdk:3.1 
WORKDIR /source

# copy csproj and restore as distinct layers
COPY *.sln .
COPY RecruitmentAPI/*.csproj ./RecruitmentAPI/
COPY RecruitmentUnitTests/*.csproj ./RecruitmentUnitTests/
ADD RecruitmentAPI/UploadResumes ./UploadResumes 

WORKDIR /source
RUN dotnet restore

# copy everything else and build app
COPY . .
WORKDIR /source
RUN dotnet publish -c release -o /app --no-restore

# final stage/image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
COPY --from=0 /app ./
EXPOSE 80
ENTRYPOINT ["dotnet", "RecruitmentAPI.dll"]
