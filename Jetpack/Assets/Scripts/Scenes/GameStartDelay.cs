namespace Scenes
{
    /// <summary>
    /// A class that inherits from LoadDelay.
    /// Contains the logic for what should happen once the delay
    /// is completed.
    /// <remarks>Coded by William.</remarks>
    /// </summary>
    public class GameStartDelay : LoadDelay
    {
        protected override void Logic()
        {
            this.LevelLoaderScript.LoadStartMenuScene();
        }
    }
}
