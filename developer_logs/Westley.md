# Log File

## May 27, 2023
* Drafted initial designs for start menu, pause, and end game scenes. The designs included animation flow ideas and some button designs.
* This took a couple hours of brainstorming, but I enjoyed pulling aspects of existing game UI's that I liked to create the one for our game.

## June 2, 2023
* Created StartMenu and StartScreen scenes in Unity.
* Buttons were added to the menu, but requires code for functionality.
* The Unity interface for UI work took some time to get used to, but work should flow more smoothly now.

## June 5, 2023
* Created Gameplay Scene/UI in Unity.
* Score.cs script created and updates the UI elements with the current distance traveled and fish collected.
* Created EndScreenUI in the Gameplay Scene.
* Updated PlayerCollisionController to update the distance display on EndScreenUI

## June 6, 2023
* Small bug with a colored hue on the StartScreen and StartMenu fixed.
* Created PauseScreenUI which was added to the Gameplay scene. The buttons are not functional.
* Created SettingsMenu Scene along with AudioSettings.cs that allows the player to adjust Master, SFX, music mixer volumes. 

## June 8, 2023
* Added how-to-play scene to give the player a sense of how to play the game. The scene is open for more updates, especially to polish it up.

## June 9, 2023
* Updated UI to scale to screen size.

## June 10, 2023
* Further screen scale updates to UI.
* Added button SFX.
* * I found a free sound clip of a rock falling, then isolated parts of that sound to create the two different button click SFX.
* Added new gameplay BGM. 
* * With the help of the art team, we found the music and the nature ambience. I then learned how to use Audacity to mix the sounds together to create our new BGM.
* Added new fish collection SFX.
* Updated StartMenu with a quit button to make it easier to close the game in the build version.

## June 11, 2023
* Redid the UI+audio update from June 10 due to merge conflict issues.
* Added sound to the starting animation. 
* * I found three free sounds online: portal idle, alarm, and dinosaur roar. Then I mixed these sounds together in Audacity to fit the runtime of the animation.
* Wrote script to enable pausing and game over screen.
* Added menu music.
* Added functionality to the quit button.
* Created GameplayManager.cs
* * Navigates the different UI of the Gameplay scene: GameplayUI, EndScreenUI, and PauseScreenUI.
* Added MountFlying SFX, Vine hit SFX.
* Added bird enemy SFX.
* * I isolated certain parts of 3 different sound clips to create the SFX used in the game. 

## June 11, 2023
* Added walking SFX.
* Implemented PlayerAudioManager that plays the correct SFX (wing flaps or walking) depending on player movement.

## June 12, 2023
* Reformat shop menu UI.