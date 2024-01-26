using Pulumi;
using Pulumi.AzureNative.Resources;
using Pulumi.AzureNative.EventHub.V20230101Preview;
using Pulumi.AzureNative.EventHub.V20230101Preview.Inputs;

return await Pulumi.Deployment.RunAsync(() =>
{
    // Create an Azure Resource Group
    var resourceGroup = new ResourceGroup("eventhub-rg");

    var mynamespace = new Namespace("namespace", new()
    {
        IsAutoInflateEnabled = true,
        MaximumThroughputUnits = 40,
        MinimumTlsVersion = "1.2",
        PublicNetworkAccess = "Enabled",
        ResourceGroupName = resourceGroup.Name,
        Sku = new SkuArgs
        {
            Capacity = 1,
            Name = "Standard",
            Tier = "Standard"
        },
        Tags = new InputMap<string>
        {
            {"Name2", "mynamespace"}
        },
        ZoneRedundant = true
    });
});