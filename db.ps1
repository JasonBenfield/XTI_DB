Import-Module PowershellForXti -Force

$script:dbConfig = [PSCustomObject]@{
    RepoOwner = "JasonBenfield"
    RepoName = "XTI_DB"
    AppName = "XTI_DB"
    AppType = "Package"
}

function DB-NewVersion {
    param(
        [Parameter(Position=0,Mandatory)]
        [ValidateSet("major", "minor", "patch")]
        $VersionType
    )
    $script:dbConfig | New-XtiVersion @PsBoundParameters
}

function DB-NewIssue {
    param(
        [Parameter(Mandatory, Position=0)]
        [string] $IssueTitle,
        [switch] $Start
    )
    $script:dbConfig | New-XtiIssue @PsBoundParameters
}

function DB-StartIssue {
    param(
        [Parameter(Position=0)]
        [long]$IssueNumber = 0
    )
    $script:dbConfig | Xti-StartIssue @PsBoundParameters
}

function DB-CompleteIssue {
    param(
    )
    $script:dbConfig | Xti-CompleteIssue @PsBoundParameters
}

function DB-Publish {
    param(
        [ValidateSet("Development", "Production", "Staging", "Test")]
        $EnvName = "Development"
    )
    $script:dbConfig | Xti-Publish @PsBoundParameters
}
