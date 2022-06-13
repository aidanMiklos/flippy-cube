using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 using UnityEngine.SceneManagement;
public class level_switcher : MonoBehaviour
{
    public string nextScene;
    public void SwitchLevel(){
        if(nextScene != ""){
            PlayerPrefs.SetString("Level", nextScene);
            SceneManager.LoadScene (sceneName:nextScene);
        }
         
    }

    public void LoadLevel(string level){
        SceneManager.LoadScene(sceneName:level);
    }
}
