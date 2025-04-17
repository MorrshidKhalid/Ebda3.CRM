using Microsoft.AspNetCore.Builder;
using Ebda3.CRM;
using Volo.Abp.AspNetCore.TestBase;

var builder = WebApplication.CreateBuilder();
builder.Environment.ContentRootPath = GetWebProjectContentRootPathHelper.Get("Ebda3.CRM.Web.csproj"); 
await builder.RunAbpModuleAsync<CRMWebTestModule>(applicationName: "Ebda3.CRM.Web");

public partial class Program
{
}
