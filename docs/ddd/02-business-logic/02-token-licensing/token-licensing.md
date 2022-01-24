<details id="token-licensing-details">
<summary style="font-size: 1.3em">Token Licensing related functionality</summary>

<details id="token-class-overview">
<summary style="font-size: 1.1em">Class Overview</summary>

<details id="token-validators">
<summary>Validators</summary>

|Validator Name|Description|
|--|--|
|[**BaseValidator**](../src/Bct.Common.Licensing.Business/Validators/DeviceLicense/BaseValidator.cs)|The base validator class with common rules that are used in other validators.|
|[AddTokensValidator](../src/Bct.Common.Licensing.Business/Validators/TokenLicenseValidators/AddTokensValidator.cs)|Used to validate whether the ``AddTokens`` command can be executed.|
|[ConsumeTokensValidator](../src/Bct.Common.Licensing.Business/Validators/TokenLicenseValidators/ConsumeTokensValidator.cs)|Used to validate whether the ``ConsumeTokens`` command can be executed.|
|[CreateTokenLicenseValidator](../src/Bct.Common.Licensing.Business/Validators/TokenLicenseValidators/CreateTokenLicenseValidator.cs)|Used to validate whether the ``CreateTokenLicense`` command can be executed.|
</details>

<details id="token-managers">
<summary>Managers
</summary>

|Manager Name|Description|
|--|--|
|[AddTokensManager](../src/Bct.Common.Licensing.Business/Managers/TokenLicense/AddTokensManager.cs)|Contains the business logic for the ``AddTokensHandler``.|
|[ConsumeTokensManager](../src/Bct.Common.Licensing.Business/Managers/TokenLicense/ConsumeTokensManager.cs)|Contains the business logic for the ``ConsumeTokensHandler``.|
|[CreateTokenLicenseManager](../src/Bct.Common.Licensing.Business/Managers/TokenLicense/CreateTokenLicenseManager.cs)|Contains the business logic for the ``CreateTokenLicenseHandler``.|
|[GetTokenLicenseByIdManager](../src/Bct.Common.Licensing.Business/Managers/TokenLicenseManagers/GetTokenLicenseByIdManager.cs)|Contains the business logic for the ``GetTokenLicenseByIdHandler`` handler.|
|[GetTokenLicensesManager](../src/Bct.Common.Licensing.Business/Managers/TokenLicenseManagers/GetTokenLicensesManager.cs)|Contains the business logic for the ``GetTokenLicensesByFilterHandler`` and ``GetAllTokenLicensesHandler`` handlers.|
</details>

<details id="token-handlers">
<summary>Handlers</summary>

|Handler Name|Description|
|--|--|
|[CreateTokenLicenseHandler](../src/Bct.Common.Licensing.Business/Handlers/TokenLicense/CreateTokenLicenseHandler.cs)|Handles the command ``CreateTokenLicense`` in the system.|
</details>

</details> <!-- Closes Class Overview -->

<details id="token-business-overview">
<summary style="font-size: 1.1em">Business Logic Specifications</summary>

## Creating a Token License

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

## Consume Tokens (no grace period)

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

## Consume Tokens (grace period)


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
</details> <!-- Closes Business Specifications -->

</details> <!-- Closes Token Licensing Related functionality -->

