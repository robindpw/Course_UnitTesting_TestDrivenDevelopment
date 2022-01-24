dotnet test /p:CollectCoverage=true /p:CoverletOutputFormat=opencover /p:CoverletOutput=./coverage/coverage
reportgenerator "-reports:./coverage/coverage.opencover.xml" "-targetdir:./coverage/report"
start "" "./coverage/report\index.htm"
pause