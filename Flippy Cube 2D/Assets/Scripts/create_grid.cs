using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class create_grid : MonoBehaviour
{
    public bool createMap = false;
    public int width = 0;
    public int height = 0;
    public GameObject groundPrefab;
    public GameObject tilePrefab;

    // Start is called before the first frame update
    void Start()
    {
        if (createMap)
        {
            GameObject ground = Instantiate(groundPrefab, new Vector3(0,0,0), Quaternion.identity);
            ground.name = "Ground";

            for(int i = 0; i < width; i++)
            {
                GameObject row = Instantiate(new GameObject(), new Vector3(0, 0, 0), Quaternion.identity);
                row.transform.parent = ground.transform;
                row.name = "Row " + i;
                for (int j = 0; j < height; j++)
                {
                    GameObject tile = Instantiate(tilePrefab, new Vector3(-j * 2.2f, -j * 1.1f, 0), Quaternion.identity);
                    tile.transform.parent = row.transform;
                    tile.name = "(" + i + "," + j + ")";
                }
                row.transform.position = new Vector3(i*2 + (0.1f*(i * 2)), -i + (0.1f*(-i)), 0);


            }
            

        }
    }


}
