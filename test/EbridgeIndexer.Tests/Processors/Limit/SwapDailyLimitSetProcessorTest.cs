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

public class SwapDailyLimitSetProcessorTest  : EbridgeIndexerTestBase
{
    private readonly SwapDailyLimitSetProcessor _swapDailyLimitSetProcessor;
    private readonly IReadOnlyRepository<CrossChainLimitInfoIndex> _repository;
    private readonly IObjectMapper _objectMapper;
    public SwapDailyLimitSetProcessorTest()
    {
        _swapDailyLimitSetProcessor = GetRequiredService<SwapDailyLimitSetProcessor>();
        _repository = GetRequiredService<IReadOnlyRepository<CrossChainLimitInfoIndex>>();
        _objectMapper = GetRequiredService<IObjectMapper>(); 
    }

    [Fact]
    public async Task HandleEventAsync_Test()
    {
        const string chainId = "AELF";

        var logEvent = new SwapDailyLimitSet
        {
            Symbol = "ELF",
            FromChainId = "Sepolia",
            SwapDailyLimit = 100,
            SwapRefreshTime = Timestamp.FromDateTime(DateTime.UtcNow),
            CurrentSwapDailyLimit = 111,
        };
        var logEventContext = GenerateLogEventContext(logEvent);
        await _swapDailyLimitSetProcessor.ProcessAsync(logEvent, logEventContext);
        
        var entities = await Query.QueryCrossChainLimitInfosAsync(_repository, _objectMapper, new GetCrossChainLimitInfoInput
        {
            SkipCount = 0
        });
        entities.ShouldNotBeNull();
        entities.Data[0].FromChainId.ShouldBe("Sepolia");
        entities.Data[0].DefaultDailyLimit.ShouldBe(100);
        entities.Data[0].CurrentDailyLimit.ShouldBe(111);
    }
}