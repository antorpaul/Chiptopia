using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour {


	public void loadOnClick(int level)
	{
		SceneManager.LoadScene(level);//ints and such also work.
	}
}
