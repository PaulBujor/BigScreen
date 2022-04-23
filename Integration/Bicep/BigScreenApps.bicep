param location string = 'northeurope'
param baseName string = 'BigScreen'

resource AppPlan 'Microsoft.Web/serverfarms@2021-03-01' = {
  location: location
  name: '${baseName}-AppPlan'
  sku: {
    name: 'F1'
  }
}

resource Backend 'Microsoft.Web/sites@2018-11-01' = {
  name: '${baseName}-API'
  location: location
  properties: {
    serverFarmId: AppPlan.id
  }
}

resource Frontend 'Microsoft.Web/sites@2018-11-01' = {
  name: baseName
  location: location
  properties: {
    serverFarmId: AppPlan.id
  }
}
