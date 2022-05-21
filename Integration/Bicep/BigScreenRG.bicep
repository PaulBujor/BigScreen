param location string = 'northeurope'
param baseName string = 'BigScreen'
param tmdbApiKey string

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

module KeyVault 'BigScreenKeyVault.bicep' = {
  name: 'KeyVault'
  params: {
    location: location
    baseName: baseName
    api: Apps.outputs.api
    client: Apps.outputs.client
    tmdbApiKey: tmdbApiKey
  }
  scope: ResourceGroup
}
