using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangerTool : MonoBehaviour {

    private int scene_count = 0;
    private string[] scenes;
    private List<Dropdown.OptionData> optionDataList = new List<Dropdown.OptionData>();
    private Dropdown dd;


    public void OnChangeClick()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(dd.captionText.text);
    }

    // Use this for initialization
    void Start () {
        scene_count = UnityEngine.SceneManagement.SceneManager.sceneCountInBuildSettings;
        scenes = new string[scene_count];

        // populate the dropdown options
        for (int i = 0; i < scene_count; i++ )
        {
            scenes[i] = System.IO.Path.GetFileNameWithoutExtension(UnityEngine.SceneManagement.SceneUtility.GetScenePathByBuildIndex(i));
            optionDataList.Add(new Dropdown.OptionData(scenes[i]));
        }

        dd = GetComponentInChildren<Dropdown>();
        dd.ClearOptions();
        dd.AddOptions(optionDataList);
                 
	}

}
