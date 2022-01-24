Detailed Design Document for BCT Common Licensing
=================================================

This document describes the Design and Implementation of the BCT Common
Licensing Subsystem.

## Domain

The Common Licensing Subsystem exposes its Domain for consumers to use through means of a Contract.

<details>
<|01-domain\01-entities\entities.md|>
</details>

<details>
<|01-domain\02-commands\commands.md|>
</details>

<details>
<|01-domain\03-events\events.md|>
</details>

<details>
<|01-domain\04-queries\queries.md|>
</details>

<details>
<|01-domain\05-responses\responses.md|>
</details>

<details>
<|01-domain\06-significant-classes\significant-classes.md|>
</details>

## Business Logic

<!---------------------------------------------------------------------------------
                Feature License Related Functionality
----------------------------------------------------------------------------------->

<details>
<summary style="font-size: 1.3em";>Device Licensing related functionality</summary>

<details id="class-overview">
<summary style="font-size: 1.1em">Class Overview</summary>

<details id="device-validators">
<|02-business-logic\01-device-licensing\01-class-overview\01-validators\validators.md|>
</details>

<details id="device-managers">
<|02-business-logic\01-device-licensing\01-class-overview\02-managers\managers.md|>
</details>

<details id="device-handlers">
<|02-business-logic\01-device-licensing\01-class-overview\03-handlers\handlers.md|>
</details>

</details><!--This closes class overview details-->

<details id="Business Logic Specifications">
<|02-business-logic\01-device-licensing\02-logic-specifications\logic-specifications.md|>
</details>

</details><!--This closes device licensing related functionality details-->

<!---------------------------------------------------------------------------------
                Token License Related Functionality
----------------------------------------------------------------------------------->

<details>
<summary style="font-size: 1.3em";>Device Licensing related functionality</summary>

<details id="class-overview">
<summary style="font-size: 1.1em">Class Overview</summary>

<details id="device-validators">
<|02-business-logic\02-token-licensing\01-class-overview\01-validators\validators.md|>
</details>

<details id="device-managers">
<|02-business-logic\02-token-licensing\01-class-overview\02-managers\managers.md|>
</details>

<details id="device-handlers">
<|02-business-logic\02-token-licensing\01-class-overview\03-handlers\handlers.md|>
</details>

</details><!--This closes class overview details-->

<details id="Business Logic Specifications">
<|02-business-logic\02-token-licensing\02-logic-specifications\logic-specifications.md|>
</details>

</details><!--This closes device licensing related functionality details-->
