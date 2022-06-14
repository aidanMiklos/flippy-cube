using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 using UnityEngine.SceneManagement;
public class level_switcher : MonoBehaviour
{
    public string nextScene;
    public Animator animator;
    public Animator playerAnimator;
    public GameObject player;


    public void SwitchLevel(){
        if(nextScene != ""){
            PlayerPrefs.SetString("Level", nextScene);
            StartCoroutine(LoadNextScene(nextScene));
        }
         
    }

    public void LoadLevel(string level){
        StartCoroutine(LoadNextScene(level));
    }

    IEnumerator LoadNextScene(string name)
    {
        player = GameObject.Find("Player(Clone)");
        player.GetComponent<player_movement>().enabled = false;
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
    }

    IEnumerator LoadThisScene()
    {
        player = GameObject.Find("Player(Clone)");
        player.GetComponent<player_movement>().enabled = false;
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



        SceneManager.LoadScene(sceneName: name);
    }


}
