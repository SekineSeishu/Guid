using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorialManager : MonoBehaviour
{
    public static tutorialManager instance;
    public GameObject tutorialText1;//チュートリアルテキスト１
    public GameObject tutorialText2;//チュートリアルテキスト２
    public GameObject tutorialText3;//チュートリアルテキスト３
    public GameObject tutorialText4;//チュートリアルテキスト４

    public void Awake()
    {
        instance = this;
    }
    void Start()
    {
        tutorialText1.SetActive(true);
    }

    public void nextTutorial()
    {
        //表示テキストに応じて次のチュートリアルテキストを表示する
        if (tutorialText1.activeInHierarchy)
        {
            tutorialText1.SetActive(false);
            tutorialText2.SetActive(true);
        }
        else if (tutorialText2.activeInHierarchy)
        {
            tutorialText2.SetActive(false);
            tutorialText3.SetActive(true);
        }
        else if (tutorialText3.activeInHierarchy)
        {
            tutorialText3.SetActive(false);
            tutorialText4.SetActive(true);
        }
    }

        // Update is called once per frame
     void Update()
    {
        
    }
}
