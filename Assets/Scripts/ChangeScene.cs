public class ChangeScene : Util {
	public string sceneName;

	public void changeScene(){
		LoadScene (sceneName, 0f);
	}
}
