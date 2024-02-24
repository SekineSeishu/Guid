using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartBool : MonoBehaviour
{
    public static StartBool Instance;
    public bool OpenImage;

    public void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        OpenImage = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
