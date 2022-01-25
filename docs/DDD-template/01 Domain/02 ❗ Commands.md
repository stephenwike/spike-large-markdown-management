|Command Name|Description|
|--|--|
|[AllocateLicenseToDevice](../src/Bct.Common.Licensing.Contract/Commands/AllocateLicenseToDevice.cs)|Attempts to create a ``DeviceLicenseAllocation``, consuming allocations from a ``DeviceLicense``.|
|[**BaseCommand**](../src/Bct.Common.Licensing.Contract/Commands/BaseCommand.cs)|Base Command inherited by all commands in the Contract.|
|[**BaseCreateLicenseCommand**](../src/Bct.Common.Licensing.Contract/Commands/BaseLicenseCreationCommand.cs)|Base Command inherited by the following commands: ``CreateDeviceLicense``, ``CreateTokenLicense`` and ``CreateTokenLicense``.|
|[ConsumeTokens](../src/Bct.Common.Licensing.Contract/Commands/ConsumeTokens.cs)|Consumes Tokens from a ``TokenLicense``.|
|[CreateDeviceLicense](../src/Bct.Common.Licensing.Contract/Commands/CreateDeviceLicense.cs)|Creates a ``DeviceLicense`` in the system.|
|[CreateFeatureLicense](../src/Bct.Common.Licensing.Contract/Commands/CreateFeatureLicense.cs)|Creates a ``FeatureLicense`` in the system.|
|[CreateTokenLicense](../src/Bct.Common.Licensing.Contract/Commands/CreateTokenLicense.cs)|Creates a ``TokenLicense`` in the system.|
|[DeleteLicense](../src/Bct.Common.Licensing.Contract/Commands/DeleteLicense.cs)|Deletes any license from the system.|
|[SetAvailableTokensValue](../src/Bct.Common.Licensing.Contract/Commands/SetAvailableTokensValue.cs)|Sets the available tokens value of a ``TokenLicense`` entity.|
|[SetIsEnabledValue](../src/Bct.Common.Licensing.Contract/Commands/SetIsEnabledValue.cs)|Sets the IsEnabled value of a ``FeatureLicense`` in the system.|
|[SetMaximumAllocationsValue](../src/Bct.Common.Licensing.Contract/Commands/SetMaximumAllocationsValue.cs)|Sets the maximum number of allocations of a ``DeviceLicense`` in the system.|
|[SetTokenGracePeriod](../src/Bct.Common.Licensing.Contract/Commands/SetTokenGracePeriod.cs).|Sets the time in days that a grace period may last as well as maximum token value that can be used during grace period.|