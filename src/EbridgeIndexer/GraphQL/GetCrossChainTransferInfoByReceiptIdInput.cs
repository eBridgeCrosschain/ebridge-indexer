namespace EbridgeIndexer.GraphQL;

public class GetCrossChainTransferInfoByReceiptIdInput
{
    public string ChainId { get; set; }
    public string ReceiptId { get; set; }
}