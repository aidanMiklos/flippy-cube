using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class tutorial : MonoBehaviour
{
    public GameObject player;
    public TextMeshProUGUI text;
    public string tutorialStart = "false";
    // Start is called before the first frame update
    void Update()
    {
        if(PlayerPrefs.GetString("tutorial")==""){
            PlayerPrefs.SetString("tutorial", "false");
        }
        tutorialStart = PlayerPrefs.GetString("tutorial");
        if(tutorialStart == "false"){
            player = GameObject.Find("Player(Clone)");
            player.GetComponent<player_movement>().enabled = false;
            text = GameObject.Find("Canvas").transform.GetChild(0).GetComponent<TextMeshProUGUI>();
            StartCoroutine(Tutorial());
        }

    }

    IEnumerator Tutorial()
    {
        PlayerPrefs.SetString("tutorial", "true");
        text.fontSize = 75;
        text.gameObject.transform.position = text.gameObject.transform.position - new Vector3(0,40,0);
        text.SetText("Swipe to control your cube");
        yield return new WaitForSeconds(4f);
        text.SetText("Get your cube in the hole");
        yield return new WaitForSeconds(4f);
        text.SetText("But don't fall off");
        yield return new WaitForSeconds(4f);
        text.fontSize = 200;
        text.gameObject.transform.position = text.gameObject.transform.position + new Vector3(0,40,0);
        text.SetText("01");
        player.GetComponent<player_movement>().enabled = true;
    }

}
