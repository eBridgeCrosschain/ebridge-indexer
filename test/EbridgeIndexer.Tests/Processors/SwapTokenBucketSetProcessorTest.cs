using AeFinder.Sdk;
using EBridge.Contracts.Bridge;
using Ebridge.Indexer.Plugin.GraphQL;
using EbridgeIndexer.Entities;
using EbridgeIndexer.GraphQL;
using EbridgeIndexer.Processors.CrossChainLimit;
using Shouldly;
using Volo.Abp.ObjectMapping;
using Xunit;

namespace EbridgeIndexer.Processors;

public class SwapTokenBucketSetProcessorTest: EbridgeIndexerTestBase
{
    private readonly SwapTokenBucketSetProcessor _swapTokenBucketSetProcessor;
    private readonly IReadOnlyRepository<CrossChainLimitInfoIndex> _repository;
    private readonly IObjectMapper _objectMapper;
    public SwapTokenBucketSetProcessorTest()
    {
        _swapTokenBucketSetProcessor = GetRequiredService<SwapTokenBucketSetProcessor>();
        _repository = GetRequiredService<IReadOnlyRepository<CrossChainLimitInfoIndex>>();
        _objectMapper = GetRequiredService<IObjectMapper>(); 
    }

    [Fact]
    public async Task HandleEventAsync_Test()
    {
        const string chainId = "AELF";

        var logEvent = new SwapTokenBucketSet
        {
            Symbol = "ELF",
            FromChainId = "Sepolia",
            SwapCapacity = 500000000000,
            SwapRefillRate = 1670000000,
            SwapBucketIsEnable = true
        };
        var logEventContext = GenerateLogEventContext(logEvent);
        await _swapTokenBucketSetProcessor.ProcessAsync(logEvent, logEventContext);
        
        var entities = await Query.QueryCrossChainLimitInfosAsync(_repository, _objectMapper, new GetCrossChainLimitInfoInput
        {
            SkipCount = 0
        });
        entities.ShouldNotBeNull();
        entities.Data[0].ToChainId.ShouldBe("AELF");
    }
}