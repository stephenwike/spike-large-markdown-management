<details>
<summary style="font-size: 1.3em";>Device Licensing related functionality</summary>

<details id="class-overview">
<summary style="font-size: 1.1em">Class Overview</summary>

<details id="device-validators">
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
</details>

<details id="device-managers">
<summary>Managers
</summary>

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


</details><!-- This closes the Class Overview tab.-->

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

</details> <!-- This closes the Business Logic Specifications tab. -->

</details><!-- This closes the Device Licensing related functionality tab. -->