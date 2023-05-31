# Log File

William: [![wakatime](https://wakatime.com/badge/github/beanbeanjuice/ecs189L-back-to-the-jungle.svg)](https://wakatime.com/badge/github/beanbeanjuice/ecs189L-back-to-the-jungle)

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
