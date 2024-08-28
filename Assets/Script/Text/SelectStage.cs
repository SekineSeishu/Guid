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
    [SerializeField] private Fade fade;//�t�F�C�h
    [SerializeField] private GameObject stage1;//�X�e�[�W�P�̃{�^��
    [SerializeField] private GameObject stage2;//�X�e�[�W2�̃{�^��
    [SerializeField] private GameObject stage3;//�X�e�[�W3�̃{�^��
    [SerializeField] private GameObject stageScene;//�ڍו\�����Ă���X�e�[�W�{�^��
    [SerializeField] private GameObject playLueL;//���[��UI
    [SerializeField] private GameObject Ghost;//�A�j���[�V�����̃L�����N�^�[
    private Animator animator;
    [SerializeField] private AudioSource audioSource;//SE�𗬂���
    [SerializeField] private AudioClip startSE;//�X�e�[�W�ړ�����ۂ�SE
    [SerializeField] private AudioClip buttonSE;//�{�^���������Ƃ���SE
    [SerializeField] private TextMeshProUGUI playText;//���[���{�^���̃e�L�X�g

    private string loadScene;//���[�h�V�[����
    private bool onClose;//�ڍ׉�ʃt���O


    void Start()
    {
        //������
        LisetUI();
        onClose = true;
        audioSource = GetComponent<AudioSource>();
    }

    //�S�Ă̏ڍ׉�ʂ̃T�C�Y��0�ɂ���
    public void LisetUI()
    {
        stage1.transform.localScale = new Vector3(0, 0, 0);
        stage2.transform.localScale = new Vector3(0, 0, 0);
        stage3.transform.localScale = new Vector3(0, 0, 0);
        playLueL.transform.localScale = new Vector3(0, 0, 0);
    }

    void Update()
    {
        if (onClose)//�ڍ׉�ʃt���O��true(�����J����Ă��Ȃ�)
        {
            if (stageScene.transform.localScale == new Vector3(0, 0, 0)) //�I���ڍ׉�ʂ̊��S�ɕ�����
            {
                stageScene = null;//�I���ڍ׉�ʂ�null�ɂ���
            }
        }
    }

    //���ꂼ���UI���A�j���[�V���������ĕ\������
    public void SelectOnClick1()//�X�e�[�W�P�̏ڍו\��
    {
        if (!stageScene)
        {
            //�ڍ׉�ʃT�C�Y���P�ɂ��ĕ\�����I���ڍ׉�ʂɐݒ肷��(�ڍ׉�ʃt���O��false��)
            onClose = false; 
            audioSource.PlayOneShot(buttonSE);
            LisetUI();
            stage1.transform.DOScale(new Vector3(1, 1, 1), 1f).SetEase(Ease.OutBack);
            stageScene = stage1;
            loadScene = "stage1";
            Debug.Log("�X�e�[�W1");
        }
    }
    public void SelectOnClick2()//�X�e�[�W2�̏ڍו\��
    {
        if (!stageScene)
        {
            //�ڍ׉�ʃT�C�Y���P�ɂ��ĕ\�����I���ڍ׉�ʂɐݒ肷��(�ڍ׉�ʃt���O��false��)
            onClose = false;
            audioSource.PlayOneShot(buttonSE);
            LisetUI();
            stage2.transform.DOScale(new Vector3(1, 1, 1), 1f).SetEase(Ease.OutBack);
            stageScene = stage2;
            loadScene = "stage2";
            Debug.Log("�X�e�[�W2");
        }
    }
    public void SelectOnClick3()//�X�e�[�W3�̏ڍו\��
    {
        if (!stageScene)
        {
            //�ڍ׉�ʃT�C�Y���P�ɂ��ĕ\�����I���ڍ׉�ʂɐݒ肷��(�ڍ׉�ʃt���O��false��)
            onClose = false;
            audioSource.PlayOneShot(buttonSE);
            LisetUI();
            stage3.transform.DOScale(new Vector3(1, 1, 1), 1f).SetEase(Ease.OutBack);
            stageScene = stage3;
            loadScene = "stage3";
            Debug.Log("�X�e�[�W3");
        }
    }

    public void LueLImage()//���[��UI��\������
    {
        //�e�L�X�g�̕����Əڍ׉�ʃt���O�ɉ����Ď��s���ʂ�ς���
        if (!stageScene && playText.text == "�V�ѕ�")
        {
            //�ڍ׉�ʂ�\��
            onClose = false;
            audioSource.PlayOneShot(buttonSE);
            LisetUI();
            playText.text = "����";
            playLueL.transform.DOScale(new Vector3(1, 1, 1), 1f).SetEase(Ease.OutBack);
            stageScene = playLueL;
        }
        else if (stageScene == playLueL && playText.text == "����")
        {
            //�ڍ׉�ʂ�����
            onClose = true;
            audioSource.PlayOneShot(buttonSE);
            playText.text = "�V�ѕ�";
            playLueL.transform.DOScale(new Vector3(0, 0, 0), 1f).SetEase(Ease.InBack);
        }
    }

    public void GoStageClick()
    {
        //�ڍ׉�ʕ\����
        if (stageScene)
        {
            //�X�e�[�W�ړ�
            onClose = true;
            audioSource.PlayOneShot(startSE);
            stageScene.transform.DOScale(new Vector3(0, 0, 0), 1f).SetEase(Ease.InBack);
            Invoke("GoScene", 1);
        }
    }

    public void BackOnClick()
    {
        //�ڍ׉�ʕ\����
        if (stageScene)
        {
            //�I���X�e�[�W�̏ڍ׉�ʂ����
            onClose = true;
            audioSource.PlayOneShot(buttonSE);
            stageScene.transform.DOScale(new Vector3(0, 0, 0), 1f).SetEase(Ease.InBack);
        }
    }

    //�A�j���[�V�������Đ����ăX�e�[�W�Ɉړ�
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
