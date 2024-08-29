using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UniRx;
using UnityEngine.UI;

enum ButtonType
{
    select,
    retry,
    next
}
public class ButtonManager : MonoBehaviour
{

    [SerializeField] private Button selectButton;//�I����ʂɖ߂�{�^��
    [SerializeField] private Button retryButton;//���g���C�{�^��
    [SerializeField] private Button nextButton;//���̃X�e�[�W�ړ��{�^��
    [SerializeField] private AudioClip clickSE;//�{�^�����������Ƃ���SE
    public string   nextLoadScene;//���̃X�e�[�W��
    public string   retryLoadScene;//���̃X�e�[�W��
    private AudioSource audio;
    public FadeIN fade;

    void Start()
    {
        audio = GetComponent<AudioSource>();
        //�A�Ŗh�~
        var button1 = selectButton.OnClickAsObservable().Select(_ => ButtonType.select);
        var button2 = retryButton.OnClickAsObservable().Select(_ => ButtonType.retry);
        var button3 = nextButton.OnClickAsObservable().Select(_ => ButtonType.next);

        //�����ꂽ�{�^�����ƂɎ��s��ς���
        Observable.Merge(button1, button2, button3)
            .ThrottleFirst(System.TimeSpan.FromSeconds(10))
            .Subscribe(x =>
            {
                Debug.Log("�{�^���������ꂽ");
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

    //�X�e�[�W�I����ʂɖ߂�
    public void Select()
    {
        audio.PlayOneShot(clickSE);
        SceneManager.LoadScene("selectStage");
    }

    //���g���C����
    public void retry()
    {
        audio.PlayOneShot(clickSE);
        fade.In(retryLoadScene);
    }

    //���̃X�e�[�W�Ɉړ�����
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
