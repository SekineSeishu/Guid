using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorialManager : MonoBehaviour
{
    public static tutorialManager instance;
    public GameObject tutorialText1;//�`���[�g���A���e�L�X�g�P
    public GameObject tutorialText2;//�`���[�g���A���e�L�X�g�Q
    public GameObject tutorialText3;//�`���[�g���A���e�L�X�g�R
    public GameObject tutorialText4;//�`���[�g���A���e�L�X�g�S

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
        //�\���e�L�X�g�ɉ����Ď��̃`���[�g���A���e�L�X�g��\������
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
