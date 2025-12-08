namespace EbridgeIndexer.GraphQL;

public class CrossChainLimitInfoPageResultDto
{
    public long TotalRecordCount { get; set; }

    public List<CrossChainLimitInfoDto> Data { get; set; }
}