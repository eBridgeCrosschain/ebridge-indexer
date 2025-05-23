using EbridgeIndexer.Entities;

namespace EbridgeIndexer.GraphQL;

public class PoolLiquidityRecordDto : GraphQLDto
{
    public string TokenSymbol { get; set; }
    public long Liquidity { get; set; }
    public LiquidityType LiquidityType { get; set; }
    public DateTime UpdateTime { get; set; }

}