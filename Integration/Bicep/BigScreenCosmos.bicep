param location string = 'eastus'

resource CosmosAccount 'Microsoft.DocumentDB/databaseAccounts@2021-10-15' = {
  name: 'bigscreen'
  location: location
  properties: {
    enableFreeTier: true
    consistencyPolicy: {
      defaultConsistencyLevel: 'Session'
    }
    locations: [
      {
        locationName: location
        failoverPriority: 0
        isZoneRedundant: false
      }
    ]
    capabilities: [
      {
        name: 'EnableServerless'
      }
    ]
    databaseAccountOfferType: 'Standard'
  }
}

output cosmosName string = CosmosAccount.name
