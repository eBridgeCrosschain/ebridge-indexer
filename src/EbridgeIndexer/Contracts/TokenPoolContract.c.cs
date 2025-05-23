// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: token_pool_contract.proto
// </auto-generated>
#pragma warning disable 0414, 1591
#region Designer generated code

using System.Collections.Generic;
using aelf = global::AElf.CSharp.Core;

namespace EBridge.Contracts.TokenPool {

  #region Events
  public partial class Locked : aelf::IEvent<Locked>
  {
    public global::System.Collections.Generic.IEnumerable<Locked> GetIndexed()
    {
      return new List<Locked>
      {
      };
    }

    public Locked GetNonIndexed()
    {
      return new Locked
      {
        FromChainId = FromChainId,
        ToChainId = ToChainId,
        TargetTokenSymbol = TargetTokenSymbol,
        Amount = Amount,
        Sender = Sender,
      };
    }
  }

  public partial class Released : aelf::IEvent<Released>
  {
    public global::System.Collections.Generic.IEnumerable<Released> GetIndexed()
    {
      return new List<Released>
      {
      };
    }

    public Released GetNonIndexed()
    {
      return new Released
      {
        FromChainId = FromChainId,
        ToChainId = ToChainId,
        TargetTokenSymbol = TargetTokenSymbol,
        Amount = Amount,
        Receiver = Receiver,
      };
    }
  }

  public partial class LiquidityAdded : aelf::IEvent<LiquidityAdded>
  {
    public global::System.Collections.Generic.IEnumerable<LiquidityAdded> GetIndexed()
    {
      return new List<LiquidityAdded>
      {
      };
    }

    public LiquidityAdded GetNonIndexed()
    {
      return new LiquidityAdded
      {
        TokenSymbol = TokenSymbol,
        Amount = Amount,
        Provider = Provider,
      };
    }
  }

  public partial class LiquidityRemoved : aelf::IEvent<LiquidityRemoved>
  {
    public global::System.Collections.Generic.IEnumerable<LiquidityRemoved> GetIndexed()
    {
      return new List<LiquidityRemoved>
      {
      };
    }

    public LiquidityRemoved GetNonIndexed()
    {
      return new LiquidityRemoved
      {
        TokenSymbol = TokenSymbol,
        Amount = Amount,
        Provider = Provider,
      };
    }
  }

  #endregion
  public static partial class TokenPoolContractContainer
  {
    static readonly string __ServiceName = "TokenPoolContract";

    #region Marshallers
    static readonly aelf::Marshaller<global::EBridge.Contracts.TokenPool.InitializeInput> __Marshaller_InitializeInput = aelf::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::EBridge.Contracts.TokenPool.InitializeInput.Parser.ParseFrom);
    static readonly aelf::Marshaller<global::Google.Protobuf.WellKnownTypes.Empty> __Marshaller_google_protobuf_Empty = aelf::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Google.Protobuf.WellKnownTypes.Empty.Parser.ParseFrom);
    static readonly aelf::Marshaller<global::EBridge.Contracts.TokenPool.LockInput> __Marshaller_LockInput = aelf::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::EBridge.Contracts.TokenPool.LockInput.Parser.ParseFrom);
    static readonly aelf::Marshaller<global::EBridge.Contracts.TokenPool.ReleaseInput> __Marshaller_ReleaseInput = aelf::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::EBridge.Contracts.TokenPool.ReleaseInput.Parser.ParseFrom);
    static readonly aelf::Marshaller<global::EBridge.Contracts.TokenPool.AddLiquidityInput> __Marshaller_AddLiquidityInput = aelf::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::EBridge.Contracts.TokenPool.AddLiquidityInput.Parser.ParseFrom);
    static readonly aelf::Marshaller<global::EBridge.Contracts.TokenPool.RemoveLiquidityInput> __Marshaller_RemoveLiquidityInput = aelf::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::EBridge.Contracts.TokenPool.RemoveLiquidityInput.Parser.ParseFrom);
    static readonly aelf::Marshaller<global::AElf.Types.Address> __Marshaller_aelf_Address = aelf::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::AElf.Types.Address.Parser.ParseFrom);
    static readonly aelf::Marshaller<global::EBridge.Contracts.TokenPool.MigratorInput> __Marshaller_MigratorInput = aelf::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::EBridge.Contracts.TokenPool.MigratorInput.Parser.ParseFrom);
    static readonly aelf::Marshaller<global::EBridge.Contracts.TokenPool.GetTokenPoolInfoInput> __Marshaller_GetTokenPoolInfoInput = aelf::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::EBridge.Contracts.TokenPool.GetTokenPoolInfoInput.Parser.ParseFrom);
    static readonly aelf::Marshaller<global::EBridge.Contracts.TokenPool.TokenPoolInfo> __Marshaller_TokenPoolInfo = aelf::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::EBridge.Contracts.TokenPool.TokenPoolInfo.Parser.ParseFrom);
    static readonly aelf::Marshaller<global::EBridge.Contracts.TokenPool.GetLiquidityInput> __Marshaller_GetLiquidityInput = aelf::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::EBridge.Contracts.TokenPool.GetLiquidityInput.Parser.ParseFrom);
    static readonly aelf::Marshaller<global::Google.Protobuf.WellKnownTypes.Int64Value> __Marshaller_google_protobuf_Int64Value = aelf::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Google.Protobuf.WellKnownTypes.Int64Value.Parser.ParseFrom);
    #endregion

    #region Methods
    static readonly aelf::Method<global::EBridge.Contracts.TokenPool.InitializeInput, global::Google.Protobuf.WellKnownTypes.Empty> __Method_Initialize = new aelf::Method<global::EBridge.Contracts.TokenPool.InitializeInput, global::Google.Protobuf.WellKnownTypes.Empty>(
        aelf::MethodType.Action,
        __ServiceName,
        "Initialize",
        __Marshaller_InitializeInput,
        __Marshaller_google_protobuf_Empty);

    static readonly aelf::Method<global::EBridge.Contracts.TokenPool.LockInput, global::Google.Protobuf.WellKnownTypes.Empty> __Method_Lock = new aelf::Method<global::EBridge.Contracts.TokenPool.LockInput, global::Google.Protobuf.WellKnownTypes.Empty>(
        aelf::MethodType.Action,
        __ServiceName,
        "Lock",
        __Marshaller_LockInput,
        __Marshaller_google_protobuf_Empty);

    static readonly aelf::Method<global::EBridge.Contracts.TokenPool.ReleaseInput, global::Google.Protobuf.WellKnownTypes.Empty> __Method_Release = new aelf::Method<global::EBridge.Contracts.TokenPool.ReleaseInput, global::Google.Protobuf.WellKnownTypes.Empty>(
        aelf::MethodType.Action,
        __ServiceName,
        "Release",
        __Marshaller_ReleaseInput,
        __Marshaller_google_protobuf_Empty);

    static readonly aelf::Method<global::EBridge.Contracts.TokenPool.AddLiquidityInput, global::Google.Protobuf.WellKnownTypes.Empty> __Method_AddLiquidity = new aelf::Method<global::EBridge.Contracts.TokenPool.AddLiquidityInput, global::Google.Protobuf.WellKnownTypes.Empty>(
        aelf::MethodType.Action,
        __ServiceName,
        "AddLiquidity",
        __Marshaller_AddLiquidityInput,
        __Marshaller_google_protobuf_Empty);

    static readonly aelf::Method<global::EBridge.Contracts.TokenPool.RemoveLiquidityInput, global::Google.Protobuf.WellKnownTypes.Empty> __Method_RemoveLiquidity = new aelf::Method<global::EBridge.Contracts.TokenPool.RemoveLiquidityInput, global::Google.Protobuf.WellKnownTypes.Empty>(
        aelf::MethodType.Action,
        __ServiceName,
        "RemoveLiquidity",
        __Marshaller_RemoveLiquidityInput,
        __Marshaller_google_protobuf_Empty);

    static readonly aelf::Method<global::AElf.Types.Address, global::Google.Protobuf.WellKnownTypes.Empty> __Method_SetAdmin = new aelf::Method<global::AElf.Types.Address, global::Google.Protobuf.WellKnownTypes.Empty>(
        aelf::MethodType.Action,
        __ServiceName,
        "SetAdmin",
        __Marshaller_aelf_Address,
        __Marshaller_google_protobuf_Empty);

    static readonly aelf::Method<global::AElf.Types.Address, global::Google.Protobuf.WellKnownTypes.Empty> __Method_SetBridgeContract = new aelf::Method<global::AElf.Types.Address, global::Google.Protobuf.WellKnownTypes.Empty>(
        aelf::MethodType.Action,
        __ServiceName,
        "SetBridgeContract",
        __Marshaller_aelf_Address,
        __Marshaller_google_protobuf_Empty);

    static readonly aelf::Method<global::EBridge.Contracts.TokenPool.MigratorInput, global::Google.Protobuf.WellKnownTypes.Empty> __Method_Migrator = new aelf::Method<global::EBridge.Contracts.TokenPool.MigratorInput, global::Google.Protobuf.WellKnownTypes.Empty>(
        aelf::MethodType.Action,
        __ServiceName,
        "Migrator",
        __Marshaller_MigratorInput,
        __Marshaller_google_protobuf_Empty);

    static readonly aelf::Method<global::EBridge.Contracts.TokenPool.GetTokenPoolInfoInput, global::EBridge.Contracts.TokenPool.TokenPoolInfo> __Method_GetTokenPoolInfo = new aelf::Method<global::EBridge.Contracts.TokenPool.GetTokenPoolInfoInput, global::EBridge.Contracts.TokenPool.TokenPoolInfo>(
        aelf::MethodType.View,
        __ServiceName,
        "GetTokenPoolInfo",
        __Marshaller_GetTokenPoolInfoInput,
        __Marshaller_TokenPoolInfo);

    static readonly aelf::Method<global::EBridge.Contracts.TokenPool.GetLiquidityInput, global::Google.Protobuf.WellKnownTypes.Int64Value> __Method_GetLiquidity = new aelf::Method<global::EBridge.Contracts.TokenPool.GetLiquidityInput, global::Google.Protobuf.WellKnownTypes.Int64Value>(
        aelf::MethodType.View,
        __ServiceName,
        "GetLiquidity",
        __Marshaller_GetLiquidityInput,
        __Marshaller_google_protobuf_Int64Value);

    static readonly aelf::Method<global::EBridge.Contracts.TokenPool.GetLiquidityInput, global::Google.Protobuf.WellKnownTypes.Int64Value> __Method_GetRemovableLiquidity = new aelf::Method<global::EBridge.Contracts.TokenPool.GetLiquidityInput, global::Google.Protobuf.WellKnownTypes.Int64Value>(
        aelf::MethodType.View,
        __ServiceName,
        "GetRemovableLiquidity",
        __Marshaller_GetLiquidityInput,
        __Marshaller_google_protobuf_Int64Value);

    static readonly aelf::Method<global::Google.Protobuf.WellKnownTypes.Empty, global::AElf.Types.Address> __Method_GetAdmin = new aelf::Method<global::Google.Protobuf.WellKnownTypes.Empty, global::AElf.Types.Address>(
        aelf::MethodType.View,
        __ServiceName,
        "GetAdmin",
        __Marshaller_google_protobuf_Empty,
        __Marshaller_aelf_Address);

    static readonly aelf::Method<global::Google.Protobuf.WellKnownTypes.Empty, global::AElf.Types.Address> __Method_GetBridgeContract = new aelf::Method<global::Google.Protobuf.WellKnownTypes.Empty, global::AElf.Types.Address>(
        aelf::MethodType.View,
        __ServiceName,
        "GetBridgeContract",
        __Marshaller_google_protobuf_Empty,
        __Marshaller_aelf_Address);

    #endregion

    #region Descriptors
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::EBridge.Contracts.TokenPool.TokenPoolContractReflection.Descriptor.Services[0]; }
    }

    public static global::System.Collections.Generic.IReadOnlyList<global::Google.Protobuf.Reflection.ServiceDescriptor> Descriptors
    {
      get
      {
        return new global::System.Collections.Generic.List<global::Google.Protobuf.Reflection.ServiceDescriptor>()
        {
          global::AElf.Standards.ACS12.Acs12Reflection.Descriptor.Services[0],
          global::EBridge.Contracts.TokenPool.TokenPoolContractReflection.Descriptor.Services[0],
        };
      }
    }
    #endregion

    /// <summary>Base class for the contract of TokenPoolContract</summary>

  }
}
#endregion

