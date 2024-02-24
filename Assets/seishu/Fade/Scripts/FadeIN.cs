using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeIN : MonoBehaviour
{
    public Fade fade;
    public string LoadScene;
    // Start is called before the first frame update
    void Start()
    {
        fade.FadeIn(3f, () =>
        {
            SceneManager.LoadScene(LoadScene);
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
