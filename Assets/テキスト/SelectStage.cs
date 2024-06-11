using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;
using TMPro;

public class SelectStage : MonoBehaviour
{
    public Fade fade;
    public GameObject stage1;
    public GameObject stage2;
    public GameObject stage3;
    public GameObject stageScene;
    public GameObject playLueL;
    public string LoadScene;
    public GameObject Ghost;
    private Animator animator;
    private AudioSource audioSource;
    public AudioSource startSE;
    private bool ON;
    public TextMeshProUGUI playText;

    //それぞれのUIをアニメーションをつけて表示する
    public void SelectOnClick1()
    {
        if (StartBool.Instance.OpenImage)
        {
            audioSource.Play();
            stage1.transform.localScale = new Vector3(0, 0, 0);
            stage2.transform.localScale = new Vector3(0, 0, 0);
            stage3.transform.localScale = new Vector3(0, 0, 0);
            playLueL.transform.localScale = new Vector3(0, 0, 0);
            stage1.transform.DOScale(new Vector3(1, 1, 1), 1f).SetEase(Ease.OutBack);
            if (gameObject.transform.localScale == new Vector3(1, 1, 1))
            {
                Debug.Log("clear");
            }
        }
    }
    public void SelectOnClick2()
    {
        if (StartBool.Instance.OpenImage)
        {
            audioSource.Play();
            stage1.transform.localScale = new Vector3(0, 0, 0);
            stage2.transform.localScale = new Vector3(0, 0, 0);
            stage3.transform.localScale = new Vector3(0, 0, 0);
            playLueL.transform.localScale = new Vector3(0, 0, 0);
            stage2.transform.DOScale(new Vector3(1, 1, 1), 1f).SetEase(Ease.OutBack);
            if (gameObject.transform.localScale == new Vector3(1, 1, 1))
            {
                Debug.Log("clear");
            }
        }
    }
    public void SelectOnClick3()
    {
        if (StartBool.Instance.OpenImage)
        {
            audioSource.Play();
            stage1.transform.localScale = new Vector3(0, 0, 0);
            stage2.transform.localScale = new Vector3(0, 0, 0);
            stage3.transform.localScale = new Vector3(0, 0, 0);
            playLueL.transform.localScale = new Vector3(0, 0, 0);
            stage3.transform.DOScale(new Vector3(1, 1, 1), 1f).SetEase(Ease.OutBack);
            if (gameObject.transform.localScale == new Vector3(1, 1, 1))
            {
                Debug.Log("clear");
            }
        }
    }
    public void GoOnClick()
    {
        startSE.Play();
        if (stageScene.transform.localScale == new Vector3 (1,1,1))
        {
            stageScene.transform.DOScale(new Vector3(0, 0, 0), 1f).SetEase(Ease.InBack);
            StartBool.Instance.OpenImage = false;
            Invoke("GoScene", 1);
        }
    }

    public void BackOnClick()
    {
        if (stageScene.transform.localScale == new Vector3(1, 1, 1))
        {
            audioSource.Play();
            stageScene.transform.DOScale(new Vector3(0, 0, 0), 1f).SetEase(Ease.InBack);
        }
    }

    //アニメーションを再生してステージに移動
    public void GoScene()
    {
        Ghost.transform.DOMoveX(80f, 3);
        fade.FadeIn(3.5f, () =>
        {
            SceneManager.LoadScene(LoadScene);
        });
    }
    public void playImage()
    {
        if (StartBool.Instance.OpenImage)
        {
            audioSource.Play();
            stage1.transform.localScale = new Vector3(0, 0, 0);
            stage2.transform.localScale = new Vector3(0, 0, 0);
            stage3.transform.localScale = new Vector3(0, 0, 0);
            if (playText.text == "遊び方" || playLueL.transform.localScale == new Vector3(0, 0, 0))
            {
                playText.text = "閉じる";
                playLueL.transform.DOScale(new Vector3(1, 1, 1), 1f).SetEase(Ease.OutBack);
            }
            else if (playText.text == "閉じる" || playLueL.transform.localScale == new Vector3(1, 1, 1))
            {
                playText.text = "遊び方";
                playLueL.transform.DOScale(new Vector3(0, 0, 0), 1f).SetEase(Ease.InBack);
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        stage1.SetActive(true);
        stage2.SetActive(true);
        stage3.SetActive(true);
        playLueL.SetActive(true);
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playLueL.transform.localScale == new Vector3(0, 0, 0))
        {
            playText.text = "遊び方";
        }
        else if (playLueL.transform.localScale == new Vector3(1, 1, 1))
        {
            playText.text = "閉じる";
        }
    }
}
