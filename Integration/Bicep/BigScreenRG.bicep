param location string = 'northeurope'
param baseName string = 'BigScreen'

targetScope = 'subscription'

resource ResourceGroup 'Microsoft.Resources/resourceGroups@2021-04-01' = {
  location: location
  name: '${baseName}RG'
}

module Apps 'BigScreenApps.bicep' = {
  name: 'Apps'
  scope: ResourceGroup
  params: {
    location: location
    baseName: baseName
  }
}

