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