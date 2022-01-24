Detailed Design Document for BCT Common Licensing
=================================================

This document describes the Design and Implementation of the BCT Common
Licensing Subsystem.

Domain
------

The Common Licensing Subsystem exposes its Domain for consumers to use
through means of a Contract.

<details>

<summary>🧱Entities</summary>

  -----------------------------------------------------------------------------------------------------------------------------------------
  Entity Name                                                                                           Description
  ----------------------------------------------------------------------------------------------------- -----------------------------------
  [**BaseLicense**](../src/Bct.Common.Licensing.Contract/Entities/BaseLicense.cs)                       Base class inherited by the
                                                                                                        following entities:
                                                                                                        `DeviceLicense`, `FeatureLicense`
                                                                                                        and `TokenLicense`

  [DeviceLicense](../src/Bct.Common.Licensing.Contract/Entities/DeviceLicense.cs)                       Represents a Device License.

  [FeatureLicense](../src/Bct.Common.Licensing.Contract/Entities/FeatureLicense.cs)                     Represents a Feature License.

  [TokenLicense](../src/Bct.Common.Licensing.Contract/Entities/TokenLicense.cs)                         Represents a Token License.

  [DeviceLicenseAllocation](../src/Bct.Common.Licensing.Contract/Entities/DeviceLicenseAllocation.cs)   Represents allocations of devices
                                                                                                        of a Device License.

  [TokenGracePeriod](../src/Bct.Common.Licensing.Contract/Entities/TokenGracePeriod.cs)                 Represents a grace period on a
                                                                                                        Token License.
  -----------------------------------------------------------------------------------------------------------------------------------------

</details>
<details>

<summary>❗ Commands</summary>

  -------------------------------------------------------------------------------------------------------------------------------------------------
  Command Name                                                                                                  Description
  ------------------------------------------------------------------------------------------------------------- -----------------------------------
  [AllocateLicenseToDevice](../src/Bct.Common.Licensing.Contract/Commands/AllocateLicenseToDevice.cs)           Attempts to create a
                                                                                                                `DeviceLicenseAllocation`,
                                                                                                                consuming allocations from a
                                                                                                                `DeviceLicense`.

  [**BaseCommand**](../src/Bct.Common.Licensing.Contract/Commands/BaseCommand.cs)                               Base Command inherited by all
                                                                                                                commands in the Contract.

  [**BaseCreateLicenseCommand**](../src/Bct.Common.Licensing.Contract/Commands/BaseLicenseCreationCommand.cs)   Base Command inherited by the
                                                                                                                following commands:
                                                                                                                `CreateDeviceLicense`,
                                                                                                                `CreateTokenLicense` and
                                                                                                                `CreateTokenLicense`.

  [ConsumeTokens](../src/Bct.Common.Licensing.Contract/Commands/ConsumeTokens.cs)                               Consumes Tokens from a
                                                                                                                `TokenLicense`.

  [CreateDeviceLicense](../src/Bct.Common.Licensing.Contract/Commands/CreateDeviceLicense.cs)                   Creates a `DeviceLicense` in the
                                                                                                                system.

  [CreateFeatureLicense](../src/Bct.Common.Licensing.Contract/Commands/CreateFeatureLicense.cs)                 Creates a `FeatureLicense` in the
                                                                                                                system.

  [CreateTokenLicense](../src/Bct.Common.Licensing.Contract/Commands/CreateTokenLicense.cs)                     Creates a `TokenLicense` in the
                                                                                                                system.

  [DeleteLicense](../src/Bct.Common.Licensing.Contract/Commands/DeleteLicense.cs)                               Deletes any license from the
                                                                                                                system.

  [SetAvailableTokensValue](../src/Bct.Common.Licensing.Contract/Commands/SetAvailableTokensValue.cs)           Sets the available tokens value of
                                                                                                                a `TokenLicense` entity.

  [SetIsEnabledValue](../src/Bct.Common.Licensing.Contract/Commands/SetIsEnabledValue.cs)                       Sets the IsEnabled value of a
                                                                                                                `FeatureLicense` in the system.

  [SetMaximumAllocationsValue](../src/Bct.Common.Licensing.Contract/Commands/SetMaximumAllocationsValue.cs)     Sets the maximum number of
                                                                                                                allocations of a `DeviceLicense` in
                                                                                                                the system.

  [SetTokenGracePeriod](../src/Bct.Common.Licensing.Contract/Commands/SetTokenGracePeriod.cs).                  Sets the time in days that a grace
                                                                                                                period may last as well as maximum
                                                                                                                token value that can be used during
                                                                                                                grace period.
  -------------------------------------------------------------------------------------------------------------------------------------------------

</details>
<details>

<summary>⚡Events</summary>

  ---------------------------------------------------------------------------------------------------------------------------------------------------
  Event Name                                                                                                      Description
  --------------------------------------------------------------------------------------------------------------- -----------------------------------
  [AvailableTokensValueUpdated](../src/Bct.Common.Licensing.Contract/Events/AvailableTokensValueUpdated.cs)       The system emits this event when
                                                                                                                  the Available Tokens value of a
                                                                                                                  `TokenLicense` is updated.

  [**BaseLicensingEvent**](../src/Bct.Common.Licensing.Contract/Events/BaseLicensingEvent.cs)                     Base Event inherited by all events
                                                                                                                  in the Contract.

  [DeviceLicenseCreated](../src/Bct.Common.Licensing.Contract/Events/DeviceLicenseCreated.cs)                     The system emits this event when a
                                                                                                                  new `DeviceLicense` is created.

  [FeatureLicenseCreated](../src/Bct.Common.Licensing.Contract/Events/FeatureLicenseCreated.cs)                   The system emits this event when a
                                                                                                                  new `FeatureLicense` is created.

  [IsEnabledValueUpdated](../src/Bct.Common.Licensing.Contract/Events/IsEnabledValueUpdated.cs)                   The system emits this event when
                                                                                                                  the value of `IsEnabled` of a
                                                                                                                  `FeatureLicense` changes.

  [LicenseAllocatedToDevice](../src/Bct.Common.Licensing.Contract/Events/LicenseAllocatedToDevice.cs)             The system emits this event when a
                                                                                                                  new `DeviceLicenseAllocation` is
                                                                                                                  created in the system.

  [LicenseDeallocatedFromDevice](../src/Bct.Common.Licensing.Contract/Events/LicenseDeallocatedFromDevice.cs)     The system emits this event when an
                                                                                                                  allocation is removed from a
                                                                                                                  `DeviceLicense` and subsequently a
                                                                                                                  `DeviceLicenseAllocation` is
                                                                                                                  closed.

  [LicenseDeleted](../src/Bct.Common.Licensing.Contract/Events/LicenseDeleted.cs)                                 The system emits this event when
                                                                                                                  any `BaseLicense` is deleted.

  [MaximumAllocationValueUpdated](../src/Bct.Common.Licensing.Contract/Events/MaximumAllocationValueUpdated.cs)   The system emits this event when
                                                                                                                  the `MaximumAllocations` value of a
                                                                                                                  `DeviceLicense` is updated.

  [TokenLicenseCreated](../src/Bct.Common.Licensing.Contract/Events/TokenLicenseCreated.cs)                       The system emits this event when a
                                                                                                                  new `TokenLicense` is created.

  [TokensConsumed](../src/Bct.Common.Licensing.Contract/Events/TokensConsumed.cs)                                 The system emits this event when
                                                                                                                  tokens were consumed from a
                                                                                                                  `TokenLicense`.

  [TokenGracePeriodCreated](../src/Bct.Common.Licensing.Contract/Events/TokenGracePeriodCreated.cs)               The system emits this event when a
                                                                                                                  Grace Period was created for a
                                                                                                                  `TokenLicense`.
  ---------------------------------------------------------------------------------------------------------------------------------------------------

</details>
<details>

<summary>❓Queries</summary>

  --------------------------------------------------------------------------------------------------------------------------------------------------------
  Query Name                                                                                                           Description
  -------------------------------------------------------------------------------------------------------------------- -----------------------------------
  [**BaseQuery**](../src/Bct.Common.Licensing.Contract/Queries/BaseQuery.cs)                                           Base Query inherited by all queries
                                                                                                                       in the Contract.

  [GetAllDeviceLicenses](../src/Bct.Common.Licensing.Contract/Queries/GetAllDeviceLicenses.cs)                         Gets all not-deleted
                                                                                                                       `DeviceLicense`.

  [GetDeviceLicensesByFilter](../src/Bct.Common.Licensing.Contract/Queries/GetDeviceLicensesByFilter.cs)               Gets all not-deleted
                                                                                                                       `DeviceLicense` by specific
                                                                                                                       filters.

  [GetDeviceLicenseById](../src/Bct.Common.Licensing.Contract/Queries/GetDeviceLicenseById.cs)                         Gets not-deleted `DeviceLicense` by
                                                                                                                       id.

  [GetDeviceAllocationsByLicenseId](../src/Bct.Common.Licensing.Contract/Queries/GetDeviceAllocationsByLicenseId.cs)   Gets all non-released (default)
                                                                                                                       `DeviceLicenseAllocation` of a
                                                                                                                       `DeviceLicense`.

  [GetAllFeatureLicenses](../src/Bct.Common.Licensing.Contract/Queries/GetAllFeatureLicenses.cs)                       Gets all not-deleted
                                                                                                                       `FeatureLicense`.

  [GetFeatureLicensesByFilter](../src/Bct.Common.Licensing.Contract/Queries/GetFeatureLicensesByFilter.cs)             Gets all not-deleted
                                                                                                                       `FeatureLicense` by specific
                                                                                                                       filters.

  [GetAllTokenLicenses](../src/Bct.Common.Licensing.Contract/Queries/GetAllTokenLicenses.cs)                           Gets all not-deleted
                                                                                                                       `TokenLicense`.

  [GetTokenLicensesByFilter](../src/Bct.Common.Licensing.Contract/Queries/GetTokenLicensesByFilter.cs)                 Gets all not-deleted `TokenLicense`
                                                                                                                       by specific filters.
  --------------------------------------------------------------------------------------------------------------------------------------------------------

</details>
<details>

<summary>➡️Responses</summary>

  ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
  Response Name                                                                                                         Responds to Command              Description
  --------------------------------------------------------------------------------------------------------------------- -------------------------------- ---------------------------
  [**BaseResponse**](../src/Bct.Common.Licensing.Contract/Messages/BaseResponse.cs)                                     `ConsumeTokens`,                 All responses inherit this
                                                                                                                        `DeleteLicense`,                 Base Response. Contains the
                                                                                                                        `DeallocateLicenseFromDevice`,   status of the operation and
                                                                                                                        `SetAvailableTokensValue`,       any errors that this
                                                                                                                        `SetIsEnabledValue`,             operation incurred while
                                                                                                                        `SetMaximumAllocationsValue`     being processed by the
                                                                                                                                                         system in an unsuccessful
                                                                                                                                                         scenario.

  [CreateLicenseResponse](../src/Bct.Common.Licensing.Contract/Messages/CreateLicenseResponse.cs)                       `CreateDeviceLicense`,           Contains the ID of the
                                                                                                                        `CreateTokenLicense`,            created license in the
                                                                                                                        `CreateFeatureLicense`           system.

  [AllocateLicenseToDeviceResponse](../src/Bct.Common.Licensing.Contract/Messages/AllocateLicenseToDeviceResponse.cs)   `AllocateLicenseToDevice`        Contains the ID of the
                                                                                                                                                         created
                                                                                                                                                         `DeviceLicenseAllocation`
                                                                                                                                                         in the system.

  [GetDeviceLicensesResponse](../src/Bct.Common.Licensing.Contract/Messages/GetDeviceLicensesResponse.cs)               `GetDeviceLicenses`              Contains a List of queried
                                                                                                                                                         device licenses.
  ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

</details>
<details>

<summary>🛎️Significant Classes</summary>

  --------------------------------------------------------------------------------------------------------------------------------
  Class Name                                                                                   Class Description
  -------------------------------------------------------------------------------------------- -----------------------------------
  [**LicenseErrorItem**](../src/Bct.Common.Licensing.Contract/Responses/LicenseErrorItem.cs)   Main Class used for providing
                                                                                               consumers with ability to debug
                                                                                               errors that are occurring in the
                                                                                               system. It contains a reference to
                                                                                               `LicenseErrorType` enum, the
                                                                                               `Source` which explains which field
                                                                                               caused the `LicenseErrorType` as
                                                                                               well as an optional `Payload` which
                                                                                               can include advanced debugging
                                                                                               information.

  [**LicenseErrorType**](../src/Bct.Common.Licensing.Contract/Enums/LicenseErrorType.cs)       Enumeration used to indicate what
                                                                                               error type occurred in the system.
                                                                                               The error types are in a
                                                                                               human-readable format to quickly
                                                                                               pin-point the nature of the error.

  [**LicenseType**](../src/Bct.Common.Licensing.Contract/Constants/LicenseType.cs)             Enumeration describing the
                                                                                               LicenseType of any given license.

  [**RestRoutes**](../src/Bct.Common.Licensing.Contract/Constants/RestRoutes.cs)               Constants that define the set of
                                                                                               defined licensing service REST
                                                                                               routes.
  --------------------------------------------------------------------------------------------------------------------------------

</details>
