using AElfIndexer.Client;
using AElfIndexer.Grains.State.Client;
using Ebridge.Indexer.Plugin.Entities;
using GraphQL;
using Nest;
using Volo.Abp.ObjectMapping;

namespace Ebridge.Indexer.Plugin.GraphQL;

public partial class Query
{
    [Name("queryCrossChainLimitInfos")]
    public static async Task<CrossChainLimitInfoPageResultDto> QueryCrossChainLimitInfosAsync(
        [FromServices] IAElfIndexerClientEntityRepository<CrossChainLimitInfoIndex, LogEventInfo> repository,
        [FromServices] IObjectMapper objectMapper,
        GetCrossChainLimitInfoDto dto)
    {
        var mustQuery = new List<Func<QueryContainerDescriptor<CrossChainLimitInfoIndex>, QueryContainer>>();
        if (!dto.FromChainId.IsNullOrEmpty())
        {
            mustQuery.Add(q => q.Term(i
                => i.Field(f => f.FromChainId).Value(dto.FromChainId)));
        }

        if (!dto.ToChainId.IsNullOrEmpty())
        {
            mustQuery.Add(q => q.Term(i
                => i.Field(f => f.ToChainId).Value(dto.ToChainId)));
        }

        if (!dto.Symbol.IsNullOrEmpty())
        {
            mustQuery.Add(q => q.Term(i
                => i.Field(f => f.Symbol).Value(dto.Symbol)));
        }

        QueryContainer Filter(QueryContainerDescriptor<CrossChainLimitInfoIndex> f)
            => f.Bool(b => b.Must(mustQuery));

        var result = await repository.GetListAsync(Filter, skip: dto.SkipCount);
        var dataList = objectMapper.Map<List<CrossChainLimitInfoIndex>, List<CrossChainLimitInfoDto>>(result.Item2);
        var pageResult = new CrossChainLimitInfoPageResultDto
        {
            TotalRecordCount = result.Item1,
            Data = dataList
        };
        return pageResult;
    }
}