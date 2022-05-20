dir "C:\Program Files\Azure Cosmos DB Emulator\"

Import-Module "$env:ProgramFiles\Azure Cosmos DB Emulator\PSModules\Microsoft.Azure.CosmosDB.Emulator"

$startEmulatorCmd = "Start-CosmosDbEmulator -NoFirewall -NoUI /DisableRateLimiting"
Write-Host $startEmulatorCmd
Invoke-Expression -Command $startEmulatorCmd

# Pipe an emulator info object to the output stream

$Emulator = Get-Item "$env:ProgramFiles\Azure Cosmos DB Emulator\Microsoft.Azure.Cosmos.Emulator.exe"
$IPAddress = Get-NetIPAddress -AddressFamily IPV4 -AddressState Preferred -PrefixOrigin Manual | Select-Object IPAddress

New-Object PSObject @{
Emulator = $Emulator.BaseName
Version = $Emulator.VersionInfo.ProductVersion
Endpoint = @($(hostname), $IPAddress.IPAddress) | ForEach-Object { "https://${_}:8081/" }
MongoDBEndpoint = @($(hostname), $IPAddress.IPAddress) | ForEach-Object { "mongodb://${_}:10255/" }
CassandraEndpoint = @($(hostname), $IPAddress.IPAddress) | ForEach-Object { "tcp://${_}:10350/" }
GremlinEndpoint = @($(hostname), $IPAddress.IPAddress) | ForEach-Object { "http://${_}:8901/" }
TableEndpoint = @($(hostname), $IPAddress.IPAddress) | ForEach-Object { "https://${_}:8902/" }
IPAddress = $IPAddress.IPAddress
}