# Log File

[![wakatime](https://wakatime.com/badge/github/beanbeanjuice/ecs189L-back-to-the-jungle.svg)](https://wakatime.com/badge/github/beanbeanjuice/ecs189L-back-to-the-jungle)

---

## May 27, 2023
* Created basic player movement and camera positioning. I accidentally did some part of the *Game Feel*'s job here, but the movement did not feel right until I added some logic for if the player was touching the ground.

---

## May 28, 2023
* Created log files for each of the members. Hopefully this can help everyone keep track of everything and give themselves notes/what they are currently thinking.
* I renamed the `SampleScene` to `Gameplay` to be more consistent as well as make sure everything will not cause issues in the future.
* Updated the `README.md` so that it has the given template from class.

---

## May 29, 2023
* Created notes for team meeting.
* I worked on putting the fish sprite into a `prefab`. Additionally, I also created a factory so that the fish can be spawned much more easily.
* I added collision detection for the player and the fish.

---

## May 30, 2023
* For the sake of time, I deviated from my task, as I had already completed all of them, and worked on randomly generating the "coins" or fish for the game. This was actually a much harder task than I thought it would be.
At first, I thought about creating prefabs for each of the patterns of fish that could spawn, but I opted to not do it that way because it felt clunky.
Instead, I created a pattern generator, where, us programmers, can input our own patterns. It automatically error checks them and spawns them into the game only if the player can grab them.
This was a huge task for me, but I am honestly happy with how it turned out. I created `FishPattern.cs`, `FishPatterns.cs`, and heavily modified the `FishFactory.cs`.
Essentially, we create our own "fish pattern" assets which we attach to the `Fish Patterns.asset` so that it can be read and understood by the code.

---

## June 1, 2023
* I added some basic background music and fish collection audio. These, of course, can be changed later as I suspect with the fish collection noise. For the background music, I chose a song that is catchy and from an artist I am familiar with, and honestly think it fits the feel of the game well.
The audio for the fish collection was chosen because it was the first thing that popped up in my mind. There seems to be random issues with framerate now because of the audio, so I messed with some of the decompression settings, and hopefully that fixes it.

---

## June 2, 2023
* Despite my meticulous creating of the GitHub issues, some of my team mates had never had experience with creating PRs and using the `issues` function on GitHub, and hence I have completely removed it. I think we can work more effectively this way, but will have to be a bit more mindful about the quality of code we are committing to the codebase.
* I created collision detections with birds.
* I created the bird movement controller. Some more can be done here, but I think that is up to the Game Logic team, or for a separate GitHub issue.
* I created collision detections with vines.
* There was an error due to how `LoopingGround.cs` was setup that would cause the player to switch to a `Gliding` state when the ground is moved. This has now been fixed, and the `PlayerMovementController` now uses a `Physics2D.BoxCast` to check if it is touching the ground.

---

## June 5, 2023
* Moved a string lookup in `LevelLoader.cs` to a hash. It should be more efficient this way.
* Helped resolve a merge conflict due to `Gameplay.unity`. UI for the `Gameplay` scene is now working!
* There was a bug in the UI that caused it to look faded and not transition properly. I got it working.

---

## June 8, 2023
* Moved player movement to `FixedUpdate()` instead of `Update()`. I did not notice before, but because the game ran at such a high FPS on *my* machine, I did not see any errors aside from the boost being fast. Running it on my Mac, which ran at a lower FPS, I figured out that having movement physics in `Update()` was not the way to go.
Now, I learned that ALL physics-related things should go in `FixedUpdate()` even if normal movement should go in `Update()`. This is possibly due to the fact that our game is an infinite side-scroller instead of a normal 2D game with movement in both axis.
