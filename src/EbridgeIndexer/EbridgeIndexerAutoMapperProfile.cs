using AeFinder.Sdk.Processor;
using AElf;
using AElf.Contracts.CrossChain;
using AElf.Contracts.MultiToken;
using AElf.Types;
using EbridgeIndexer.Entities;
using EbridgeIndexer.GraphQL;
using AutoMapper;
using EBridge.Contracts.Bridge;

namespace EbridgeIndexer;

public class EbridgeIndexerAutoMapperProfile : Profile
{
    public EbridgeIndexerAutoMapperProfile()
    {
        CreateMap<CrossChainLimitInfoIndex, CrossChainLimitInfoDto>();

        //CrossChainLimitInfo
        CreateMap<ReceiptDailyLimitSet, CrossChainLimitInfoIndex>()
            .ForMember(des => des.ToChainId, opt
                => opt.MapFrom(source => source.TargetChainId
                )).ForMember(des => des.DefaultDailyLimit, opt
                => opt.MapFrom(source => source.ReceiptDailyLimit
                )).ForMember(des => des.CurrentDailyLimit, opt
                => opt.MapFrom(source => source.CurrentReceiptDailyLimit
                )).ForMember(des => des.RefreshTime, opt
                => opt.MapFrom(source => source.ReceiptRefreshTime.ToDateTime()
                ));
        CreateMap<ReceiptLimitChanged, CrossChainLimitInfoIndex>()
            .ForMember(des => des.ToChainId, opt
                => opt.MapFrom(source => source.TargetChainId
                )).ForMember(des => des.CurrentDailyLimit, opt
                => opt.MapFrom(source => source.CurrentReceiptDailyLimitAmount
                )).ForMember(des => des.CurrentBucketTokenAmount, opt
                => opt.MapFrom(source => source.CurrentReceiptBucketTokenAmount
                )).ForMember(des => des.RefreshTime, opt
                => opt.MapFrom(source => source.ReceiptDailyLimitRefreshTime.ToDateTime()
                )).ForMember(des => des.BucketUpdateTime, opt
                => opt.MapFrom(source => source.ReceiptBucketUpdateTime.ToDateTime()
                ));
        CreateMap<ReceiptTokenBucketSet, CrossChainLimitInfoIndex>()
            .ForMember(des => des.ToChainId, opt
                => opt.MapFrom(source => source.TargetChainId
                )).ForMember(des => des.Capacity, opt
                => opt.MapFrom(source => source.ReceiptCapacity
                )).ForMember(des => des.RefillRate, opt
                => opt.MapFrom(source => source.ReceiptRefillRate
                )).ForMember(des => des.IsEnable, opt
                => opt.MapFrom(source => source.ReceiptBucketIsEnable
                )).ForMember(des => des.CurrentBucketTokenAmount, opt
                => opt.MapFrom(source => source.CurrentReceiptBucketTokenAmount
                )).ForMember(des => des.BucketUpdateTime, opt
                => opt.MapFrom(source => source.ReceiptBucketUpdateTime.ToDateTime()
                ));
        CreateMap<SwapDailyLimitSet, CrossChainLimitInfoIndex>()
            .ForMember(des => des.DefaultDailyLimit, opt
                => opt.MapFrom(source => source.SwapDailyLimit
                )).ForMember(des => des.CurrentDailyLimit, opt
                => opt.MapFrom(source => source.CurrentSwapDailyLimit
                )).ForMember(des => des.RefreshTime, opt
                => opt.MapFrom(source => source.SwapRefreshTime.ToDateTime()
                ));
        CreateMap<SwapLimitChanged, CrossChainLimitInfoIndex>()
            .ForMember(des => des.CurrentDailyLimit, opt
                => opt.MapFrom(source => source.CurrentSwapDailyLimitAmount
                )).ForMember(des => des.CurrentBucketTokenAmount, opt
                => opt.MapFrom(source => source.CurrentSwapBucketTokenAmount
                )).ForMember(des => des.RefreshTime, opt
                => opt.MapFrom(source => source.SwapDailyLimitRefreshTime.ToDateTime()
                )).ForMember(des => des.BucketUpdateTime, opt
                => opt.MapFrom(source => source.SwapBucketUpdateTime.ToDateTime()
                ));
        CreateMap<SwapTokenBucketSet, CrossChainLimitInfoIndex>()
            .ForMember(des => des.Capacity, opt
                => opt.MapFrom(source => source.SwapCapacity
                )).ForMember(des => des.RefillRate, opt
                => opt.MapFrom(source => source.SwapRefillRate
                )).ForMember(des => des.IsEnable, opt
                => opt.MapFrom(source => source.SwapBucketIsEnable
                )).ForMember(des => des.CurrentBucketTokenAmount, opt
                => opt.MapFrom(source => source.CurrentSwapBucketTokenAmount
                )).ForMember(des => des.BucketUpdateTime, opt
                => opt.MapFrom(source => source.SwapBucketUpdateTime.ToDateTime()
                ));
        // Common
        CreateMap<Hash, string>().ConvertUsing(s => s == null ? null : s.ToHex());
        CreateMap<Address, string>().ConvertUsing(s => s.ToBase58());
        
        CreateMap<CrossChainReceived, CrossChainTransferInfoIndex>()
            .ForMember(d => d.FromChainId, opt => opt.MapFrom(o => ChainHelper.ConvertChainIdToBase58(o.FromChainId)))
            .ForMember(d => d.TransferTransactionId, opt => opt.MapFrom(o => o.TransferTransactionId.ToHex()))
            .ForMember(d => d.ReceiveAmount, opt => opt.MapFrom(o => o.Amount))
            .ForMember(d => d.ReceiveTokenSymbol, opt => opt.MapFrom(o => o.Symbol))
            .ForMember(d => d.FromAddress, opt => opt.MapFrom(o => o.From.ToBase58()))
            .ForMember(d => d.ToAddress, opt => opt.MapFrom(o => o.To.ToBase58()));

        CreateMap<CrossChainTransferred, CrossChainTransferInfoIndex>()
            .ForMember(d => d.TransferAmount, opt => opt.MapFrom(o => o.Amount))
            .ForMember(d => d.TransferTokenSymbol, opt => opt.MapFrom(o => o.Symbol))
            .ForMember(d => d.ToChainId, opt => opt.MapFrom(o => ChainHelper.ConvertChainIdToBase58(o.ToChainId)))
            .ForMember(d => d.FromAddress, opt => opt.MapFrom(o => o.From.ToBase58()))
            .ForMember(d => d.ToAddress, opt => opt.MapFrom(o => o.To.ToBase58()));
        
        // CrossChain
        CreateMap<ParentChainIndexed, CrossChainIndexingInfoIndex>()
            .ForMember(d => d.IndexChainId, opt => opt.MapFrom(o => ChainHelper.ConvertChainIdToBase58(o.ChainId)))
            .ForMember(d => d.IndexBlockHeight, opt => opt.MapFrom(o => o.IndexedHeight));

        CreateMap<SideChainIndexed, CrossChainIndexingInfoIndex>()
            .ForMember(d => d.IndexChainId, opt => opt.MapFrom(o => ChainHelper.ConvertChainIdToBase58(o.ChainId)))
            .ForMember(d => d.IndexBlockHeight, opt => opt.MapFrom(o => o.IndexedHeight));

        CreateMap<CrossChainIndexingInfoIndex, CrossChainIndexingInfoDto>()
            .ForMember(d=>d.BlockHash, opt=>opt.MapFrom(o=>o.Metadata.Block.BlockHash))
            .ForMember(d=>d.BlockHeight, opt=>opt.MapFrom(o=>o.Metadata.Block.BlockHeight))
            .ForMember(d=>d.BlockTime, opt=>opt.MapFrom(o=>o.Metadata.Block.BlockTime))
            .ForMember(d=>d.ChainId, opt=>opt.MapFrom(o=>o.Metadata.ChainId));
        CreateMap<CrossChainTransferInfoIndex, CrossChainTransferInfoDto>()
            .ForMember(d=>d.BlockHash, opt=>opt.MapFrom(o=>o.Metadata.Block.BlockHash))
            .ForMember(d=>d.BlockHeight, opt=>opt.MapFrom(o=>o.Metadata.Block.BlockHeight))
            .ForMember(d=>d.BlockTime, opt=>opt.MapFrom(o=>o.Metadata.Block.BlockTime))
            .ForMember(d=>d.ChainId, opt=>opt.MapFrom(o=>o.Metadata.ChainId));
        
        // Bridge
        CreateMap<ReceiptCreated, CrossChainTransferInfoIndex>()
            .ForMember(d => d.TransferAmount, opt => opt.MapFrom(o => o.Amount))
            .ForMember(d => d.FromAddress, opt => opt.MapFrom(o => o.Owner.ToBase58()))
            .ForMember(d => d.ToAddress, opt => opt.MapFrom(o => o.TargetAddress))
            .ForMember(d => d.TransferTokenSymbol, opt => opt.MapFrom(o => o.Symbol))
            .ForMember(d => d.ToChainId, opt => opt.MapFrom(o => o.TargetChainId));

        CreateMap<TokenSwapped, CrossChainTransferInfoIndex>()
            .ForMember(d => d.ReceiveAmount, opt => opt.MapFrom(o => o.Amount))
            .ForMember(d => d.ReceiveTokenSymbol, opt => opt.MapFrom(o => o.Symbol))
            .ForMember(d => d.ToAddress, opt => opt.MapFrom(o => o.Address.ToBase58()));
        // TokenPool
        CreateMap<UserLiquidityRecordIndex, UserLiquidityRecordDto>()
            .ForMember(d=>d.BlockHash, opt=>opt.MapFrom(o=>o.Metadata.Block.BlockHash))
            .ForMember(d=>d.BlockHeight, opt=>opt.MapFrom(o=>o.Metadata.Block.BlockHeight))
            .ForMember(d=>d.BlockTime, opt=>opt.MapFrom(o=>o.Metadata.Block.BlockTime))
            .ForMember(d=>d.ChainId, opt=>opt.MapFrom(o=>o.Metadata.ChainId));
        CreateMap<PoolLiquidityRecordIndex, PoolLiquidityRecordDto>()
            .ForMember(d=>d.BlockHash, opt=>opt.MapFrom(o=>o.Metadata.Block.BlockHash))
            .ForMember(d=>d.BlockHeight, opt=>opt.MapFrom(o=>o.Metadata.Block.BlockHeight))
            .ForMember(d=>d.BlockTime, opt=>opt.MapFrom(o=>o.Metadata.Block.BlockTime))
            .ForMember(d=>d.ChainId, opt=>opt.MapFrom(o=>o.Metadata.ChainId));
    }
}