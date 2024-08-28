using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;
using TMPro;

public class SelectStage : MonoBehaviour
{
    public Fade fade;//�t�F�C�h
    public GameObject stage1;//�X�e�[�W�P�̃{�^��
    public GameObject stage2;//�X�e�[�W2�̃{�^��
    public GameObject stage3;//�X�e�[�W3�̃{�^��
    public GameObject stageScene;//�ڍו\�����Ă���X�e�[�W�{�^��
    public GameObject playLueL;//���[��UI
    public string LoadScene;//���[�h�V�[����
    public GameObject Ghost;//�A�j���[�V�����̃L�����N�^�[
    private Animator animator;
    private AudioSource audioSource;//SE�𗬂���
    public AudioSource startSE;//�X�e�[�W�ړ�����ۂ�SE
    public TextMeshProUGUI playText;//���[���{�^���̃e�L�X�g

    //���ꂼ���UI���A�j���[�V���������ĕ\������
    public void SelectOnClick1()//�X�e�[�W�P�̏ڍו\��
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
                Debug.Log("�X�e�[�W1");
            }
        }
    }
    public void SelectOnClick2()//�X�e�[�W2�̏ڍו\��
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
                Debug.Log("�X�e�[�W2");
            }
        }
    }
    public void SelectOnClick3()//�X�e�[�W3�̏ڍו\��
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
                Debug.Log("�X�e�[�W3");
            }
        }
    }
    public void GoOnClick()//�X�e�[�W�ړ�
    {
        startSE.Play();
        if (stageScene.transform.localScale == new Vector3 (1,1,1))
        {
            stageScene.transform.DOScale(new Vector3(0, 0, 0), 1f).SetEase(Ease.InBack);
            StartBool.Instance.OpenImage = false;
            Invoke("GoScene", 1);
        }
    }

    public void BackOnClick()//�I���X�e�[�W�̏ڍ׉�ʂ����
    {
        if (stageScene.transform.localScale == new Vector3(1, 1, 1))
        {
            audioSource.Play();
            stageScene.transform.DOScale(new Vector3(0, 0, 0), 1f).SetEase(Ease.InBack);
        }
    }

    //�A�j���[�V�������Đ����ăX�e�[�W�Ɉړ�
    public void GoScene()
    {
        Ghost.transform.DOMoveX(80f, 3);
        fade.FadeIn(3.5f, () =>
        {
            SceneManager.LoadScene(LoadScene);
        });
    }
    public void playImage()//���[��UI��\������
    {
        if (StartBool.Instance.OpenImage)
        {
            audioSource.Play();
            stage1.transform.localScale = new Vector3(0, 0, 0);
            stage2.transform.localScale = new Vector3(0, 0, 0);
            stage3.transform.localScale = new Vector3(0, 0, 0);
            //���[���{�^�����e�L�X�g�̕����ɂ���Ď��s��ς���
            if (playText.text == "�V�ѕ�" || playLueL.transform.localScale == new Vector3(0, 0, 0))
            {
                playText.text = "����";
                playLueL.transform.DOScale(new Vector3(1, 1, 1), 1f).SetEase(Ease.OutBack);
            }
            else if (playText.text == "����" || playLueL.transform.localScale == new Vector3(1, 1, 1))
            {
                playText.text = "�V�ѕ�";
                playLueL.transform.DOScale(new Vector3(0, 0, 0), 1f).SetEase(Ease.InBack);
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        //������
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
