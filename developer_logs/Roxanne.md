# Log File
---
## May 27, 2023
* Created Initial Sprite Artwork of Player, Mount, and Ground. Player, Mount, and Ground sprites were all inspired through the credited online sources, with personal tweaks and edits made by myself on pixelartmaker.com. Also created initial Google Doc to keep track of art licenses and citations for inspiration.

---
## May 29, 2023
* Created and completed artwork for start menu, including Start, Setting, Shop buttons, BackToTheJungle Logo, and player / mount display, inspired by credited sources for block letters but made myself on pixelartmaker.

* Incorporated gameplay background (jungle background) into gameplay scene.

* Created a vine prefab with 5 different sprites as one of the main obstacles in the game. Vines were inspired by source, but made myself on pixelartmaker.

---
## May 30, 2023
* Created and completed artwork for pause menu, including coins logo, distance logo, tablet display logo, and pause logo. Also completed continue button, and 2 variations of mainMenu button. These were all inspired by credited sources but made myself on pixelartmaker.

* Reused coins, distance, menu, and tablet sprites for the Game Over menu. Created a new back button along with variations of play again button designs according to initial UI design.

---
## May 31, 2023
* Created flying and walking pterodactyl sprites, made on pixelartmaker.

* Created animations with these sprites, one for flying when there is user input to accelerate upwards, one for gliding when there is no user input for gliding downwards, one short landing animation, and one walking animation.
As for these animations, I created `MountAnimationController.cs` to change the conditionals of whether the player (attached to the mount) was in the air or on the ground in order to animate the respective animations, only on the Mount object itself.

---
## June 3, 2023
* Created vine sprites on pixelartmaker.com

* Then outlined these sprites in yellow for a better game feel and visual pop to make it easier for player to see and dodge in gameplay.

---
## June 7, 2023
* Created new parallax background sprites with 5 different layers.

---
## June 9, 2023
* Added the bird warning flash animation.

* Added the 2 second lab cutscene animation upon very start of game. Used the Timeline and Animation feature in Unity for player and dino animation movement into the portal.

--- 
## June 13, 2023
* Increased player acceleration and starting velocity for a better game feel, since we felt the game started out too slow. Code sections were added in `PlayerMovementController.cs` to ensure a max velocity of 15 as the fastest speed the player can reach.