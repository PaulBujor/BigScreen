param location string = 'northeurope'
param baseName string = 'BigScreen'
param tenantId string = tenant().tenantId
param api string
param client string
param tmdbApiKey string
param cosmosName string

resource KeyVault 'Microsoft.KeyVault/vaults@2021-10-01' = {
  location: location
  name: '${baseName}-Vault'
  properties: {
    sku: {
      name: 'standard'
      family: 'A'
    }
    accessPolicies: [
      {
        tenantId: tenantId
        objectId: api
        permissions: {
          secrets: [
            'list'
            'get'
          ]
        }
      }
      {
        tenantId: tenantId
        objectId: '6981e08c-ed11-4921-a829-62b9838b9a1d'
        permissions: {
          secrets: [
            'list'
            'get'
          ]
        }
      }
      {
        tenantId: tenantId
        objectId: '8eac0439-912c-4691-86f1-6817098ebf56'
        permissions: {
          secrets: [
            'list'
            'get'
          ]
        }
      }
      {
        tenantId: tenantId
        objectId: '2664c9c5-13ea-4254-9b39-dd8f635ace4e'
        permissions: {
          secrets: [
            'list'
            'get'
          ]
        }
      }
    ]
    tenantId: tenantId
  }
}

resource tmdbSecret 'Microsoft.KeyVault/vaults/secrets@2019-09-01' = {
  name: 'tmdbApiKey'
  parent: KeyVault
  properties: {
    value: tmdbApiKey
  }
}

resource Cosmos 'Microsoft.DocumentDB/databaseAccounts@2021-10-15' existing = {
  name: cosmosName
}

resource cosmosURL 'Microsoft.KeyVault/vaults/secrets@2019-09-01' = {
  name: 'cosmosURL'
  parent: KeyVault
  properties: {
    value: Cosmos.properties.documentEndpoint
  }
}

resource cosmosAccessKey 'Microsoft.KeyVault/vaults/secrets@2019-09-01' = {
  name: 'cosmosAccessKey'
  parent: KeyVault
  properties: {
    value: Cosmos.listKeys().primaryMasterKey
  }
}
