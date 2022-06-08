using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn_player : MonoBehaviour
{
    public Vector3 spawnPos = new Vector3(-3.15F, -1.5F, 12);
    public GameObject player;
    public float height = 2.7F;
    public void spawn()
    {
        GameObject curPlayer = Instantiate(player, new Vector3(0,0,0), Quaternion.identity);
        GameObject Bottom = curPlayer.gameObject.transform.GetChild(0).gameObject;
        GameObject Top = curPlayer.gameObject.transform.GetChild(1).gameObject;
        Bottom.transform.position = spawnPos;
        Top.transform.position = Bottom.transform.position;
        Top.transform.position += new Vector3(0, height, 0);
    }

    private void Start()
    {
        spawn();
    }
}
