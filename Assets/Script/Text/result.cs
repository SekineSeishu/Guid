using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class result : MonoBehaviour
{
    public GameManager GM;
    //ステージごとに実績を作ってリザルトで表示する
    public GameObject OneStar;//リザルトで出す星1
    public GameObject TwoStar;//リザルトで出す星2
    public GameObject ThreeStar;//リザルトで出す星3
    public int OneCount;//移動回数以内１
    public int TwoCount;//移動回数以内２
    private AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        //星のサイズを0にして見えなくする
        OneStar.transform.localScale = new Vector3(0, 0, 0);
        TwoStar.transform.localScale = new Vector3(0, 0, 0);
        ThreeStar.transform.localScale = new Vector3(0, 0, 0);

        //DoTweenを使ってモーションを付けながらリザルトを表示する
        this.transform.DOScale(new Vector3(1, 1, 1), 1f).SetEase(Ease.OutBack);
        //リザルトが表示されたら実績の確認をする
        if (gameObject.transform.localScale == new Vector3(1,1,1))
        {
            Debug.Log("clear");
            Debug.Log(GM.PlayCount);
            //クリア時にそれぞれの条件を達成しているかの確認
            if (GM.PlayCount > OneCount)//残り移動回数が指定回数以内
            {
                Invoke("oneStar", 1);
            }
            if (GM.PlayCount > TwoCount)//残り移動回数が指定回数以内
            {
                Invoke("twoStar", 2);
            }
            Invoke("threeStar", 3);//ステージクリア
        }
    }

    void Update()
    {

    }

    //達成していた場合星の獲得演出を実行する
    private void oneStar()
    {
        OneStar.SetActive(true);
        OneStar.transform.DOScale(new Vector3(1, 1, 1), 1f).SetEase(Ease.OutBack);
    }
    private void twoStar()
    {
        TwoStar.SetActive(true);
        TwoStar.transform.DOScale(new Vector3(1, 1, 1), 1f).SetEase(Ease.OutBack);
    }
    private void threeStar()
    {
        ThreeStar.SetActive(true);
        ThreeStar.transform.DOScale(new Vector3(1, 1, 1), 1f).SetEase(Ease.OutBack);
    }
}
