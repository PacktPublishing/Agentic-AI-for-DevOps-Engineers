$ErrorActionPreference = "Stop"

Write-Host "==> Restoring"
dotnet restore src/GenAIDevOps.sln

Write-Host "==> Testing"
dotnet test src/GenAIDevOps.sln
