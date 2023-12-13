using AElfIndexer;

namespace Ebridge.Indexer.Plugin.GraphQL;

public class GetSyncStateDto
{
    public string ChainId { get; set; }
    public BlockFilterType FilterType { get; set; }
}