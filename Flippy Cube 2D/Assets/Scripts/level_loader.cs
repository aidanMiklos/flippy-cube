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
        if(PlayerPrefs.GetString("Level") == null){
            PlayerPrefs.SetString("Level", "Level 1");
        }
        else if(PlayerPrefs.GetString("Level") != SceneManager.GetActiveScene().name){
        GameObject levelSwitcher = GameObject.Find("Level Switcher");
        levelSwitcher.GetComponent<level_switcher>().LoadLevel(PlayerPrefs.GetString("Level"));
        }
        if(!GameObject.Find("Music(Clone)")){ 
            Instantiate(music, new Vector3(0,0,0), Quaternion.identity);
            string state = PlayerPrefs.GetString("ToggleState");
            
            if(state=="All"){
                gameObject.GetComponent<AudioSource>().volume = 0.8f;
            }
            else if(state=="Half"){
                gameObject.GetComponent<AudioSource>().volume = 0.3f;
            }
            else{
                gameObject.GetComponent<AudioSource>().volume = 0f;
            }
        }

    }

}