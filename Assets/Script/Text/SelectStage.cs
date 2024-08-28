using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;
using TMPro;

public class SelectStage : MonoBehaviour
{
    public Fade fade;//フェイド
    public GameObject stage1;//ステージ１のボタン
    public GameObject stage2;//ステージ2のボタン
    public GameObject stage3;//ステージ3のボタン
    public GameObject stageScene;//詳細表示しているステージボタン
    public GameObject playLueL;//ルールUI
    public string LoadScene;//ロードシーン名
    public GameObject Ghost;//アニメーションのキャラクター
    private Animator animator;
    private AudioSource audioSource;//SEを流す先
    public AudioSource startSE;//ステージ移動する際のSE
    public TextMeshProUGUI playText;//ルールボタンのテキスト

    //それぞれのUIをアニメーションをつけて表示する
    public void SelectOnClick1()//ステージ１の詳細表示
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
                Debug.Log("ステージ1");
            }
        }
    }
    public void SelectOnClick2()//ステージ2の詳細表示
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
                Debug.Log("ステージ2");
            }
        }
    }
    public void SelectOnClick3()//ステージ3の詳細表示
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
                Debug.Log("ステージ3");
            }
        }
    }
    public void GoOnClick()//ステージ移動
    {
        startSE.Play();
        if (stageScene.transform.localScale == new Vector3 (1,1,1))
        {
            stageScene.transform.DOScale(new Vector3(0, 0, 0), 1f).SetEase(Ease.InBack);
            StartBool.Instance.OpenImage = false;
            Invoke("GoScene", 1);
        }
    }

    public void BackOnClick()//選択ステージの詳細画面を閉じる
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
    public void playImage()//ルールUIを表示する
    {
        if (StartBool.Instance.OpenImage)
        {
            audioSource.Play();
            stage1.transform.localScale = new Vector3(0, 0, 0);
            stage2.transform.localScale = new Vector3(0, 0, 0);
            stage3.transform.localScale = new Vector3(0, 0, 0);
            //ルールボタンをテキストの文字によって実行を変える
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
        //初期化
        stage1.SetActive(true);
        stage2.SetActive(true);
        stage3.SetActive(true);
        playLueL.SetActive(true);
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
