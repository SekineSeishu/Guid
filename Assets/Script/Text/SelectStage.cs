using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;
using TMPro;
using UniRx;
using UnityEngine.UI;

public class SelectStage : MonoBehaviour
{
    [SerializeField] private Fade fade;//フェイド
    [SerializeField] private GameObject stage1;//ステージ１のボタン
    [SerializeField] private GameObject stage2;//ステージ2のボタン
    [SerializeField] private GameObject stage3;//ステージ3のボタン
    [SerializeField] private GameObject stageScene;//詳細表示しているステージボタン
    [SerializeField] private GameObject playLueL;//ルールUI
    [SerializeField] private GameObject Ghost;//アニメーションのキャラクター
    private Animator animator;
    [SerializeField] private AudioSource audioSource;//SEを流す先
    [SerializeField] private AudioClip startSE;//ステージ移動する際のSE
    [SerializeField] private AudioClip buttonSE;//ボタン押したときのSE
    [SerializeField] private TextMeshProUGUI playText;//ルールボタンのテキスト

    private string loadScene;//ロードシーン名
    private bool onClose;//詳細画面フラグ


    void Start()
    {
        //初期化
        LisetUI();
        onClose = true;
        audioSource = GetComponent<AudioSource>();
    }

    //全ての詳細画面のサイズを0にする
    public void LisetUI()
    {
        stage1.transform.localScale = new Vector3(0, 0, 0);
        stage2.transform.localScale = new Vector3(0, 0, 0);
        stage3.transform.localScale = new Vector3(0, 0, 0);
        playLueL.transform.localScale = new Vector3(0, 0, 0);
    }

    void Update()
    {
        if (onClose)//詳細画面フラグがtrue(何も開かれていない)
        {
            if (stageScene.transform.localScale == new Vector3(0, 0, 0)) //選択詳細画面の完全に閉じた時
            {
                stageScene = null;//選択詳細画面をnullにする
            }
        }
    }

    //それぞれのUIをアニメーションをつけて表示する
    public void SelectOnClick1()//ステージ１の詳細表示
    {
        if (!stageScene)
        {
            //詳細画面サイズを１にして表示し選択詳細画面に設定する(詳細画面フラグをfalseに)
            onClose = false; 
            audioSource.PlayOneShot(buttonSE);
            LisetUI();
            stage1.transform.DOScale(new Vector3(1, 1, 1), 1f).SetEase(Ease.OutBack);
            stageScene = stage1;
            loadScene = "stage1";
            Debug.Log("ステージ1");
        }
    }
    public void SelectOnClick2()//ステージ2の詳細表示
    {
        if (!stageScene)
        {
            //詳細画面サイズを１にして表示し選択詳細画面に設定する(詳細画面フラグをfalseに)
            onClose = false;
            audioSource.PlayOneShot(buttonSE);
            LisetUI();
            stage2.transform.DOScale(new Vector3(1, 1, 1), 1f).SetEase(Ease.OutBack);
            stageScene = stage2;
            loadScene = "stage2";
            Debug.Log("ステージ2");
        }
    }
    public void SelectOnClick3()//ステージ3の詳細表示
    {
        if (!stageScene)
        {
            //詳細画面サイズを１にして表示し選択詳細画面に設定する(詳細画面フラグをfalseに)
            onClose = false;
            audioSource.PlayOneShot(buttonSE);
            LisetUI();
            stage3.transform.DOScale(new Vector3(1, 1, 1), 1f).SetEase(Ease.OutBack);
            stageScene = stage3;
            loadScene = "stage3";
            Debug.Log("ステージ3");
        }
    }

    public void LueLImage()//ルールUIを表示する
    {
        //テキストの文字と詳細画面フラグに応じて実行結果を変える
        if (!stageScene && playText.text == "遊び方")
        {
            //詳細画面を表示
            onClose = false;
            audioSource.PlayOneShot(buttonSE);
            LisetUI();
            playText.text = "閉じる";
            playLueL.transform.DOScale(new Vector3(1, 1, 1), 1f).SetEase(Ease.OutBack);
            stageScene = playLueL;
        }
        else if (stageScene == playLueL && playText.text == "閉じる")
        {
            //詳細画面を消す
            onClose = true;
            audioSource.PlayOneShot(buttonSE);
            playText.text = "遊び方";
            playLueL.transform.DOScale(new Vector3(0, 0, 0), 1f).SetEase(Ease.InBack);
        }
    }

    public void GoStageClick()
    {
        //詳細画面表示中
        if (stageScene)
        {
            //ステージ移動
            onClose = true;
            audioSource.PlayOneShot(startSE);
            stageScene.transform.DOScale(new Vector3(0, 0, 0), 1f).SetEase(Ease.InBack);
            Invoke("GoScene", 1);
        }
    }

    public void BackOnClick()
    {
        //詳細画面表示中
        if (stageScene)
        {
            //選択ステージの詳細画面を閉じる
            onClose = true;
            audioSource.PlayOneShot(buttonSE);
            stageScene.transform.DOScale(new Vector3(0, 0, 0), 1f).SetEase(Ease.InBack);
        }
    }

    //アニメーションを再生してステージに移動
    public void GoScene()
    {
        Debug.Log("GoScene!");
        Ghost.transform.DOMoveX(80f, 3);
        fade.FadeIn(3.5f, () =>
        {
            SceneManager.LoadScene(loadScene);
        });
    }
}
