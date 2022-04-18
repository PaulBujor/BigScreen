param location string = 'northeurope'

resource appPlan 'Microsoft.Web/serverfarms@2021-03-01' = {
  location: location
  name: 'BigScreen Plan'
}

resource backend 'Microsoft.Web/sites@2018-11-01' = {
  name: 'BigScreen-API'
  location: location
  properties: {
    serverFarmId: appPlan.id
  }
}

resource frontend 'Microsoft.Web/sites@2018-11-01' = {
  name: 'BigScreen'
  location: location
  properties: {
    serverFarmId: appPlan.id
  }
}

