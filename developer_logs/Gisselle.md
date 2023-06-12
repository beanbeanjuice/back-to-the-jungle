# Log File

# May 30, 2023 #
- FEATURE: Infinite Ground
  - Added LoopingGround.cs file that inifitely loops ground
  - Added LoopingGround script to Ground object in Hierarchy

# May 31, 2023 #
- FEATURE: Infinite Ground
  - Fixed logic in LoopingGround.cs to handle ground properties
  - Added LoopingGround.cs script to Ground prefab
  - Modified LoopingGround.cs to move groundPrefab consistently and factor in size of prefab
  - LoopingGround.cs does still need to handle deleting past groundPrefabs

# June 1, 2023 #
- FEATURE: Infinite Ground
  - Fixed linting errors in LoopingGround.cs and changed Ground prefabs
  - Downloaded Gameplay.unity file from integration and swapped it w old one
  - Fixed logic for LoopingGround.cs and addressed issues from PR
  - Changed SpawnDistance and secondsBeforeDelete in LoopingGround.cs

# June 2, 2023 #
- FEATURE: Vine Factory
  - Added prefabs for Vines
  - Added VineFactory.cs that spawns in vines and deletes them when Barry has passed them
  - Fixed indentation in LoopingGround.cs
- Merged Infnite Ground to Integration
- MERGE CONFLICTS (Integration <- InfiniteGround):
  - Duplicated CurrentGround and renamed it to NextGround to prepare for InfiniteGround branch
  - Compared conflicts and manually put in transform properties

# June 3, 2023 #
- FEATURE: Vine Factory
  - Switched colliders on vine prefabs from Box Collider to Polygon Collider for more accuracy
  - Fixed Gameplay.Unity after merging conflicts (took several pulls and rebasing) -> ended up putting my changes in Integration to accept my changes in Vine Factory
  - Fixed syntax in LoopingGround.cs
  - Added case in PlayerCollisionController.cs to handle Vine prefab
  - Added Audio file to cue when Barry collides with vines
  - Added EndGame method in PlayerController.cs to switch to scores scene
  - Modified Gameplay.Unity to handle vine collisions

# June 7, 2023 #
- FEATURE: Vine Factory
  - Cleaned up vines variables
  - Deleted Super Mario music wav files

# June 8, 2023 #
- FEATURE: Vine Factory
  - Vines no longer delete when player collides
- Merged Vine Factory to Integration

# June 10, 2023 #
- FEATURE: Bird Factory
    - Added possibiliy of getting pinkBirdPrefab (goes 2x faster than the blue bird)
    - Fixed logic in BirdFactory.cs to spawn birds simultaneously but still be delayed by one second
    - Fixed scale of pinkBirdPrefab to fit size
    - Got rid of a line in WarningController.cs
    - Added BirdFactory.cs that packages birds and warnings together
    - Warnings spawn with a bird following right after depending on the delay
    - Added WarningController.cs that handles the start of warnings, positioning, and when to destroy the gameObject
    - Added BirdController.cs that handles the velocity of birds, positioning, and when to destroy the gameObject
    - Removed BirdMovement.cs controller from bird prefab and added BirdController.cs
    - Changed the deletion time of the fish prefab to 12 seconds to account for memory usage

# June 11, 2023 #
- FEATURE: Bird Factory
  - Deleted commented code in WarningController.cs
  - Deleted \_secondsBeforeLaunch because it was adding more of a delay to the birds launching which is already handled by \_secondsBetweenBirds in BirdFactory.cs
  - Changed \_secondsBetweenBirds to 1.5f in BirdFactory.cs
  - Upped the max possible birds to 7, but because of Random.Range's max exclusive rule, players could receive a max of 6 birds back to back
  - Deleted comments in BirdFactory.cs that explained a pattern system that would be enabled if there were more than one bird planned to launch
  - Changed the name of the IEnumerator DelayBetweenBirds to GenerateWarningsAndBirds in BirdFactory.cs
  - Changed the name of the IEnumerator WaitAndGetYPosition to WaitAndSpawnBird in BirdFactory.cs
  - Deleted the line WaitForSeconds in WaitAndSpawnBird due to a timing conflict (delayed the birds longer) in BirdFactory.cs
  - Deleted Debug.Log in SpawnBird method in BirdFactory.cs
  - Added BirdWarning tag to Tag Manager
- Merged Bird Factory to Integration
