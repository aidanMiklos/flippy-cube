using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_movement : MonoBehaviour
{
    public GameObject Bottom;
    public GameObject Top;
    //1.1 2.2
    public float vertical_x = 2.2F;
    public float vertical_y = 1.1F;

    public float height = 2.7F;

    //standing lying sideways
    public string state = "standing";
    void Awake(){
        Bottom = this.gameObject.transform.GetChild(0).gameObject;
        Top = this.gameObject.transform.GetChild(1).gameObject;

    }

    void Update()
    {
        if (Input.GetKeyDown("up"))
        {
            Up();
        }

        if (Input.GetKeyDown("down"))
        {
            Down();
        }
    }

    void Down(){
        if(state=="standing"){
            Bottom.transform.position += new Vector3(vertical_x,-vertical_y,0);
            Top.transform.position = Bottom.transform.position;
            Top.transform.position += new Vector3(vertical_x,-vertical_y,0);
            state = "lying";
        }

        else if(state=="lying"){
            Bottom.transform.position += new Vector3(vertical_x*2,-vertical_y*2,0);
            Top.transform.position = Bottom.transform.position;
            Top.transform.position += new Vector3(0,height,0);
            state = "standing";
        }
        
    }

    void Up(){
        if(state=="standing"){
            Top.transform.position = Bottom.transform.position;
            Top.transform.position -= new Vector3(vertical_x,-vertical_y,0);
            
            Bottom.transform.position -= new Vector3(vertical_x*2,-vertical_y*2,0);
            state = "lying";
        }

        else if(state=="lying"){
            Bottom.transform.position -= new Vector3(vertical_x,-vertical_y,0);
            Top.transform.position = Bottom.transform.position;
            Top.transform.position += new Vector3(0,height,0);
            state = "standing";
        }
        
    }
}
