using AeFinder.Sdk.Processor;
using EBridge.Contracts.Bridge;
using EbridgeIndexer.Entities;

namespace EbridgeIndexer.Processors.CrossChainLimit;

public class ReceiptDailyLimitSetProcessor : CrossChainLimitProcessorBase<ReceiptDailyLimitSet>
{
    public override async Task ProcessAsync(ReceiptDailyLimitSet logEvent, LogEventContext context)
    {
        var id = IdGenerateHelper.GetId(context.ChainId, logEvent.TargetChainId, logEvent.Symbol);
        var limitInfoIndex = await GetEntityAsync<CrossChainLimitInfoIndex>(id);
        if (limitInfoIndex == null)
        {
            limitInfoIndex = new CrossChainLimitInfoIndex();
            limitInfoIndex.Id = id;
            limitInfoIndex.FromChainId = context.ChainId;
            limitInfoIndex.LimitType = CrossChainLimitType.Receipt;
        }
        ObjectMapper.Map(logEvent, limitInfoIndex);
        await SaveEntityAsync(limitInfoIndex);
    }
}