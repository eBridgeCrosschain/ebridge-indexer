using AElfIndexer.Client.GraphQL;

namespace Ebridge.Indexer.Plugin.GraphQL;

public class EbridgeIndexerPluginSchema : AElfIndexerClientSchema<Query>
{
    public EbridgeIndexerPluginSchema(IServiceProvider serviceProvider) : base(serviceProvider)
    {
    }
}