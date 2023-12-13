using AElfIndexer.Client;
using AElfIndexer.Client.Handlers;
using AElfIndexer.Grains.State.Client;
using EBridge.Contracts.Bridge;
using Ebridge.Indexer.Plugin.Entities;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Volo.Abp.ObjectMapping;

namespace Ebridge.Indexer.Plugin.Processors.CrossChainLimit;

public class ReceiptDailyLimitSetProcessor : CrossChainLimitProcessorBase<ReceiptDailyLimitSet>
{
    public ReceiptDailyLimitSetProcessor(ILogger<ReceiptDailyLimitSetProcessor> logger,
        IObjectMapper objectMapper, IOptionsSnapshot<ContractInfoOptions> contractInfoOptions,
        IAElfIndexerClientEntityRepository<CrossChainLimitInfoIndex, LogEventInfo> crossChainLimitInfoIndexRepository) :
        base(logger, objectMapper, contractInfoOptions, crossChainLimitInfoIndexRepository)
    {
    }

    protected override async Task HandleEventAsync(ReceiptDailyLimitSet eventValue, LogEventContext context)
    {
        var id = IdGenerateHelper.GetId(context.ChainId, eventValue.TargetChainId, eventValue.Symbol);
        var limitInfoIndex = await LimitInfoIndexRepository.GetFromBlockStateSetAsync(id, context.ChainId);
        if (limitInfoIndex == null)
        {
            limitInfoIndex = new CrossChainLimitInfoIndex();
            limitInfoIndex.Id = id;
            limitInfoIndex.FromChainId = context.ChainId;
            limitInfoIndex.LimitType = CrossChainLimitType.Receipt;
        }
        ObjectMapper.Map(context, limitInfoIndex);
        ObjectMapper.Map(eventValue, limitInfoIndex);
        await LimitInfoIndexRepository.AddOrUpdateAsync(limitInfoIndex);
    }
}