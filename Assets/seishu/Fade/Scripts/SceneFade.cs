using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneFade : MonoBehaviour
{
    public Fade fade;
    public string SceneName;
    private AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Title")
        {
            if (Input.GetMouseButtonDown(0))
            {
                audio.Play();
                SceneManager.LoadScene(SceneName);
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                fade.FadeIn(10f, () =>
                {
                    SceneManager.LoadScene(SceneName);
                });
            }
        }
    }
}
