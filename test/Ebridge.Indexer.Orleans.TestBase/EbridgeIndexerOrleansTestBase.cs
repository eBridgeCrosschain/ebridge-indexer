using Ebridge.Indexer.TestBase;
using Orleans.TestingHost;
using Volo.Abp.Modularity;

namespace Ebridge.Indexer.Orleans.TestBase;

public abstract class EbridgeIndexerOrleansTestBase<TStartupModule> : EbridgeIndexerTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{
    protected readonly TestCluster Cluster;

    public EbridgeIndexerOrleansTestBase()
    {
        Cluster = GetRequiredService<ClusterFixture>().Cluster;
    }
}