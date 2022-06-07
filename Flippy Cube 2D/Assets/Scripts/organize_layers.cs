using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class organize_layers : MonoBehaviour
{
    int layer = 1;
    private SpriteRenderer sprite;
    void Awake()
    {
        for (int i = 0; i < this.gameObject.transform.childCount; i++)
        {
            GameObject child = this.gameObject.transform.GetChild(i).gameObject;
        for (int j = 0; j < child.gameObject.transform.childCount; j++)
        {
            
            GameObject baby = child.gameObject.transform.GetChild(j).gameObject;
            sprite = baby.GetComponent<SpriteRenderer>();
            sprite.sortingOrder = layer;
            layer++;
        }
        }
    }


}
