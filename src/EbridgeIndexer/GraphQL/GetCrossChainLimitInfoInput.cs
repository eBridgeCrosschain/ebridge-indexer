namespace Ebridge.Indexer.Plugin.GraphQL;

public class GetCrossChainLimitInfoInput
{
   public int SkipCount { get; set; }
   
   public string FromChainId { get; set; }
    
   public string ToChainId { get; set; }
   
   public string Symbol { get; set; }
}