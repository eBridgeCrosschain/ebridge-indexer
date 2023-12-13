using AElfIndexer.Client;
using AElfIndexer.Client.Handlers;
using AElfIndexer.Grains.State.Client;
using Ebridge.Indexer.Plugin.GraphQL;
using Ebridge.Indexer.Plugin.Processors;
using Ebridge.Indexer.Plugin.Processors.CrossChainLimit;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;

namespace Ebridge.Indexer.Plugin;

[DependsOn(typeof(AElfIndexerClientModule), typeof(AbpAutoMapperModule))]
public class EbridgeIndexerPluginModule : AElfIndexerClientPluginBaseModule<EbridgeIndexerPluginModule,
    EbridgeIndexerPluginSchema, Query>
{
    protected override void ConfigureServices(IServiceCollection serviceCollection)
    {
        var configuration = serviceCollection.GetConfiguration();
        serviceCollection.AddSingleton<IAElfLogEventProcessor<LogEventInfo>, ReceiptDailyLimitSetProcessor>();
        serviceCollection.AddSingleton<IAElfLogEventProcessor<LogEventInfo>, ReceiptLimitChangedProcessor>();
        serviceCollection.AddSingleton<IAElfLogEventProcessor<LogEventInfo>, ReceiptTokenBucketSetProcessor>();
        serviceCollection.AddSingleton<IAElfLogEventProcessor<LogEventInfo>, SwapDailyLimitSetProcessor>();
        serviceCollection.AddSingleton<IAElfLogEventProcessor<LogEventInfo>, SwapLimitChangedProcessor>();
        serviceCollection.AddSingleton<IAElfLogEventProcessor<LogEventInfo>, SwapTokenBucketSetProcessor>();
        Configure<ContractInfoOptions>(configuration.GetSection("ContractInfo"));
    }

    protected override string ClientId => "AElfIndexer_eBridge";
    protected override string Version => "1fa9a532ea7845079fbbbc1cf691357c";
}