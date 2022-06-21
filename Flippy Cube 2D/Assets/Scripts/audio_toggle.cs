using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class audio_toggle : MonoBehaviour
{
    public string toggleState;
    public Sprite all;
    public Sprite half;
    public Sprite none;

    public AudioSource background;
    
    string[] states = new string[]{"All", "Half", "None"};
    void Awake(){
        if(PlayerPrefs.GetString("ToggleState") == ""){
            PlayerPrefs.SetString("ToggleState", "All");
        }
        toggleState = PlayerPrefs.GetString("ToggleState");
        
        if(toggleState=="All"){
            gameObject.GetComponent<Image>().sprite = all;
            PlayerPrefs.SetString("ToggleState", "All");
        }
        else if(toggleState=="Half"){
            gameObject.GetComponent<Image>().sprite = half;
            PlayerPrefs.SetString("ToggleState", "Half");
        }
        else{
            gameObject.GetComponent<Image>().sprite = none;
            PlayerPrefs.SetString("ToggleState", "None");
        }
        
    }

    public void OnClick(){
        background = GameObject.Find("Music(Clone)").GetComponent<AudioSource>();
        int nextValue = Array.IndexOf(states,toggleState)+1;
        if (nextValue == 3){
            nextValue = 0;
        }
        toggleState = states[nextValue];

        if(toggleState=="All"){
            gameObject.GetComponent<Image>().sprite = all;
            PlayerPrefs.SetString("ToggleState", "All");
            background.volume = 0.8f;
        }
        else if(toggleState=="Half"){
            gameObject.GetComponent<Image>().sprite = half;
            PlayerPrefs.SetString("ToggleState", "Half");
            background.volume = 0.3f;
        }
        else{
            gameObject.GetComponent<Image>().sprite = none;
            PlayerPrefs.SetString("ToggleState", "None");
            background.volume = 0f;
        }
    }

}
