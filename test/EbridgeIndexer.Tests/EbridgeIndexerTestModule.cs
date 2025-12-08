using AeFinder.App.TestBase;
using EbridgeIndexer.Processors.Bridge;
using EbridgeIndexer.Processors.CrossChain;
using EbridgeIndexer.Processors.CrossChainLimit;
using EbridgeIndexer.Processors.Token;
using EbridgeIndexer.Processors.TokenPool;
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
        context.Services.AddSingleton<ReceiptCreatedProcessor>();
        context.Services.AddSingleton<TokenSwappedProcessor>();
        //ParentChainIndexedProcessor
        context.Services.AddSingleton<ParentChainIndexedProcessor>();
        //SideChainIndexedProcessor
        context.Services.AddSingleton<SideChainIndexedProcessor>();
        //CrossChainTransferredProcessor
        context.Services.AddSingleton<CrossChainTransferredProcessor>();
        //CrossChainReceivedProcessor
        context.Services.AddSingleton<CrossChainReceivedProcessor>();
        context.Services.AddSingleton<LiquidityAddedProcessor>();
        context.Services.AddSingleton<LiquidityRemovedProcessor>();
        context.Services.AddSingleton<LockedProcessor>();
        context.Services.AddSingleton<ReleasedProcessor>();
    }
}