Import-Module PowershellForXti -Force

$script:dbConfig = [PSCustomObject]@{
    RepoOwner = "JasonBenfield"
    RepoName = "XTI_DB"
    AppName = "XTI_DB"
    AppType = "Package"
    ProjectDir = ""
}

function DB-New-XtiIssue {
    param(
        [Parameter(Mandatory, Position=0)]
        [string] $IssueTitle,
        $Labels = @(),
        [string] $Body = "",
        [switch] $Start
    )
    $script:dbConfig | New-XtiIssue @PsBoundParameters
}

function DB-Xti-StartIssue {
    param(
        [Parameter(Position=0)]
        [long]$IssueNumber = 0,
        $IssueBranchTitle = "",
        $AssignTo = ""
    )
    $script:dbConfig | Xti-StartIssue @PsBoundParameters
}

function DB-New-XtiVersion {
    param(
        [Parameter(Position=0)]
        [ValidateSet("major", "minor", "patch")]
        $VersionType = "minor",
        [ValidateSet("Development", "Production", "Staging", "Test")]
        $EnvName = "Production"
    )
    $script:dbConfig | New-XtiVersion @PsBoundParameters
}

function DB-Xti-Merge {
    param(
        [Parameter(Position=0)]
        [string] $CommitMessage
    )
    $script:dbConfig | Xti-Merge @PsBoundParameters
}

function DB-New-XtiPullRequest {
    param(
        [Parameter(Position=0)]
        [string] $CommitMessage
    )
    $script:dbConfig | New-XtiPullRequest @PsBoundParameters
}

function DB-Xti-PostMerge {
    param(
    )
    $script:dbConfig | Xti-PostMerge @PsBoundParameters
}

function DB-Publish {
    param(
        [switch] $Prod
    )
    $script:dbConfig | Xti-PublishPackage @PsBoundParameters
    if($Prod) {
        $script:dbConfig | Xti-Merge
    }
}
