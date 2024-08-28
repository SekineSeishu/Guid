using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    public static StageManager Instance;
    public Vector3 defaultpos;
    public GameObject GrassBlock;
    public float time;
    int[,] stageLayout = {
        {0,1,1,1,1,0},
        {0,1,1,1,1,1},
        {0,0,0,0,0,1},
        {0,1,1,1,1,1},
        {0,1,1,1,1,0}
    };

    void GenerateStage()
    {
        int rows = stageLayout.GetLength(0);
        int cols = stageLayout.GetLength(1);

        for (int z = 0; z < rows; z++)
        {
            for (int x = 0; x < cols; x++)
            {
                if (x >= 0 && x < stageLayout.GetLength(0) && z >= 0 && z < stageLayout.GetLength(1))
                {
                    if (stageLayout[x, z] == 1)
                    {
                        Vector3 position = new Vector3(defaultpos.x + x, defaultpos.y, defaultpos.z + z);
                        Instantiate(GrassBlock, position, Quaternion.identity);
                    }
                }
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        GenerateStage();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
