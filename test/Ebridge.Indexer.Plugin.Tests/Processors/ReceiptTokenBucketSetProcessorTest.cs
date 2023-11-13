using AElf.CSharp.Core.Extension;
using AElfIndexer.Client;
using AElfIndexer.Client.Handlers;
using AElfIndexer.Grains.State.Client;
using EBridge.Contracts.Bridge;
using Ebridge.Indexer.Plugin.Entities;
using Ebridge.Indexer.Plugin.Processors.CrossChainLimit;
using Ebridge.Indexer.Plugin.Tests.Helper;
using Google.Protobuf.WellKnownTypes;
using Shouldly;
using Xunit;

namespace Ebridge.Indexer.Plugin.Tests.Processors;

public class ReceiptTokenBucketSetProcessorTest : EbridgeIndexerPluginTestBase
{
    protected readonly IAElfIndexerClientEntityRepository<CrossChainLimitInfoIndex, LogEventInfo>
        _crossChainLimitInfoIndexRepository;


    public ReceiptTokenBucketSetProcessorTest()
    {
        _crossChainLimitInfoIndexRepository =
            GetRequiredService<IAElfIndexerClientEntityRepository<CrossChainLimitInfoIndex, LogEventInfo>>();
    }

    [Fact]
    public async Task HandleEventAsync_Test()
    {
        const string chainId = "AELF";
        const string blockHash = "0f4f79c709ee39c597795689f99be3c1384148dbb1a0b1b0fa21fc91229164e3";
        const string previousBlockHash = "f2316fb0e7646259a4238d8cd4700c9c6451a432e89df48c2368418c55c22b81";
        const string transactionId = "7a4c16a8aa4bb415b1128d060bb3e356ca7bab9ff77be5838a0ce5c4f5b1fe19";
        const long blockHeight = 120;

        //step1: create blockStateSet
        var blockStateSet = new BlockStateSet<LogEventInfo>
        {
            BlockHash = blockHash,
            BlockHeight = blockHeight,
            Confirmed = false,
            PreviousBlockHash = previousBlockHash,
        };
        var blockStateSetKey = await InitializeBlockStateSetAsync(blockStateSet, chainId);

        //step2: create logEventInfo
        /*{
            "Symbol":"ELF",
            "TargetChainId":"Sepolia",
            "ReceiptCapacity":500000000000,
            "ReceiptRefillRate":1670000000,
            "ReceiptBucketIsEnable":true,
            "ReceiptBucketUpdateTime":{
                "Seconds":1699809652,
                "Nanos":141745500
            }
        }*/
        var receiptTokenBucketSet = new ReceiptTokenBucketSet
        {
            Symbol = "ELF",
            TargetChainId = "Sepolia",
            ReceiptCapacity = 500000000000,
            ReceiptRefillRate = 1670000000,
            ReceiptBucketIsEnable = true,
            //ReceiptBucketUpdateTime = DateTime.UtcNow.ToUniversalTime().ToTimestamp()
        };

        var logEventInfo = LogEventHelper.ConvertAElfLogEventToLogEventInfo(receiptTokenBucketSet.ToLogEvent());
        logEventInfo.BlockHeight = blockHeight;
        logEventInfo.ChainId = chainId;
        logEventInfo.BlockHash = blockHash;
        logEventInfo.TransactionId = transactionId;

        var logEventContext = new LogEventContext
        {
            ChainId = chainId,
            BlockHeight = blockHeight,
            BlockHash = blockHash,
            PreviousBlockHash = previousBlockHash,
            TransactionId = transactionId
        };

        var processor = GetRequiredService<ReceiptTokenBucketSetProcessor>();
        await processor.HandleEventAsync(logEventInfo, logEventContext);

        //step4: save blockStateSet into es
        await BlockStateSetSaveDataAsync<LogEventInfo>(blockStateSetKey);
        await Task.Delay(0);
        
        var infoIndex = await _crossChainLimitInfoIndexRepository.GetAsync(
            IdGenerateHelper.GetId(chainId, receiptTokenBucketSet.TargetChainId, receiptTokenBucketSet.Symbol));

        infoIndex.ShouldNotBeNull();
    }
}