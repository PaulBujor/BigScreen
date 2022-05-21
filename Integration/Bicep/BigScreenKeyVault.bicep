param location string = 'northeurope'
param baseName string = 'BigScreen'
param tenantId string = tenant().tenantId
param api string
param client string
param tmdbApiKey string

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
        objectId: client
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

resource keyVaultSecret 'Microsoft.KeyVault/vaults/secrets@2019-09-01' = {
  name: 'tmdbApiKey'
  parent: KeyVault
  properties: {
    value: tmdbApiKey
  }
}
