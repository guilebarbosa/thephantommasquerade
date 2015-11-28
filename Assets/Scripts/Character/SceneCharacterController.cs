public class SceneCharacterController : Util {
    public string sceneName;

    public void changeScene()
    {
        LoadScene(sceneName, 0f);
    }
}