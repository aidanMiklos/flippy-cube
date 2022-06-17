using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class tutorial : MonoBehaviour
{
    GameObject player;
    TextMeshPro text;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player(Clone)");
        player.GetComponent<player_movement>().enabled = false;
        text = GameObject.Find("Canvas").transform.GetChild(0).GetComponent<TextMeshPro>();
        StartCoroutine(Tutorial());
    }

    IEnumerator Tutorial()
    {
        text.SetText("Swipe to control your cube");
        yield return new WaitForSeconds(0.3f);
    }

}
