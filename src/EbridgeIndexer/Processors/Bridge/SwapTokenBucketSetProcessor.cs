using AeFinder.Sdk.Processor;
using EBridge.Contracts.Bridge;
using EbridgeIndexer.Entities;
using EbridgeIndexer.Processors.Bridge;

namespace EbridgeIndexer.Processors.CrossChainLimit;

public class SwapTokenBucketSetProcessor : BridgeProcessorBase<SwapTokenBucketSet>
{
    public override async Task ProcessAsync(SwapTokenBucketSet logEvent, LogEventContext context)
    {
        var id = IdGenerateHelper.GetId(logEvent.FromChainId, context.ChainId, logEvent.Symbol);
        var limitInfoIndex = await GetEntityAsync<CrossChainLimitInfoIndex>(id);
        if (limitInfoIndex == null)
        {
            limitInfoIndex = new CrossChainLimitInfoIndex();
            limitInfoIndex.Id = id;
            limitInfoIndex.ToChainId = context.ChainId;
            limitInfoIndex.LimitType = CrossChainLimitType.Swap;
        }
        ObjectMapper.Map(logEvent, limitInfoIndex);
        await SaveEntityAsync(limitInfoIndex);
    }
}