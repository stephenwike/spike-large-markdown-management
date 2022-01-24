<summary>🛎️Significant Classes</summary>

|Class Name|Class Description|
|--|--|
|[**LicenseErrorItem**](../src/Bct.Common.Licensing.Contract/Responses/LicenseErrorItem.cs)|Main Class used for providing consumers with ability to debug errors that are occurring in the system. It contains a reference to ``LicenseErrorType`` enum, the ``Source`` which explains which field caused the ``LicenseErrorType`` as well as an optional ``Payload`` which can include advanced debugging information.|
|[**LicenseErrorType**](../src/Bct.Common.Licensing.Contract/Enums/LicenseErrorType.cs)|Enumeration used to indicate what error type occurred in the system. The error types are in a human-readable format to quickly pin-point the nature of the error.|
|[**LicenseType**](../src/Bct.Common.Licensing.Contract/Constants/LicenseType.cs)|Enumeration describing the LicenseType of any given license.|
|[**RestRoutes**](../src/Bct.Common.Licensing.Contract/Constants/RestRoutes.cs)|Constants that define the set of defined licensing service REST routes.|
