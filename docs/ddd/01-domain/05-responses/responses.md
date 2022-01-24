<summary>➡️Responses</summary>

|Response Name|Responds to Command|Description|
|--|--|--|
|[**BaseResponse**](../src/Bct.Common.Licensing.Contract/Messages/BaseResponse.cs)|``ConsumeTokens``, ``DeleteLicense``, ``DeallocateLicenseFromDevice``, ``SetAvailableTokensValue``, ``SetIsEnabledValue``, ``SetMaximumAllocationsValue``|All responses inherit this Base Response. Contains the status of the operation and any errors that this operation incurred while being processed by the system in an unsuccessful scenario.|
|[CreateLicenseResponse](../src/Bct.Common.Licensing.Contract/Messages/CreateLicenseResponse.cs)|``CreateDeviceLicense``, ``CreateTokenLicense``, ``CreateFeatureLicense``|Contains the ID of the created license in the system.|
|[AllocateLicenseToDeviceResponse](../src/Bct.Common.Licensing.Contract/Messages/AllocateLicenseToDeviceResponse.cs)|``AllocateLicenseToDevice``|Contains the ID of the created ``DeviceLicenseAllocation`` in the system.|
|[GetDeviceLicensesResponse](../src/Bct.Common.Licensing.Contract/Messages/GetDeviceLicensesResponse.cs)|``GetDeviceLicenses``|Contains a List of queried device licenses.|
