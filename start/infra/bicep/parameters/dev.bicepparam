using '../main.bicep'

param environmentName = 'dev'

param containerAppName = 'ca-dev-sample'
param containerRegistryName = 'agenticaidevopsdev'
param imageName = 'azuredocs/containerapps-helloworld'
param imageTag = 'latest'
param targetPort = 80
