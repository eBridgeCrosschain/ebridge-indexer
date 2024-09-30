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
}