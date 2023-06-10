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
* Added new gameplay BGM.
* Added new fish collection SFX.
* Updated StartMenu with a quit button to make it easier to close the game in the build version.