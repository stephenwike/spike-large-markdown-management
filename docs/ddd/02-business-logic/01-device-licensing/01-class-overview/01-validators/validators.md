<summary>Validators</summary>

|Validator Name|Description|
|--|--|
|[**BaseValidator**](../src/Bct.Common.Licensing.Business/Validators/DeviceLicense/BaseValidator.cs)|The base validator class with common rules that are used in other validators.|
|[**BaseCreateLicenseValidator**](../src/Bct.Common.Licensing.Business/Validators/DeviceLicense/BaseCreateLicenseValidator.cs)|The base validator class for CreateLicense validators.|
|[**BaseQueryValidator**](../src/Bct.Common.Licensing.Business/Validators/BaseQueryValidator.cs)| Inherits from the ``BaseValidator`` and is used to validate all the ``GetAll`` and ``GetByFilter`` queries.|
|[GetByIdValidator](../src/Bct.Common.Licensing.Business/Validators/GetByIdValidator.cs)|Inherits from ``BaseQueryValidator`` and is used to validate all the ``GeyById`` queries, including ``GetDeviceLicenseById``, ``GetTokenLicenseById``, and ``GetFeatureLicenseById``.|
|[AllocateLicenseToDeviceValidator](../src/Bct.Common.Licensing.Business/Validators/DeviceLicenseValidators/AllocateLicenseToDeviceValidator.cs)|Used to validate whether the ``AllocateLicenseToDevice`` command can be executed.|
|[CreateDeviceLicenseValidator](../src/Bct.Common.Licensing.Business/Validators/DeviceLicenseValidators/CreateDeviceLicenseValidator.cs)|Used to validate whether the ``CreateDeviceLicense`` command can be executed.|
|[DeallocateLicenseFromDeviceValidator](../src/Bct.Common.Licensing.Business/Validators/DeviceLicenseValidators/DeallocateLicenseFromDeviceValidator.cs)|Used to validate whether the ``DeallocateLicenseFromDevice`` command can be executed.|
|[DeleteLicenseValidator](../src/Bct.Common.Licensing.Business/Validators/DeviceLicenseValidators/DeleteLicenseValidator.cs)|Used to validate whether the ``DeleteLicense`` command can be executed.|
|[SetMaximumAllocationsValidator](../src/Bct.Common.Licensing.Business/Validators/DeviceLicenseValidators/SetMaximumAllocationsValidator.cs)|Used to validate whether the ``SetMaximumAllocationsValue`` command can be executed.|
