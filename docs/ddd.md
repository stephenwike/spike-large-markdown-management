Detailed Design Document for BCT Common Licensing
=================================================

This document describes the Design and Implementation of the BCT Common
Licensing Subsystem.

## Domain

The Common Licensing Subsystem exposes its Domain for consumers to use through means of a Contract.

<details>
<summary>🧱Entities</summary>

|Entity Name|Description|
|--|--|
|[**BaseLicense**](../src/Bct.Common.Licensing.Contract/Entities/BaseLicense.cs)|Base class inherited by the following entities: ``DeviceLicense``, ``FeatureLicense`` and ``TokenLicense``|
|[DeviceLicense](../src/Bct.Common.Licensing.Contract/Entities/DeviceLicense.cs)|Represents a Device License.|
|[FeatureLicense](../src/Bct.Common.Licensing.Contract/Entities/FeatureLicense.cs)|Represents a Feature License.|
|[TokenLicense](../src/Bct.Common.Licensing.Contract/Entities/TokenLicense.cs)|Represents a Token License.
|[DeviceLicenseAllocation](../src/Bct.Common.Licensing.Contract/Entities/DeviceLicenseAllocation.cs)|Represents allocations of devices of a Device License.|
|[TokenGracePeriod](../src/Bct.Common.Licensing.Contract/Entities/TokenGracePeriod.cs)|Represents a grace period on a Token License.|

</details>

<details>
<summary>❗ Commands</summary>

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

</details>

<details>
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

</details>

<details>
<summary>❓Queries</summary>

|Query Name|Description|
|--|--|
|[**BaseQuery**](../src/Bct.Common.Licensing.Contract/Queries/BaseQuery.cs)|Base Query inherited by all queries in the Contract.|
|[GetAllDeviceLicenses](../src/Bct.Common.Licensing.Contract/Queries/GetAllDeviceLicenses.cs)|Gets all not-deleted ``DeviceLicense``.|
|[GetDeviceLicensesByFilter](../src/Bct.Common.Licensing.Contract/Queries/GetDeviceLicensesByFilter.cs)|Gets all not-deleted ``DeviceLicense`` by specific filters.|
|[GetDeviceLicenseById](../src/Bct.Common.Licensing.Contract/Queries/GetDeviceLicenseById.cs)|Gets not-deleted ``DeviceLicense`` by id.|
|[GetDeviceAllocationsByLicenseId](../src/Bct.Common.Licensing.Contract/Queries/GetDeviceAllocationsByLicenseId.cs)|Gets all non-released (default) `DeviceLicenseAllocation` of a ``DeviceLicense``.|
|[GetAllFeatureLicenses](../src/Bct.Common.Licensing.Contract/Queries/GetAllFeatureLicenses.cs)|Gets all not-deleted ``FeatureLicense``.|
|[GetFeatureLicensesByFilter](../src/Bct.Common.Licensing.Contract/Queries/GetFeatureLicensesByFilter.cs)|Gets all not-deleted ``FeatureLicense`` by specific filters.|
|[GetAllTokenLicenses](../src/Bct.Common.Licensing.Contract/Queries/GetAllTokenLicenses.cs)|Gets all not-deleted ``TokenLicense``.|
|[GetTokenLicensesByFilter](../src/Bct.Common.Licensing.Contract/Queries/GetTokenLicensesByFilter.cs)|Gets all not-deleted ``TokenLicense`` by specific filters.

</details>

<details>
<summary>➡️Responses</summary>

|Response Name|Responds to Command|Description|
|--|--|--|
|[**BaseResponse**](../src/Bct.Common.Licensing.Contract/Messages/BaseResponse.cs)|``ConsumeTokens``, ``DeleteLicense``, ``DeallocateLicenseFromDevice``, ``SetAvailableTokensValue``, ``SetIsEnabledValue``, ``SetMaximumAllocationsValue``|All responses inherit this Base Response. Contains the status of the operation and any errors that this operation incurred while being processed by the system in an unsuccessful scenario.|
|[CreateLicenseResponse](../src/Bct.Common.Licensing.Contract/Messages/CreateLicenseResponse.cs)|``CreateDeviceLicense``, ``CreateTokenLicense``, ``CreateFeatureLicense``|Contains the ID of the created license in the system.|
|[AllocateLicenseToDeviceResponse](../src/Bct.Common.Licensing.Contract/Messages/AllocateLicenseToDeviceResponse.cs)|``AllocateLicenseToDevice``|Contains the ID of the created ``DeviceLicenseAllocation`` in the system.|
|[GetDeviceLicensesResponse](../src/Bct.Common.Licensing.Contract/Messages/GetDeviceLicensesResponse.cs)|``GetDeviceLicenses``|Contains a List of queried device licenses.|

</details>

<details>
<summary>🛎️Significant Classes</summary>

|Class Name|Class Description|
|--|--|
|[**LicenseErrorItem**](../src/Bct.Common.Licensing.Contract/Responses/LicenseErrorItem.cs)|Main Class used for providing consumers with ability to debug errors that are occurring in the system. It contains a reference to ``LicenseErrorType`` enum, the ``Source`` which explains which field caused the ``LicenseErrorType`` as well as an optional ``Payload`` which can include advanced debugging information.|
|[**LicenseErrorType**](../src/Bct.Common.Licensing.Contract/Enums/LicenseErrorType.cs)|Enumeration used to indicate what error type occurred in the system. The error types are in a human-readable format to quickly pin-point the nature of the error.|
|[**LicenseType**](../src/Bct.Common.Licensing.Contract/Constants/LicenseType.cs)|Enumeration describing the LicenseType of any given license.|
|[**RestRoutes**](../src/Bct.Common.Licensing.Contract/Constants/RestRoutes.cs)|Constants that define the set of defined licensing service REST routes.|

</details>

## Business Logic

<!---------------------------------------------------------------------------------
                Feature License Related Functionality
----------------------------------------------------------------------------------->

<details>
<summary style="font-size: 1.3em";>Device Licensing related functionality</summary><blockquote>

<details id="class-overview">
<summary style="font-size: 1.1em">Class Overview</summary><blockquote>

<details id="device-validators"><blockquote>
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

</blockquote></details>

<details id="device-managers">
<summary>Managers</summary>

|Manager Name|Description|
|--|--|
|[AllocateLicenseManager](../src/Bct.Common.Licensing.Business/Managers/DeviceLicenseManagers/DeviceLicenseManager.cs)|Contains the business logic for the ``AllocateLicenseToDeviceHandler``. 
|[CreateLicenseManager](../src/Bct.Common.Licensing.Business/Managers/DeviceLicenseManagers/CreateLicenseManager.cs)|Contains the business logic for the ``CreateDeviceLicenseHandler``. 
|[DeallocateLicenseManager](../src/Bct.Common.Licensing.Business/Managers/DeviceLicenseManagers/DeallocateLicenseManager.cs)|Contains the business logic for the ``DeallocateLicenseFromDeviceHandler``. 
|[DeleteLicenseManager](../src/Bct.Common.Licensing.Business/Managers/DeviceLicenseManagers/DeleteLicenseManager.cs)|Contains the business logic for the ``DeleteLicenseHandler`` handler. 
|[GetDeviceLicenseByIdManager](../src/Bct.Common.Licensing.Business/Managers/DeviceLicenseManagers/GetDeviceLicenseByIdManager.cs)|Contains the business logic for the ``GetDeviceLicenseByIdHandler`` handler. 
|[GetDeviceLicensesManager](../src/Bct.Common.Licensing.Business/Managers/DeviceLicenseManagers/GetDeviceLicensesManager.cs)|Contains the business logic for the ``GetDeviceLicensesByFilterHandler`` and ``GetAllDeviceLicensesHandler`` handlers. 
|[SetMaximumAllocationsManager](../src/Bct.Common.Licensing.Business/Managers/DeviceLicenseManagers/SetMaximumAllocationsManager.cs)|Contains the business logic for the ``SetMaximumAllocationsValueHandler`` handler.

</details>

<details id="device-handlers">
<summary>Handlers</summary>

|Handler Name|Description|
|--|--|
|[AllocateLicenseToDeviceHandler](../src/Bct.Common.Licensing.Business/Handlers/DeviceLicense/AllocateLicenseToDeviceHandler.cs)|Handles the command ``AllocateLicenseToDevice`` in the system.|
|[CreateDeviceLicenseHandler](../src/Bct.Common.Licensing.Business/Handlers/DeviceLicense/CreateDeviceLicenseHandler.cs)|Handles the command ``CreateDeviceLicense`` in the system.|
|[DeallocateLicenseFromDeviceHandler](../src/Bct.Common.Licensing.Business/Handlers/DeviceLicense/DeallocateLicenseFromDeviceHandler.cs)|Handles the command ``DeallocateLicenseFromDevice`` in the system.|
|[DeleteLicenseHandler](../src/Bct.Common.Licensing.Business/Handlers/DeviceLicense/DeleteLicenseHandler.cs)|Handles the ``DeleteLicense`` command.|
|[SetMaximumAllocationsValueHandler](../src/Bct.Common.Licensing.Business/Handlers/DeviceLicense/SetMaximumAllocationsValueHandler.cs)|Handles the command ``SetMaximumAllocationsValue`` in the system.|
|[GetAllDeviceLicensesHandler](../src/Bct.Common.Licensing.Business/Handlers/DeviceLicense/GetAllDeviceLicensesHandler.cs)|Handles the query ``GetAllDeviceLicenses`` in the system.|
|[GetDeviceLicensesByFilterHandler](../src/Bct.Common.Licensing.Business/Handlers/DeviceLicense/GetDeviceLicensesByFilterHandler.cs)|Handles the query ``GetDeviceLicensesByFilter`` in the system.|

</details>

</blockquote></details><!--This closes class overview details-->

<details id="Business Logic Specifications">
<summary style="font-size: 1.1em">Specifications</summary>

### Creating Device License

<!-- MARKDOWN-AUTO-DOCS:START (CODE:src=./spec/CreateDeviceLicense.spec) -->
<!-- The below code snippet is automatically added from ./spec/CreateDeviceLicense.spec -->
```spec
Feature: Create Device License

--------------------------------------------------------------------
Scenario: Create non-trial device license in the Licensing system
--------------------------------------------------------------------
When
    CreateLicense request is received

Given
    TenantId is not null or empty
    and Tenant exists in system
    and LicenseType is not null or empty
    and DeviceType is not null or empty
    and ExpiryDateUtc is not in the past
    and CurrentAllocations is not greater than MaximumAllocations
    and MaximumAllocations is greater than zero
    and IsTrial is false
    
Then
    The non-trial device license can be created 
    and a DeviceLicenseCreated event is published on the message bus
    and a CreateLicenseResponse including the created license id is returned


--------------------------------------------------------------------
Scenario: Create trial device license in the Licensing system
--------------------------------------------------------------------
When
    CreateLicense request is received

Given
    TenantId is not null or empty and Tenant exists in system
    and LicenseType is not null
    and DeviceType is not null
    and ExpiryDateUtc is not in the past
    and IsTrial is true    

Then
    The trial device license can be created
    and a DeviceLicenseCreated event is published on the message bus
    and a CreateLicenseResponse including the created license id is returned
```
<!-- MARKDOWN-AUTO-DOCS:END -->

![Logic flow executed by the system for device creation.](./drawio/images/CreateDeviceLicense-Page-1.png)

### Allocating a License to Device

<!-- MARKDOWN-AUTO-DOCS:START (CODE:src=./spec/AllocateLicenseToDevice.spec) -->
<!-- The below code snippet is automatically added from ./spec/AllocateLicenseToDevice.spec -->
```spec
Feature: Allocate License To Device

------------------------------------------------------
Scenario: Allocate any non-trial license to device
------------------------------------------------------
Given
    An AllocateLicenseToDevice request is received

When
    TenantId is not null or empty 
    and Tenant Exists in the system
    and allocation id is positive
    and a license with the given id exists
    and license type is Device
    and license is not expired
    and license is not trial
    and CurrentAllocations is less than the MaximumAllocations
    and DeviceUniqueId is not null or empty
    and SerialNumber is not null or empty
    
Then
    License allocated to the device
    and a DeviceAllocation object is created
    and CurrentAllocations is updated
    and a LicenseAllocatedToDevice event is published onto the message bus
    and a AllocateLicenseToDeviceResponse is returned


-------------------------------------------------
Scenario: Allocate any trial license to device
-------------------------------------------------
Given
    An AllocateLicenseToDevice request is received

When
    TenantId is not null or empty 
    and Tenant Exists in the system
    and allocation id is positive
    and a license with the given id exists
    and the license type is Device
    and thr license is not expired
    and DeviceUniqueId is not null or empty
    and SerialNumber is not null or empty
    and the license is trial
    
Then
    License allocated to the device
    and a DeviceAllocation object is created
    and CurrentAllocations is updated
    and a LicenseAllocatedToDevice event is published onto the message bus
    and a AllocateLicenseToDeviceResponse is returned
```
<!-- MARKDOWN-AUTO-DOCS:END -->

![Logic flow executed by the system for allocating a license to device.](./drawio/images/AllocateLicenseToDevice-Page-1.png)

### Deallocating a License from Device

<!-- MARKDOWN-AUTO-DOCS:START (CODE:src=./spec/CreateDeviceLicense.spec) -->
<!-- The below code snippet is automatically added from ./spec/CreateDeviceLicense.spec -->
```spec
Feature: Create Device License

--------------------------------------------------------------------
Scenario: Create non-trial device license in the Licensing system
--------------------------------------------------------------------
When
    CreateLicense request is received

Given
    TenantId is not null or empty
    and Tenant exists in system
    and LicenseType is not null or empty
    and DeviceType is not null or empty
    and ExpiryDateUtc is not in the past
    and CurrentAllocations is not greater than MaximumAllocations
    and MaximumAllocations is greater than zero
    and IsTrial is false
    
Then
    The non-trial device license can be created 
    and a DeviceLicenseCreated event is published on the message bus
    and a CreateLicenseResponse including the created license id is returned


--------------------------------------------------------------------
Scenario: Create trial device license in the Licensing system
--------------------------------------------------------------------
When
    CreateLicense request is received

Given
    TenantId is not null or empty and Tenant exists in system
    and LicenseType is not null
    and DeviceType is not null
    and ExpiryDateUtc is not in the past
    and IsTrial is true    

Then
    The trial device license can be created
    and a DeviceLicenseCreated event is published on the message bus
    and a CreateLicenseResponse including the created license id is returned
```
<!-- MARKDOWN-AUTO-DOCS:END -->

![Logic flow executed by the system for deallocating a license from device.](./drawio/images/DeallocateLicenseFromDevice-Page-1.png)

### Setting a MaximumAllocations value on a Device License

<!-- MARKDOWN-AUTO-DOCS:START (CODE:src=./spec/SetMaximumAllocations.spec) -->
<!-- The below code snippet is automatically added from ./spec/SetMaximumAllocations.spec -->
```spec
Feature: Set MaximumAllocations Value

---------------------------------------------------------
Scenario: Set the MaximumAllocations value of a device license
---------------------------------------------------------
Given
    A SetMaximumAllocationsValue request is received

When
    TenantId is not null or empty 
    and Tenant Exists in the system
    and a DeviceLicense for the given tenantId and licenseId exists in the system
    and the new MaximumAllocationsValue is greater than 0
    and the new MaximumAllocationsValue is not larger than the number of current allocated devices
    and the license is not expired
    
Then
    The the MaximumAllocations value is set to the given value.
    An MaximumAllocationValueUpdated event is published onto the message bus.
    A successful base response is returned.
```
<!-- MARKDOWN-AUTO-DOCS:END -->

![Logic flow executed by the system when setting Maximum Allocations.](./drawio/images/SetMaximumAllocations-Page-1.png)

### Deleting Device License

<!-- MARKDOWN-AUTO-DOCS:START (CODE:src=./spec/DeleteLicense.spec) -->
<!-- The below code snippet is automatically added from ./spec/DeleteLicense.spec -->
```spec
Feature: Delete License

--------------------------------------------------------------------
Scenario: Delete any license in the Licensing system
--------------------------------------------------------------------
When
    DeleteLicense request is received

Given
    TenantId is not null or empty
    and Tenant exists in system
    and LicenseType is not null or empty
    and LicenseId is greater than 0
    and LicenseId exists in system
    
Then
    The license can be deleted 
    and a LicenseDeleted event is published on the message bus
    and a DeleteLicenseResponse including the deleted license id is returned
```
<!-- MARKDOWN-AUTO-DOCS:END -->

![Logic flow executed by the system for deleting a device license.](./drawio/images/DeleteLicense-Page-1.png)
</details>

</blockquote></details><!--This closes device licensing related functionality details-->

<!---------------------------------------------------------------------------------
                Token License Related Functionality
----------------------------------------------------------------------------------->

<details>
<summary style="font-size: 1.3em";>Device Licensing related functionality</summary>

<details id="class-overview">
<summary style="font-size: 1.1em">Class Overview</summary>

<details id="device-validators">
<summary>Validators</summary>

|Validator Name|Description|
|--|--|
|[**BaseValidator**](../src/Bct.Common.Licensing.Business/Validators/DeviceLicense/BaseValidator.cs)|The base validator class with common rules that are used in other validators.|
|[AddTokensValidator](../src/Bct.Common.Licensing.Business/Validators/TokenLicenseValidators/AddTokensValidator.cs)|Used to validate whether the ``AddTokens`` command can be executed.|
|[ConsumeTokensValidator](../src/Bct.Common.Licensing.Business/Validators/TokenLicenseValidators/ConsumeTokensValidator.cs)|Used to validate whether the ``ConsumeTokens`` command can be executed.|
|[CreateTokenLicenseValidator](../src/Bct.Common.Licensing.Business/Validators/TokenLicenseValidators/CreateTokenLicenseValidator.cs)|Used to validate whether the ``CreateTokenLicense`` command can be executed.|

</details>

<details id="device-managers">
<summary>Managers</summary>

|Manager Name|Description|
|--|--|
|[AddTokensManager](../src/Bct.Common.Licensing.Business/Managers/TokenLicense/AddTokensManager.cs)|Contains the business logic for the ``AddTokensHandler``.|
|[ConsumeTokensManager](../src/Bct.Common.Licensing.Business/Managers/TokenLicense/ConsumeTokensManager.cs)|Contains the business logic for the ``ConsumeTokensHandler``.|
|[CreateTokenLicenseManager](../src/Bct.Common.Licensing.Business/Managers/TokenLicense/CreateTokenLicenseManager.cs)|Contains the business logic for the ``CreateTokenLicenseHandler``.|
|[GetTokenLicenseByIdManager](../src/Bct.Common.Licensing.Business/Managers/TokenLicenseManagers/GetTokenLicenseByIdManager.cs)|Contains the business logic for the ``GetTokenLicenseByIdHandler`` handler.|
|[GetTokenLicensesManager](../src/Bct.Common.Licensing.Business/Managers/TokenLicenseManagers/GetTokenLicensesManager.cs)|Contains the business logic for the ``GetTokenLicensesByFilterHandler`` and ``GetAllTokenLicensesHandler`` handlers.|

</details>

<details id="device-handlers">
<summary>Handlers</summary>

|Handler Name|Description|
|--|--|
|[CreateTokenLicenseHandler](../src/Bct.Common.Licensing.Business/Handlers/TokenLicense/CreateTokenLicenseHandler.cs)|Handles the command ``CreateTokenLicense`` in the system.|

</details>

</details><!--This closes class overview details-->

<details id="Business Logic Specifications">
<summary style="font-size: 1.1em">Business Logic Specifications</summary>

### Creating a Token License

<!-- MARKDOWN-AUTO-DOCS:START (CODE:src=./spec/CreateTokenLicense.spec) -->
<!-- The below code snippet is automatically added from ./spec/CreateTokenLicense.spec -->
```spec
Feature:  Create Token Licensing

-----------------------------------------------
Scenario:  Create a non-trial token license
-----------------------------------------------
Given:  A CreateTokenLicense request is received

When:  TenantId is not null or empty
       and Tenant exists in the system
       and LicenseType is Token
       and DeviceType is not null or empty
       and ExpiryDateUtc is not in the past
       and TokenValue is greater than 0
       and IsTrial is false

Then:  The system creates a non-trial TokenLicense 
       and a TokenLicenseCreated event is published onto the message bus
       and a CreateLicenseResponse including the created license id is returned


------------------------------------------
Scenario:  Create a trial token license
------------------------------------------
Given:  A CreateTokenLicense request is received 

When:  TenantId is not null or empty
       and Tenant exists in the system
       and LicenseType is Token
       and DeviceType is not null or empty
       and ExpiryDateUtc is not in the past
       and TokenValue is greater than 0
       and IsTrial is true

Then:  The system creates a non-trial TokenLicense 
       and a TokenLicenseCreated event is published onto the message bus
       and a CreateLicenseResponse including the created license id is returned
```
<!-- MARKDOWN-AUTO-DOCS:END -->

![Creating a token license flow](drawio/images/CreateTokenLicense-Page-1.png)

### Consume Tokens (no grace period)

<!-- MARKDOWN-AUTO-DOCS:START (CODE:src=./spec/ConsumeTokens.spec) -->
<!-- The below code snippet is automatically added from ./spec/ConsumeTokens.spec -->
```spec
Feature: Consume Token License

---------------------------------------------------------
Scenario: Consume tokens of a token license with no grace period
---------------------------------------------------------
Given
    A ConsumeTokens request is received

When
    TenantId is not null or empty 
    and Tenant Exists in the system
    and a TokenLicense for the given tenantId and licenseId exists in the system
    and the TokenLicense is not expired
    and the TokenLicense is not trial
    and ExpiryDate is not passed
    and TokensToBeConsumed is greater than 0
    and TokensToBeConsumed is less than AvailableTokens
    
Then
    The tokens are consumed and deducted from AvailableTokens
    A TokensConsumed event is published onto the message bus
    A success message is returned


---------------------------------------------------------
Scenario: Consume tokens of a token license with grace period - CREATE GRACE PERIOD
---------------------------------------------------------
Given
    A ConsumeTokens request is received

When
    TenantId is not null or empty 
    and Tenant Exists in the system
    and a TokenLicense for the given tenantId and licenseId exists in the system
    and the TokenLicense is not expired
    and the TokenLicense is not trial
    and ExpiryDate is not passed
    and TokensToBeConsumed is greater than 0
    and TokensToBeConsumed is greater than or equal to AvailableTokens
    and GracePeriod does not exist or is not active
    
Then
    The tokens are consumed and deducted from AvailableTokens
    Remaining tokens are added to GracePeriod.TokensConsumed
    A TokensConsumed event is published onto the message bus
    A success message is returned


---------------------------------------------------------
Scenario: Consume tokens of a token license with grace period - UPDATE GRACE PERIOD
---------------------------------------------------------
Given
    A ConsumeTokens request is received

When
    TenantId is not null or empty 
    and Tenant Exists in the system
    and a TokenLicense for the given tenantId and licenseId exists in the system
    and the TokenLicense is not expired
    and the TokenLicense is not trial
    and ExpiryDate is not passed
    and TokensToBeConsumed is greater than 0
    and TokensToBeConsumed is greater than or equal to AvailableTokens
    and GracePeriod is active
    and GracePeriod.ExpiryDateUtc has not passed
    
Then
    Tokens are added to GracePeriod.TokensConsumed
    A TokensConsumed event is published onto the message bus
    A success message is returned


-----------------------------------------------------
Scenario: Consume tokens of a trial token license
-----------------------------------------------------
Given
    A ConsumeTokens request is received

When
    TenantId is not null or empty 
    and Tenant Exists in the system
    and a TokenLicense for the given tenantId and licenseId exists in the system
    and the TokenLicense is not expired
    and the TokenLicense is trial
    and TokensToBeConsumed is greater than 0
    and ExpiryDate is not passed
    
Then
    The tokens are consumed and deducted from the AvailableTokens
    A TokensConsumed event is published onto the message bus
    A success message is returned
```
<!-- MARKDOWN-AUTO-DOCS:END -->

![Consuming tokens](drawio/images/ConsumeTokens-Page-1.png)

### Consume Tokens (grace period)


<!-- MARKDOWN-AUTO-DOCS:START (CODE:src=./spec/ConsumeTokensGracePeriod.spec) -->
<!-- The below code snippet is automatically added from ./spec/ConsumeTokensGracePeriod.spec -->
```spec
Feature: Consume Token License

---------------------------------------------------------
Scenario: Consume tokens of a non-trial token license invoking Grace Period
---------------------------------------------------------
Given
    A ConsumeTokens request is received

When
    TenantId is not null or empty 
    and Tenant Exists in the system
    and a TokenLicense for the given tenantId and licenseId exists in the system
	and the TokenLicense is not expired
    and the TokenLicense is not trial
	and TokensToBeConsumed is greater than 0
	and no GracePeriod exists for TokenLicense
    and (AvailableTokens-TokensToBeConsumed) is less than or equal 0
Then
    A GracePeriod is created in the system for the TokenLicense
		The GracePeriod ExpiryDateUtc is set to the number of TokenGracePeriodDays from Settings.
	AvailableTokens is set to 0
    A TokensConsumed event is published onto the message bus
    A success message is returned


-----------------------------------------------------
Scenario: Consume tokens of a non-trial token license with active Grace Period
-----------------------------------------------------
Given
    A ConsumeTokens request is received

When
    TenantId is not null or empty 
    and Tenant Exists in the system
    and a TokenLicense for the given tenantId and licenseId exists in the system
	and the TokenLicense is not expired
    and the TokenLicense is not trial
	and TokensToBeConsumed is greater than 0
	and GracePeriod exists for TokenLicense
		and GracePeriod ExpiryDateUtc is not in the past
		and GracePeriodTokensConsumed plus TokensToBeConsumed is less than or equal to MaximumTokenConsumption in Settings.
    and TokensToBeConsumed is greater than 0
    and AvailableTokens is less than or equal 0
Then
	The GracePeriodTokensConsumed is increased by the number of tokens from TokensToBeConsumed
    A TokensConsumed event is published onto the message bus
    A success message is returned
```
<!-- MARKDOWN-AUTO-DOCS:END -->

<!-- 
![Consuming tokens](drawio/images/ConsumeTokensGracePeriod-Page-1.png)
-->
</details>

</details><!--This closes device licensing related functionality details-->
