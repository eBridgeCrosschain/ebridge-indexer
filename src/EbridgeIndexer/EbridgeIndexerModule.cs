using AeFinder.Sdk.Processor;
using EbridgeIndexer.GraphQL;
using EbridgeIndexer.Processors;
using EbridgeIndexer.Processors.Bridge;
using EbridgeIndexer.Processors.CrossChain;
using EbridgeIndexer.Processors.CrossChainLimit;
using EbridgeIndexer.Processors.Token;
using EbridgeIndexer.Processors.TokenPool;
using GraphQL.Types;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;

namespace EbridgeIndexer;

public class EbridgeIndexerModule: AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpAutoMapperOptions>(options => { options.AddMaps<EbridgeIndexerModule>(); });
        context.Services.AddSingleton<ISchema, AeIndexerSchema>();
        
        // Add your LogEventProcessor implementation.
        context.Services.AddSingleton<ILogEventProcessor, ReceiptDailyLimitSetProcessor>();
        context.Services.AddSingleton<ILogEventProcessor, ReceiptLimitChangedProcessor>();
        context.Services.AddSingleton<ILogEventProcessor, ReceiptTokenBucketSetProcessor>();
        context.Services.AddSingleton<ILogEventProcessor, SwapDailyLimitSetProcessor>();
        context.Services.AddSingleton<ILogEventProcessor, SwapLimitChangedProcessor>();
        context.Services.AddSingleton<ILogEventProcessor, SwapTokenBucketSetProcessor>();
        context.Services.AddSingleton<ILogEventProcessor, ReceiptCreatedProcessor>();
        context.Services.AddSingleton<ILogEventProcessor, TokenSwappedProcessor>();
        context.Services.AddSingleton<ILogEventProcessor, CrossChainTransferredProcessor>();
        context.Services.AddSingleton<ILogEventProcessor, CrossChainReceivedProcessor>();
        context.Services.AddSingleton<ILogEventProcessor, ParentChainIndexedProcessor>();
        context.Services.AddSingleton<ILogEventProcessor, SideChainIndexedProcessor>();
        context.Services.AddSingleton<ILogEventProcessor, LiquidityAddedProcessor>();
        context.Services.AddSingleton<ILogEventProcessor, LiquidityRemovedProcessor>();
        context.Services.AddSingleton<ILogEventProcessor, LockedProcessor>();
        context.Services.AddSingleton<ILogEventProcessor, ReleasedProcessor>();
    }
}