#!/usr/bin/env bash
set -euo pipefail

echo "==> Restoring"
dotnet restore src/GenAIDevOps.sln

echo "==> Testing"
dotnet test src/GenAIDevOps.sln
