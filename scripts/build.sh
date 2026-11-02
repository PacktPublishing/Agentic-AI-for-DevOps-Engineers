#!/usr/bin/env bash
set -euo pipefail

echo "==> Restoring"
dotnet restore src/GenAIDevOps.sln

echo "==> Building"
dotnet build src/GenAIDevOps.sln
