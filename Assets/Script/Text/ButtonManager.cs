using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UniRx;
using UnityEngine.UI;

enum ButtonType//ボタンの種類
{
    select,
    retry,
    next
}
public class ButtonManager : MonoBehaviour
{

    [SerializeField] private Button selectButton;//選択画面に戻るボタン
    [SerializeField] private Button retryButton;//リトライボタン
    [SerializeField] private Button nextButton;//次のステージ移動ボタン
    [SerializeField] private AudioClip clickSE;//ボタンを押したときのSE
    public string   nextLoadScene;//次のステージ名
    public string   retryLoadScene;//今のステージ名
    private AudioSource audio;
    public FadeIN fade;

    void Start()
    {
        audio = GetComponent<AudioSource>();
        //それぞれのボタンの種類を決める
        var button1 = selectButton.OnClickAsObservable().Select(_ => ButtonType.select);
        var button2 = retryButton.OnClickAsObservable().Select(_ => ButtonType.retry);
        var button3 = nextButton.OnClickAsObservable().Select(_ => ButtonType.next);

        //押されたボタンごとに実行を変える
        Observable.Merge(button1, button2, button3)
            .ThrottleFirst(System.TimeSpan.FromSeconds(10))
            .Subscribe(x =>
            {
                Debug.Log("ボタンが押された");
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
            }).AddTo(this);
    }

    //ステージ選択画面に戻る
    public void Select()
    {
        audio.PlayOneShot(clickSE);
        SceneManager.LoadScene("selectStage");
    }

    //リトライする
    public void retry()
    {
        audio.PlayOneShot(clickSE);
        fade.In(retryLoadScene);
    }

    //次のステージに移動する
    public void Next()
    {
        audio.PlayOneShot(clickSE);
        fade.In(nextLoadScene);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
