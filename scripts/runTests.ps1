$env:PROJECT_ID = "PROJECT ID"
$env:PERSONAL_DATA_API_KEY = "API KEY"


Push-Location -Path "../KenticoCloud.PersonalData.Tests"
Try
{
    $command = "dotnet test"
    Invoke-Expression $command
}
Finally
{
    Pop-Location
}
