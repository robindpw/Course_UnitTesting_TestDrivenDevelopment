@echo Make sure to you have installed report genarator globally by running following command: dotnet tool install -g dotnet-reportgenerator-globaltool
pause
dotnet test /p:CollectCoverage=true /p:CoverletOutputFormat=opencover /p:CoverletOutput=./coverage/coverage
reportgenerator "-reports:./coverage/coverage.opencover.xml" "-targetdir:./coverage/report"
start "" "./coverage/report\index.htm"
pause