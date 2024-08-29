using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class result : MonoBehaviour
{
    [SerializeField] private GameManager GM;
    //ステージごとに実績を作ってリザルトで表示する
    [SerializeField] private GameObject OneStar;//リザルトで出す星1
    [SerializeField] private GameObject TwoStar;//リザルトで出す星2
    [SerializeField] private GameObject ThreeStar;//リザルトで出す星3
    [SerializeField] private AudioClip getStarSE;
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
        StartCoroutine(GetStar());
    }

    private IEnumerator GetStar()
    {
        yield return new WaitForSeconds(1);
        Debug.Log("clear");
        Debug.Log(GM.PlayCount);

        //クリア時にそれぞれの条件を達成しているかの確認
        //達成していた場合星の獲得演出を実行する
        if (GM.PlayCount > OneCount)//残り移動回数が指定回数以内
        {
            yield return new WaitForSeconds(1);
            Debug.Log("one");
            audio.PlayOneShot(getStarSE);
            OneStar.transform.DOScale(new Vector3(1, 1, 1), 1f).SetEase(Ease.OutBack);
        }
        if (GM.PlayCount > TwoCount)//残り移動回数が指定回数以内
        {
            yield return new WaitForSeconds(1);
            Debug.Log("two");
            audio.PlayOneShot(getStarSE);
            TwoStar.transform.DOScale(new Vector3(1, 1, 1), 1f).SetEase(Ease.OutBack);
        }
        Debug.Log("Three");
        //ステージクリア
        yield return new WaitForSeconds(1);
        audio.PlayOneShot(getStarSE);
        ThreeStar.transform.DOScale(new Vector3(1, 1, 1), 1f).SetEase(Ease.OutBack); 
    }
    void Update()
    {
       
    }
}
