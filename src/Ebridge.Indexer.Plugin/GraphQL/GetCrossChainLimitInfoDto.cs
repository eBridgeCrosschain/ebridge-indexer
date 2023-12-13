namespace Ebridge.Indexer.Plugin.GraphQL;

public class GetCrossChainLimitInfoDto
{
   public int SkipCount { get; set; }
   
   public string FromChainId { get; set; }
    
   public string ToChainId { get; set; }
   
   public string Symbol { get; set; }
}