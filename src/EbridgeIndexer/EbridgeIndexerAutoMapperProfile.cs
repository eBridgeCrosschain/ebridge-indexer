using AeFinder.Sdk.Processor;
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
    }
}