using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 using UnityEngine.SceneManagement;
using System;
public class level_switcher : MonoBehaviour
{
    public string nextScene;
    public Animator animator;
    public Animator playerAnimator;
    public GameObject player;
    public bool wonSound = false;

    public void SwitchLevel(){
        if(nextScene != ""){
            PlayerPrefs.SetString("Level", nextScene);
            StartCoroutine(LoadNextScene(nextScene, true));
        }
         
    }

    public void LoadLevel(string level){
        StartCoroutine(LoadNextScene(level, false));
    }

    IEnumerator LoadNextScene(string name, bool isWin)
    {
        if (isWin && !wonSound)
        {
            gameObject.GetComponent<AudioSource>().Play();
            wonSound = true;
        }
        try
        {
            player = GameObject.Find("Player(Clone)");
            player.GetComponent<player_movement>().enabled = false;
        }
        catch(NullReferenceException)
        {
            Debug.Log("no player in scen");
        }

        bool wait = true;
        Debug.Log("SWITCH");
        try
        {
            animator.SetTrigger("End");
            
        }
        catch (UnassignedReferenceException)
        {
            wait = false;
        }

        if (wait)
        {
            yield return new WaitForSeconds(1f);
        }
        


        SceneManager.LoadScene(sceneName: name);
        Destroy(gameObject);
    }

    public void Die()
    {
        StartCoroutine(LoadThisScene());
    }

    IEnumerator LoadThisScene()
    {
        player = GameObject.Find("Player(Clone)");
        player.GetComponent<player_movement>().enabled = false;
        playerAnimator = player.GetComponent<Animator>();
        bool wait = true;
        Debug.Log("SWITCH");
        try
        {
            playerAnimator.SetTrigger("DIE");

        }
        catch (UnassignedReferenceException)
        {
            wait = false;
        }

        if (wait)
        {
            yield return new WaitForSeconds(1f);
        }

        wait = true;

        try
        {
            animator.SetTrigger("End");

        }
        catch (UnassignedReferenceException)
        {
            wait = false;
        }

        if (wait)
        {
            yield return new WaitForSeconds(1f);
        }


        SceneManager.LoadScene(sceneName: SceneManager.GetActiveScene().name);
    }


}
