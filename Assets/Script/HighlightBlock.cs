using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightBlock : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Character")
        {
            Destroy(gameObject);
        }
        else if (other.gameObject.tag == "StageBlock")
        {
            Debug.Log("block");
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
