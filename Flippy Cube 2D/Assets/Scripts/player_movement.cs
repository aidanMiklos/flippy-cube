using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

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

    GameObject Ground;
    List<Vector2> coordList = new List<Vector2>();
    List<string> blockList = new List<string>();
    public string bottomBlock;
    public string topBlock;

    //standing lying sideways
    public string state = "standing";
    void Awake(){
        Bottom = this.gameObject.transform.GetChild(0).gameObject;
        Top = this.gameObject.transform.GetChild(1).gameObject;
        topCoords = startingPos;
        bottomCoords = startingPos;
        Ground = GameObject.Find("Ground");
        coordList = Ground.gameObject.GetComponent<grid_setup>().coordList;
        blockList = Ground.gameObject.GetComponent<grid_setup>().blockList;
        FindBlocksOn(bottomCoords, topCoords);
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

        FindBlocksOn(bottomCoords, topCoords);

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
        FindBlocksOn(bottomCoords, topCoords);
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
        FindBlocksOn(bottomCoords, topCoords);
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
        FindBlocksOn(bottomCoords, topCoords);
    }

    void FindBlocksOn(Vector2 b_coords, Vector2 t_coords){
        int bottomIndex = coordList.IndexOf(b_coords);
        int topIndex = coordList.IndexOf(t_coords);
        try
        {
            bottomBlock = blockList[bottomIndex];
        }
        catch(ArgumentOutOfRangeException e){
            bottomBlock = "AIR";
        }

        try{
            topBlock = blockList[topIndex];
        }
        catch(ArgumentOutOfRangeException e){
            topBlock = "AIR";
        }
        
    }
}
