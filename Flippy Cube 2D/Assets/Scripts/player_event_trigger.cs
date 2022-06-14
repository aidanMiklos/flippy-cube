using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_event_trigger : MonoBehaviour
{
    public string bottomBlock;
    public string topBlock;

    void Update(){
        bottomBlock = gameObject.GetComponent<player_movement>().bottomBlock;
        topBlock = gameObject.GetComponent<player_movement>().topBlock;

        if(bottomBlock == "AIR" || topBlock == "AIR"){
            Die();
        }
        if(bottomBlock == "WIN" && topBlock == "WIN"){
            Win();
        }
    }

    public void Die(){
        Debug.Log("DIE");
    }
    public void Win(){
        GameObject levelSwitcher = GameObject.Find("Level Switcher");
        levelSwitcher.GetComponent<level_switcher>().SwitchLevel();
    }
}
