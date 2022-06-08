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

    public Vector2 bottomCoords = new Vector2(0, 0);
    public Vector2 topCoords = new Vector2(0, 0);
    public Vector2 startingPos = new Vector2(0, 0);

    //standing lying sideways
    public string state = "standing";
    void Awake(){
        Bottom = this.gameObject.transform.GetChild(0).gameObject;
        Top = this.gameObject.transform.GetChild(1).gameObject;
        topCoords = startingPos;
        bottomCoords = startingPos;
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
        if (Input.GetKeyDown("right"))
        {
            Right();
        }
        if (Input.GetKeyDown("left"))
        {
            Left();
        }
    }

    void Down(){
        if(state=="standing"){
            Bottom.transform.position += new Vector3(vertical_x,-vertical_y,0);
            Top.transform.position = Bottom.transform.position;
            Top.transform.position += new Vector3(vertical_x,-vertical_y,0);
            state = "lying";
            bottomCoords += new Vector2(1,0);
            topCoords += new Vector2(2, 0);
        }

        else if(state=="lying"){
            Bottom.transform.position += new Vector3(vertical_x*2,-vertical_y*2,0);
            Top.transform.position = Bottom.transform.position;
            Top.transform.position += new Vector3(0,height,0);
            state = "standing";
            topCoords += new Vector2(1, 0);
            bottomCoords = topCoords;
        }
        else if (state == "sideways")
        {
            Bottom.transform.position -= new Vector3(-vertical_x, vertical_y, 0);
            Top.transform.position -= new Vector3(-vertical_x, vertical_y, 0);
            state = "sideways";
            bottomCoords += new Vector2(1, 0);
            topCoords += new Vector2(1, 0);
        }


    }

    void Up(){
        if(state=="standing"){
            Top.transform.position = Bottom.transform.position;
            Top.transform.position -= new Vector3(vertical_x,-vertical_y,0);
            
            Bottom.transform.position -= new Vector3(vertical_x*2,-vertical_y*2,0);
            state = "lying";
            topCoords -= new Vector2(1, 0);
            bottomCoords -= new Vector2(2, 0);
        }

        else if(state=="lying"){
            Bottom.transform.position -= new Vector3(vertical_x,-vertical_y,0);
            Top.transform.position = Bottom.transform.position;
            Top.transform.position += new Vector3(0,height,0);
            state = "standing";
            bottomCoords -= new Vector2(1, 0);
            topCoords = bottomCoords;
        }
        else if (state == "sideways")
        {
            Bottom.transform.position += new Vector3(-vertical_x, vertical_y, 0);
            Top.transform.position += new Vector3(-vertical_x, vertical_y, 0);
            state = "sideways";
            bottomCoords -= new Vector2(1, 0);
            topCoords -= new Vector2(1, 0);
        }

    }

    void Right()
    {
        if (state == "standing"){

            Bottom.transform.position += new Vector3(vertical_x, vertical_y, 0);
            Top.transform.position = Bottom.transform.position;
            Bottom.transform.position += new Vector3(vertical_x, vertical_y, 0);
            state = "sideways";
            topCoords -= new Vector2(0, 1);
            bottomCoords -= new Vector2(0, 2);
        }
        else if (state == "lying")
        {
            Bottom.transform.position += new Vector3(vertical_x, vertical_y, 0);
            Top.transform.position += new Vector3(vertical_x, vertical_y, 0);
            state = "lying";
            topCoords -= new Vector2(0, 1);
            bottomCoords -= new Vector2(0, 1);
        }
        else if (state == "sideways")
        {
            Bottom.transform.position += new Vector3(vertical_x, vertical_y, 0);
            Top.transform.position = Bottom.transform.position;
            Top.transform.position += new Vector3(0, height, 0);
            state = "standing";
            bottomCoords -= new Vector2(0, 1);
            topCoords = bottomCoords;
        }
    }

    void Left()
    {
        if (state == "standing")
        {
            Bottom.transform.position -= new Vector3(vertical_x, vertical_y, 0);
            Top.transform.position = Bottom.transform.position;
            Top.transform.position -= new Vector3(vertical_x, vertical_y, 0);
            state = "sideways";
            bottomCoords += new Vector2(0, 1);
            topCoords += new Vector2(0, 2);
        }
        else if (state == "lying")
        {
            Bottom.transform.position -= new Vector3(vertical_x, vertical_y, 0);
            Top.transform.position -= new Vector3(vertical_x, vertical_y, 0);
            state = "lying";
            bottomCoords += new Vector2(0, 1);
            topCoords += new Vector2(0, 1);
        }
        else if (state == "sideways")
        {
            Top.transform.position -= new Vector3(vertical_x, vertical_y, 0);
            Bottom.transform.position = Top.transform.position;
            Top.transform.position += new Vector3(0, height, 0);
            state = "standing";
            topCoords += new Vector2(0, 1);
            bottomCoords = topCoords;
        }

    }
}
