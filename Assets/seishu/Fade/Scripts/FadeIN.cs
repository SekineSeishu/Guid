using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeIN : MonoBehaviour
{
    private Fade fade;

    public void In(string loadScene)
    {
        fade =  gameObject.GetComponent<Fade>();
        fade.FadeIn(3f, () =>
        {
            SceneManager.LoadScene(loadScene);
        });
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
