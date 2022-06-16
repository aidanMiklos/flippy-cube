using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grid_setup : MonoBehaviour
{
    private SpriteRenderer sprite;
    public List<Vector2> coordList = new List<Vector2>();
    public List<string> blockList = new List<string>();


    void Awake()
    {
        for (int layer = 0; layer < this.gameObject.transform.childCount; layer++)
        {
            GameObject child = this.gameObject.transform.GetChild(layer).gameObject;
            for (int tile = 0; tile < child.gameObject.transform.childCount; tile++)
            {
                coordList.Add(new Vector2(layer, tile));
                GameObject baby = child.gameObject.transform.GetChild(tile).gameObject;
                if(baby.name == "WIN")
                {
                    blockList.Add("WIN");
                }

                else if(baby.name.Contains("AIR"))
                {
                    blockList.Add("AIR");
                }

                else
                {
                    blockList.Add("GROUND");
                }

            }
        }
    }

}
