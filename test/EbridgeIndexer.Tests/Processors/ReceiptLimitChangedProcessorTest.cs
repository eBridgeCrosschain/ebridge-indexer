using AeFinder.Sdk;
using EBridge.Contracts.Bridge;
using Ebridge.Indexer.Plugin.GraphQL;
using EbridgeIndexer.Entities;
using EbridgeIndexer.GraphQL;
using EbridgeIndexer.Processors.CrossChainLimit;
using Google.Protobuf.WellKnownTypes;
using Shouldly;
using Volo.Abp.ObjectMapping;
using Xunit;

namespace EbridgeIndexer.Processors;

public class ReceiptLimitChangedProcessorTest: EbridgeIndexerTestBase
{
    private readonly ReceiptLimitChangedProcessor _receiptLimitChangedProcessor;
    private readonly IReadOnlyRepository<CrossChainLimitInfoIndex> _repository;
    private readonly IObjectMapper _objectMapper;
    public ReceiptLimitChangedProcessorTest()
    {
        _receiptLimitChangedProcessor = GetRequiredService<ReceiptLimitChangedProcessor>();
        _repository = GetRequiredService<IReadOnlyRepository<CrossChainLimitInfoIndex>>();
        _objectMapper = GetRequiredService<IObjectMapper>(); 
    }

    [Fact]
    public async Task HandleEventAsync_Test()
    {
        const string chainId = "AELF";

        var logEvent = new ReceiptLimitChanged
        {
            Symbol = "ELF",
            TargetChainId = "Sepolia",
            CurrentReceiptBucketTokenAmount = 100,
            ReceiptDailyLimitRefreshTime = Timestamp.FromDateTime(DateTime.UtcNow),
            CurrentReceiptDailyLimitAmount = 111
        };
        var logEventContext = GenerateLogEventContext(logEvent);
        await _receiptLimitChangedProcessor.ProcessAsync(logEvent, logEventContext);
        
        var entities = await Query.QueryCrossChainLimitInfosAsync(_repository, _objectMapper, new GetCrossChainLimitInfoInput
        {
            ToChainId = logEvent.TargetChainId,
            Symbol = logEvent.Symbol,
            FromChainId = chainId,
            SkipCount = 0
        });
        entities.ShouldNotBeNull();
        entities.Data[0].ToChainId.ShouldBe("Sepolia");
        entities.Data[0].CurrentDailyLimit.ShouldBe(111);
        entities.Data[0].CurrentBucketTokenAmount.ShouldBe(100);
    }
}