# WAKE — CIM423 Interactive World

Interactive Unity project created for **CIM423: Building Virtual Worlds** at the University of Miami.

## Project Overview

WAKE is an interactive 3D experience that begins in a dark room. The player opens their eyes, interacts with a mirror that transforms into a portal, and enters a city environment.

The experience guides the player through a sequence of interactions involving a bucket, fire hydrant, and a character on fire. Completing the interaction sequence changes the state of the environment.

## Interaction Flow

1. Start the experience through the **WAKE** opening screen.
2. Interact with the mirror to transform it into a portal.
3. Use the portal to enter the city.
4. Pick up the bucket.
5. Bring the bucket to the fire hydrant and fill it.
6. Use the filled bucket to extinguish the fire.
7. Interact with the character to complete the experience.

## Source Code

The `Scripts` folder contains the C# scripts created for the project.

### Interaction Scripts

- `MirrorPortalInteraction.cs` — controls the mirror-to-portal transformation and teleportation.
- `BucketState.cs` — tracks the current state of the bucket.
- `BucketGuidanceManager.cs` — manages guidance and beacon states during the interaction sequence.
- `HydrantInteraction.cs` — handles the bucket filling interaction.
- `FireInteraction.cs` — controls the fire extinguishing interaction.

### UI and Feedback

- `StartMenuController.cs` — controls the opening WAKE sequence.
- `EndScreenController.cs` — controls the end-screen behavior.
- `HoverScaleFeedback.cs` — provides visual feedback when interactive objects are hovered.

## Tools

- Unity
- C#
- XR Interaction Toolkit

## Documentation

Full project documentation, screenshots, video, asset credits, and development details are available on the project documentation page.

**Documentation:** [Add documentation link here]
