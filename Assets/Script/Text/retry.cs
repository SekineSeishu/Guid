using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class retry : MonoBehaviour
{
    public string LoadScene;
    private AudioSource audio;
    public Fade fade;
    public GameObject fadeCanvas;
    public void OnClick()
    {
        audio.Play();
        StartBool.Instance.OpenImage = false;
        fadeCanvas.SetActive(true);
    }
    public void Select()
    {
            audio.Play();
            StartBool.Instance.OpenImage = false;
            SceneManager.LoadScene("Title");
    }
    public void Next()
    {
            audio.Play();
            StartBool.Instance.OpenImage = false;
            fadeCanvas.SetActive(true);
    }

    public void restart()
    {
        audio.Play();
        StartBool.Instance.OpenImage = false;
        fadeCanvas.SetActive(true);
    }
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        fadeCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
