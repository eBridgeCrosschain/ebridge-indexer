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

public class ReceiptDailyLimitSetProcessorTest : EbridgeIndexerTestBase
{
    private readonly ReceiptDailyLimitSetProcessor _receiptDailyLimitSetProcessor;
    private readonly IReadOnlyRepository<CrossChainLimitInfoIndex> _repository;
    private readonly IObjectMapper _objectMapper;
    public ReceiptDailyLimitSetProcessorTest()
    {
        _receiptDailyLimitSetProcessor = GetRequiredService<ReceiptDailyLimitSetProcessor>();
        _repository = GetRequiredService<IReadOnlyRepository<CrossChainLimitInfoIndex>>();
        _objectMapper = GetRequiredService<IObjectMapper>(); 
    }

    [Fact]
    public async Task HandleEventAsync_Test()
    {
        const string chainId = "AELF";

        var logEvent = new ReceiptDailyLimitSet
        {
            Symbol = "ELF",
            TargetChainId = "Sepolia",
            ReceiptDailyLimit = 100,
            ReceiptRefreshTime = Timestamp.FromDateTime(DateTime.UtcNow),
            CurrentReceiptDailyLimit = 111,
        };
        var logEventContext = GenerateLogEventContext(logEvent);
        await _receiptDailyLimitSetProcessor.ProcessAsync(logEvent, logEventContext);
        
        var entities = await Query.QueryCrossChainLimitInfosAsync(_repository, _objectMapper, new GetCrossChainLimitInfoInput
        {
            ToChainId = logEvent.TargetChainId,
            Symbol = logEvent.Symbol,
            FromChainId = chainId,
            SkipCount = 0
        });
        entities.ShouldNotBeNull();
        entities.Data[0].ToChainId.ShouldBe("Sepolia");
        entities.Data[0].DefaultDailyLimit.ShouldBe(100);
        entities.Data[0].CurrentDailyLimit.ShouldBe(111);
    }
}