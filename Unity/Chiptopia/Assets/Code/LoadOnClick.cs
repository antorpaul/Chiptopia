using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadOnClick : MonoBehaviour {

	private AssetBundle myLoadedAssetBundle;
	private string[] scenePaths;

	void Start()
	{
		myLoadedAssetBundle = AssetBundle.LoadFromFile ("scenes");
		scenePaths = myLoadedAssetBundle.GetAllScenePaths();
	}

	void OnGUI()
	{
		if (GUI.Button (new Rect (10, 10, 100, 30), "Change Scene")) {
			Debug.Log ("Scene2 loading: " + scenePaths [0]);
			SceneManager.LoadScene (scenePaths [0], LoadSceneMode.Single);
		}
	}
}
