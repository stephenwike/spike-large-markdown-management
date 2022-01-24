<summary>⚡Events</summary>

|Event Name|Description|
|--|--|
|[AvailableTokensValueUpdated](../src/Bct.Common.Licensing.Contract/Events/AvailableTokensValueUpdated.cs)|The system emits this event when the Available Tokens value of a ``TokenLicense`` is updated.|
|[**BaseLicensingEvent**](../src/Bct.Common.Licensing.Contract/Events/BaseLicensingEvent.cs)|Base Event inherited by all events in the Contract.|
|[DeviceLicenseCreated](../src/Bct.Common.Licensing.Contract/Events/DeviceLicenseCreated.cs)|The system emits this event when a new ``DeviceLicense`` is created.|
|[FeatureLicenseCreated](../src/Bct.Common.Licensing.Contract/Events/FeatureLicenseCreated.cs)|The system emits this event when a new ``FeatureLicense`` is created.|
|[IsEnabledValueUpdated](../src/Bct.Common.Licensing.Contract/Events/IsEnabledValueUpdated.cs)|The system emits this event when the value of ``IsEnabled`` of a ``FeatureLicense`` changes.|
|[LicenseAllocatedToDevice](../src/Bct.Common.Licensing.Contract/Events/LicenseAllocatedToDevice.cs)|The system emits this event when a new ``DeviceLicenseAllocation`` is created in the system.|
|[LicenseDeallocatedFromDevice](../src/Bct.Common.Licensing.Contract/Events/LicenseDeallocatedFromDevice.cs)|The system emits this event when an allocation is removed from a ``DeviceLicense`` and subsequently a ``DeviceLicenseAllocation`` is closed.|
|[LicenseDeleted](../src/Bct.Common.Licensing.Contract/Events/LicenseDeleted.cs)|The system emits this event when any ``BaseLicense`` is deleted.|
|[MaximumAllocationValueUpdated](../src/Bct.Common.Licensing.Contract/Events/MaximumAllocationValueUpdated.cs)|The system emits this event when the ``MaximumAllocations`` value of a ``DeviceLicense`` is updated.|
|[TokenLicenseCreated](../src/Bct.Common.Licensing.Contract/Events/TokenLicenseCreated.cs)|The system emits this event when a new ``TokenLicense`` is created.|
|[TokensConsumed](../src/Bct.Common.Licensing.Contract/Events/TokensConsumed.cs)|The system emits this event when tokens were consumed from a ``TokenLicense``.|
|[TokenGracePeriodCreated](../src/Bct.Common.Licensing.Contract/Events/TokenGracePeriodCreated.cs)|The system emits this event when a Grace Period was created for a ``TokenLicense``.|
