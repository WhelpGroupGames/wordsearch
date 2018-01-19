using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Singleton Data / Controller class that exists to share data
/// between scenes.
/// </summary>
public class GameController : MonoBehaviour {

    public static GameController instance;

    void Awake() {
        // if nothing exists, create it.  If it already exists
        if (instance == null)
        {
            instance = this;
        }
        else if(instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

	// Use this for initialization
	void Start () {
        //This shit doesn't work right
        //Debug.Log("Total Scenes: " + SceneManager.sceneCountInBuildSettings);
        //for (int i = 0; i < SceneManager.sceneCountInBuildSettings; i++ )
        //{
        //    Debug.Log("Scene : " + i + ", " + SceneManager.GetSceneByBuildIndex(i).name);
        //}
    }

    // Update is called once per frame
    void Update() { }
}
