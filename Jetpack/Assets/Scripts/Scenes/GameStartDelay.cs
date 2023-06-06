namespace Scenes
{
    public class GameStartDelay : LoadDelay
    {
        protected override void Logic()
        {
            this.LevelLoaderScript.LoadStartMenuScene();
        }
    }
}
