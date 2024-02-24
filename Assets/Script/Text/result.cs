using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class result : MonoBehaviour
{
    public GameManager GM;
    public GameObject OneStar;
    public GameObject TwoStar;
    public GameObject ThreeStar;
    public int OneCount;
    public int TwoCount;
    private AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        OneStar.transform.localScale = new Vector3(0, 0, 0);
        TwoStar.transform.localScale = new Vector3(0, 0, 0);
        ThreeStar.transform.localScale = new Vector3(0, 0, 0);
        this.transform.DOScale(new Vector3(1, 1, 1), 1f).SetEase(Ease.OutBack);
        if (gameObject.transform.localScale == new Vector3(1,1,1))
        {
            Debug.Log("clear");
            Debug.Log(GM.PlayCount);
            //クリア時にそれぞれの条件を達成しているかの確認
            if (GM.PlayCount > OneCount)
            {
                Invoke("oneStar", 1);
            }
            if (GM.PlayCount > TwoCount)
            {
                Invoke("twoStar", 2);
            }
            Invoke("threeStar", 3);
        }
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

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.localScale == new Vector3(1, 1, 1))
        {
            Debug.Log("clear");
            if (GameManager.Instance.PlayCount > OneCount)
            {
                Invoke("oneStar", 1);
            }
            if (GameManager.Instance.PlayCount > TwoCount)
            {
                Invoke("twoStar", 2);
            }
            Invoke("threeStar", 3);
        }
    }
}
