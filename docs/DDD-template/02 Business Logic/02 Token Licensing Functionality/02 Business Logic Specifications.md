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