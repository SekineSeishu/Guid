using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UniRx;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    enum ButtonType
    {
        select,
        retry,
        next
    }

    [SerializeField] private ButtonType buttonType;
    [SerializeField] private Button selectButton;
    [SerializeField] private Button retryButton;
    [SerializeField] private Button nextButton;
    public string LoadScene;
    private AudioSource audio;
    public Fade fade;
    public GameObject fadeCanvas;

    void Start()
    {
        audio = GetComponent<AudioSource>();
        fadeCanvas.SetActive(false);
        IObservable<ButtonType> observable1 = selectButton
            .OnClickAsObservable ()
            .TakeUntilDestroy(this)
            .Select(_ => ButtonType.select);

        IObservable<ButtonType> observable2 = retryButton
            .OnClickAsObservable()
            .TakeUntilDestroy(this)
            .Select(_ => ButtonType.retry);

        IObservable<ButtonType> observable3 = nextButton
            .OnClickAsObservable()
            .TakeUntilDestroy(this)
            .Select(_ => ButtonType.next);

        Observable.Merge(observable1, observable2, observable3)
            .ThrottleFirst(System.TimeSpan.FromSeconds(10))
            .Subscribe(x =>
            {
                switch (x)
                {
                    case ButtonType.select:
                        Select();
                        break;
                    case ButtonType.retry:
                        retry();
                        break;
                    case ButtonType.next:
                        Next();
                        break;
                }
            });
    }

    public void Select()
    {
        audio.Play();
        StartBool.Instance.OpenImage = false;
        SceneManager.LoadScene("Title");
    }

    public void retry()
    {
        audio.Play();
        StartBool.Instance.OpenImage = false;
        fadeCanvas.SetActive(true);
    }

    public void Next()
    {
        audio.Play();
        StartBool.Instance.OpenImage = false;
        fadeCanvas.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
