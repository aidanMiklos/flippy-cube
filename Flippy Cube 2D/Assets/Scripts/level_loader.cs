using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class level_loader : MonoBehaviour
{
    public GameObject music;
    // Start is called before the first frame update
    void Awake()
    {   
        if(SceneManager.GetActiveScene().name != "Base"){
            StartFunction();
        }
        
    }

    public void StartFunction(){
        if(!GameObject.Find("Music(Clone)")){ 
            GameObject musicClone = Instantiate(music, new Vector3(0,0,0), Quaternion.identity);
            string state = PlayerPrefs.GetString("ToggleState");
            
            if(state=="All" || state == ""){
                musicClone.GetComponent<AudioSource>().volume = 0.8f;
            }
            else if(state=="Half"){
                musicClone.GetComponent<AudioSource>().volume = 0.3f;
            }
            else{
                musicClone.GetComponent<AudioSource>().volume = 0f;
            }
        }
        if(PlayerPrefs.GetString("Level") == ""){
            PlayerPrefs.SetString("Level", "Level 1");
        }
        else if(PlayerPrefs.GetString("Level") != SceneManager.GetActiveScene().name){
        GameObject levelSwitcher = GameObject.Find("Level Switcher");
        levelSwitcher.GetComponent<level_switcher>().LoadLevel(PlayerPrefs.GetString("Level"));
        }
    }

}