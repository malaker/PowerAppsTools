# PowerApp Checker
## Motivation

In the moment of implementing existing Powershell module  Microsoft.PowerApps.Checker.PowerShell does not implement client credential flow. This library implements client credential flow. It calls powerapps checker web api - https://docs.microsoft.com/en-us/power-platform/alm/checker-api/overview

For teams who are in need of automation CI/CD pipeline introducing static analysis of powerapp / dynamics 365 solution is great benefit. It quickly identifies problematic patterns and prevent introducing to solution legacy patterns or deprecated API etc.

## What it does 

Library allows to call PowerApps Checker Web Api and make static analysis of power app solution including Dynamics 365 solution. Implements OAuth client credential flow It is possible to use client secret or client certificate.

## What is needed

1. Registered app in portal azure
2. App should have assigned either 
    - Dynamics CRM /user_impersonation and assigned system administrator role in environment
    - or PowerApps-Adivsor/Analysis.All

## Example usage

```csharp
string tenantId = "123456b6-1234-1234-1234-123456789abc"; // tenant id
string clientId = "12345678-1234-5678-1234-123456789abc"; // application id for registered app in portal azure
string redrictUri = "http://localhost" // registered redirect uri for app in portal azure

//using secret
var client =  DefaultClientFactory.Instance.Create(
            new ClientSettings()
            {
                TenantId = tenantId,
                ClientId = clientId,
                Scopes = new [] { "https://api.advisor.powerapps.com//.default" },
                RedirectUri = redrictUri,
                Secret = "somesecret",
                
            });
//using certificate
X509Certificate2 certificate = ... // load certificate from store or file

client =  DefaultClientFactory.Instance.Create(
            new ClientSettings()
            {
                TenantId = tenantId,
                ClientId = clientId,
                Scopes = new [] { "https://api.advisor.powerapps.com//.default" },
                RedirectUri = redrictUri,
                Certificate = certificate,
                
            });

//load zipped managed solution
string fullPathToManagedSolution = "C:\\directory\solution_managed.zip";

byte[] managedSolution = null;

using(var fs = File.Open(fullPathToManagedSolution,FileMode.Open)){
    using(var ms = new MemoryStream()){
        fs.CopyTo(ms);
        ms.Position=0L;
        managedSolution = ms.ToArray();
    }
}

//calling powerapps checker web api
//initialize correlationId

Guid correlationId = Guid.NewGuid();

var uploadReqResponse = await client.UploadSolution(managedSolution, "Test", tenantId, correlationId, CancellationToken.None);

var analysisInvokationResult = await client.InvokeAnalysis(uploadReqResponse, CancellationToken.None);

//in the loop
var analysisStatus = await client.CheckAnalysis(tenantId, correlationId, CancellationToken.None);

do
{
    await Task.Delay(5000);

    analysisStatus = await client.CheckAnalysis(tenantId, correlationId, default);

} while (analysisStatus.Progress != 100);

```

# XRM Online Management API
Online Management API is a REST API that lets you create and manage Common Data Service environments in your Office 365 tenant.

## Motivation

Current powershell library https://docs.microsoft.com/en-us/powerapps/developer/common-data-service/online-management-api/overview does not support client credential flow. This small library uses Xrm Online Management API rest API using client credentials (secret or certificate). Can be used in CI/CD pipeline.

## Configuration

1. Register app in portal.azure.com
    - Give API permissions : Dynamics CRM / user_impersonation / Type Delegated
2. As Global administrator or Dynamics 365 Service administrator
    -  Using powershell register your app as manager of CDS environments 
```powershell
Install-Module -Name Microsoft.Xrm.OnlineManagementAPI
Import-Module Microsoft.Xrm.OnlineManagementAPI

$username = "<YOUR AD Account name>"
$plainPassword = "P@ssw0rd"
$password = $plainPassword | ConvertTo-SecureString -AsPlainText -Force


$credentials = New-Object System.Management.Automation.PSCredential -ArgumentList ($username,$password)

New-CrmManagementApp -AppId "<APPID>" -ApiUrl "<e.g https://admin.services.crm4.dynamics.com>" -TenantId "<TENANTID>" -Enable -Credential $credentials

```

After this you should be able to call XRM Online Management API using client credential flow.

## Example

```csharp
string tenantId = "123456b6-1234-1234-1234-123456789abc"; // tenant id
string clientId = "12345678-1234-5678-1234-123456789abc"; // application id for registered app in portal azure
string redrictUri = "http://localhost" // registered redirect uri for app in portal azure

//using secret
var client =  DefaultOnlineManagementApiClientFactory.Instance.Create(
            new XRMClientSettings()
            {
                TenantId = tenantId,
                ClientId = clientId,
                Scopes = new [] { "https://admin.services.crm4.dynamics.com//.default" },
                RedirectUri = redrictUri,
                Secret = "somesecret",
                
            });
//using certificate
X509Certificate2 certificate = ... // load certificate from store or file

client =  DefaultClientFactory.Instance.Create(
            new XrmClientSettings()
            {
                TenantId = tenantId,
                ClientId = clientId,
                Scopes = new [] { "https://admin.services.crm4.dynamics.com//.default" },
                RedirectUri = redrictUri,
                Certificate = certificate,
                
            });

 var instances = await client.GetInstances(CancellationToken.None);


```