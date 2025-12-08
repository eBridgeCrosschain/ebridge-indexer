using AeFinder.Sdk;
using EBridge.Contracts.Bridge;
using EbridgeIndexer.GraphQL;
using Ebridge.Indexer.Plugin.GraphQL;
using EbridgeIndexer.Entities;
using EbridgeIndexer.Processors.CrossChainLimit;
using Shouldly;
using Xunit;
using Volo.Abp.ObjectMapping;

namespace EbridgeIndexer.Processors;

public class ReceiptTokenBucketSetProcessorTest : EbridgeIndexerTestBase
{
    private readonly ReceiptTokenBucketSetProcessor _receiptTokenBucketSetProcessor;
    private readonly IReadOnlyRepository<CrossChainLimitInfoIndex> _repository;
    private readonly IObjectMapper _objectMapper;
    public ReceiptTokenBucketSetProcessorTest()
    {
        _receiptTokenBucketSetProcessor = GetRequiredService<ReceiptTokenBucketSetProcessor>();
        _repository = GetRequiredService<IReadOnlyRepository<CrossChainLimitInfoIndex>>();
        _objectMapper = GetRequiredService<IObjectMapper>(); 
    }

    [Fact]
    public async Task HandleEventAsync_Test()
    {
        const string chainId = "AELF";

        var logEvent = new ReceiptTokenBucketSet
        {
            Symbol = "ELF",
            TargetChainId = "Sepolia",
            ReceiptCapacity = 500000000000,
            ReceiptRefillRate = 1670000000,
            ReceiptBucketIsEnable = true,
            //ReceiptBucketUpdateTime = DateTime.UtcNow.ToUniversalTime().ToTimestamp()
        };
        var logEventContext = GenerateLogEventContext(logEvent);
        await _receiptTokenBucketSetProcessor.ProcessAsync(logEvent, logEventContext);
        
        var entities = await Query.QueryCrossChainLimitInfosAsync(_repository, _objectMapper, new GetCrossChainLimitInfoInput
        {
            ToChainId = logEvent.TargetChainId,
            Symbol = logEvent.Symbol,
            FromChainId = chainId,
            SkipCount = 0
        });
        entities.ShouldNotBeNull();
        entities.Data[0].ToChainId.ShouldBe("Sepolia");
    }
}