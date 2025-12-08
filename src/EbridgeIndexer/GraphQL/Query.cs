using AeFinder.Sdk;
using Ebridge.Indexer.Plugin.GraphQL;
using EbridgeIndexer.Entities;
using GraphQL;
using Volo.Abp.ObjectMapping;

namespace EbridgeIndexer.GraphQL;

public class Query
{
    private const int MaxResultCount = 10000;
    
    [Name("queryCrossChainLimitInfos")]
    public static async Task<CrossChainLimitInfoPageResultDto> QueryCrossChainLimitInfosAsync(
        [FromServices] IReadOnlyRepository<CrossChainLimitInfoIndex> repository,
        [FromServices] IObjectMapper objectMapper,
        GetCrossChainLimitInfoInput input)
    {
        var queryable = await repository.GetQueryableAsync();
        if (!input.FromChainId.IsNullOrEmpty())
        {
            queryable = queryable.Where(a => a.FromChainId == input.FromChainId);
        }

        if (!input.ToChainId.IsNullOrEmpty())
        {
            queryable = queryable.Where(a => a.ToChainId == input.ToChainId);
        }

        if (!input.Symbol.IsNullOrEmpty())
        {
            queryable = queryable.Where(a => a.Symbol == input.Symbol);

        }

        var result = queryable.Skip(input.SkipCount).Take(MaxResultCount).ToList();
        var dataList = objectMapper.Map<List<CrossChainLimitInfoIndex>, List<CrossChainLimitInfoDto>>(result);
        return new CrossChainLimitInfoPageResultDto
        {
            TotalRecordCount = queryable.Count(),
            Data = dataList
        };
    }
    
    public static async Task<List<CrossChainIndexingInfoDto>> CrossChainIndexingInfo(
        [FromServices] IReadOnlyRepository<CrossChainIndexingInfoIndex> repository,
        [FromServices] IObjectMapper objectMapper,
        QueryInput input)
    {
        input.Validate();

        var queryable = await repository.GetQueryableAsync();

        queryable = queryable.Where(a => a.Metadata.ChainId == input.ChainId);

        if (input.StartBlockHeight > 0)
        {
            queryable = queryable.Where(a => a.Metadata.Block.BlockHeight >= input.StartBlockHeight);
        }

        if (input.EndBlockHeight > 0)
        {
            queryable = queryable.Where(a => a.Metadata.Block.BlockHeight <= input.EndBlockHeight);
        }

        var result = queryable.OrderBy(o => o.Metadata.Block.BlockHeight).Take(input.MaxMaxResultCount).ToList();
        return objectMapper.Map<List<CrossChainIndexingInfoIndex>, List<CrossChainIndexingInfoDto>>(result);
    }

    public static async Task<List<CrossChainTransferInfoDto>> CrossChainTransferInfo(
        [FromServices] IReadOnlyRepository<CrossChainTransferInfoIndex> repository,
        [FromServices] IObjectMapper objectMapper, QueryInput input)
    {
        input.Validate();

        var queryable = await repository.GetQueryableAsync();

        queryable = queryable.Where(a => a.Metadata.ChainId == input.ChainId);

        if (input.StartBlockHeight > 0)
        {
            queryable = queryable.Where(a => a.Metadata.Block.BlockHeight >= input.StartBlockHeight);
        }

        if (input.EndBlockHeight > 0)
        {
            queryable = queryable.Where(a => a.Metadata.Block.BlockHeight <= input.EndBlockHeight);
        }

        var result = queryable.OrderBy(o => o.Metadata.Block.BlockHeight).Take(input.MaxMaxResultCount).ToList();
        return objectMapper.Map<List<CrossChainTransferInfoIndex>, List<CrossChainTransferInfoDto>>(result);
    }
    public static async Task<CrossChainTransferInfoDto> QueryCrossChainTransferInfoByReceiptId(
        [FromServices] IReadOnlyRepository<CrossChainTransferInfoIndex> repository,
        [FromServices] IObjectMapper objectMapper, GetCrossChainTransferInfoByReceiptIdInput input)
    {
        var queryable = await repository.GetQueryableAsync();
        queryable = queryable.Where(a => a.Metadata.ChainId == input.ChainId);
        queryable = queryable.Where(a => a.ReceiptId == input.ReceiptId);
        var result = queryable.FirstOrDefault();
        return result == null ? null : objectMapper.Map<CrossChainTransferInfoIndex, CrossChainTransferInfoDto>(result);
    }
    public static async Task<CrossChainTransferInfoDto> HomogeneousCrossChainReceiveInfo(
        [FromServices] IReadOnlyRepository<CrossChainTransferInfoIndex> repository,
        [FromServices] IObjectMapper objectMapper, GetCrossChainInfoInput input)
    {
        var queryable = await repository.GetQueryableAsync();
        queryable = queryable.Where(a => a.Metadata.ChainId == input.ChainId);
        queryable = queryable.Where(a => a.ReceiveTransactionId == input.TransactionId);
        var result = queryable.FirstOrDefault();
        return result == null ? null : objectMapper.Map<CrossChainTransferInfoIndex, CrossChainTransferInfoDto>(result);
    }
    public static async Task<CrossChainTransferInfoDto> HomogeneousCrossChainTransferInfo(
        [FromServices] IReadOnlyRepository<CrossChainTransferInfoIndex> repository,
        [FromServices] IObjectMapper objectMapper, GetCrossChainInfoInput input)
    {
        var queryable = await repository.GetQueryableAsync();
        queryable = queryable.Where(a => a.Metadata.ChainId == input.ChainId);
        queryable = queryable.Where(a => a.TransferTransactionId == input.TransactionId);
        var result = queryable.FirstOrDefault();
        return result == null ? null : objectMapper.Map<CrossChainTransferInfoIndex, CrossChainTransferInfoDto>(result);
    }
    
    public static async Task<List<PoolLiquidityRecordDto>> PoolLiquidityInfo(
        [FromServices] IReadOnlyRepository<PoolLiquidityRecordIndex> repository,
        [FromServices] IObjectMapper objectMapper, QueryInput input)
    {
        input.Validate();

        var queryable = await repository.GetQueryableAsync();

        queryable = queryable.Where(a => a.Metadata.ChainId == input.ChainId);

        if (input.StartBlockHeight > 0)
        {
            queryable = queryable.Where(a => a.Metadata.Block.BlockHeight >= input.StartBlockHeight);
        }

        if (input.EndBlockHeight > 0)
        {
            queryable = queryable.Where(a => a.Metadata.Block.BlockHeight <= input.EndBlockHeight);
        }

        var result = queryable.OrderBy(o => o.Metadata.Block.BlockHeight).Take(input.MaxMaxResultCount).ToList();
        return objectMapper.Map<List<PoolLiquidityRecordIndex>, List<PoolLiquidityRecordDto>>(result);
    }
    
    public static async Task<List<UserLiquidityRecordDto>> UserLiquidityInfo(
        [FromServices] IReadOnlyRepository<UserLiquidityRecordIndex> repository,
        [FromServices] IObjectMapper objectMapper, QueryInput input)
    {
        input.Validate();

        var queryable = await repository.GetQueryableAsync();

        queryable = queryable.Where(a => a.Metadata.ChainId == input.ChainId);

        if (input.StartBlockHeight > 0)
        {
            queryable = queryable.Where(a => a.Metadata.Block.BlockHeight >= input.StartBlockHeight);
        }

        if (input.EndBlockHeight > 0)
        {
            queryable = queryable.Where(a => a.Metadata.Block.BlockHeight <= input.EndBlockHeight);
        }

        var result = queryable.OrderBy(o => o.Metadata.Block.BlockHeight).Take(input.MaxMaxResultCount).ToList();
        return objectMapper.Map<List<UserLiquidityRecordIndex>, List<UserLiquidityRecordDto>>(result);
    }
}