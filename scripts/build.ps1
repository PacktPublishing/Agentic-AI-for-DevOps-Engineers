$ErrorActionPreference = "Stop"

Write-Host "==> Restoring"
dotnet restore src/GenAIDevOps.sln

Write-Host "==> Building"
dotnet build src/GenAIDevOps.sln
