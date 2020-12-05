param ([Parameter(Mandatory)]$Name)
$env:DOTNET_ENVIRONMENT="Development"
dotnet ef --startup-project ./Tools/MainDbTool migrations add $Name --project ./Lib/MainDB.EF.SqlServer