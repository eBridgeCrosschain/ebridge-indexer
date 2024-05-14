using AElf.CSharp.Core;
using AElfIndexer.Client;
using AElfIndexer.Client.Handlers;
using AElfIndexer.Grains.State.Client;
using Ebridge.Indexer.Plugin.Entities;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Volo.Abp.ObjectMapping;

namespace Ebridge.Indexer.Plugin.Processors.CrossChainLimit;

public abstract class CrossChainLimitProcessorBase<TEvent> : AElfLogEventProcessorBase<TEvent, LogEventInfo>
    where TEvent : IEvent<TEvent>, new()
{
    protected ILogger<CrossChainLimitProcessorBase<TEvent>> Logger;
    protected readonly IObjectMapper ObjectMapper;
    protected readonly ContractInfoOptions ContractInfoOptions;

    protected readonly IAElfIndexerClientEntityRepository<CrossChainLimitInfoIndex, LogEventInfo> LimitInfoIndexRepository;

    protected CrossChainLimitProcessorBase(ILogger<CrossChainLimitProcessorBase<TEvent>> logger,
        IObjectMapper objectMapper,
        IOptionsSnapshot<ContractInfoOptions> contractInfoOptions,
        IAElfIndexerClientEntityRepository<CrossChainLimitInfoIndex, LogEventInfo> crossChainLimitInfoIndexRepository
    )
        : base(logger)
    {
        Logger = logger;
        ObjectMapper = objectMapper;
        ContractInfoOptions = contractInfoOptions.Value;
        LimitInfoIndexRepository = crossChainLimitInfoIndexRepository;
    }

    public override string GetContractAddress(string chainId)
    {
        return ContractInfoOptions.ContractInfos[chainId].BridgeContractAddress;
    }
}