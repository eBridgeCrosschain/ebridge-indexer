using AeFinder.App.TestBase;
using EbridgeIndexer.Processors.CrossChainLimit;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;

namespace EbridgeIndexer;

[DependsOn(
    typeof(AeFinderAppTestBaseModule),
    typeof(EbridgeIndexerModule))]
public class EbridgeIndexerTestModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AeFinderAppEntityOptions>(options => { options.AddTypes<EbridgeIndexerModule>(); });
        
        // Add your Processors.
        context.Services.AddSingleton<ReceiptTokenBucketSetProcessor>();
        context.Services.AddSingleton<ReceiptLimitChangedProcessor>();
        context.Services.AddSingleton<ReceiptDailyLimitSetProcessor>();
        context.Services.AddSingleton<SwapTokenBucketSetProcessor>();
        context.Services.AddSingleton<SwapDailyLimitSetProcessor>();
        context.Services.AddSingleton<SwapLimitChangedProcessor>();

    }
}