using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private GameObject selectCharacter;//�I���L�����N�^�[
    public int PlayCount;//�ړ��\��
    [SerializeField] private tutorialManager tutorial;
    [SerializeField] private TMP_Text playCountText;//�ړ��\�񐔂̕\���e�L�X�g
    [SerializeField] private GameObject resultUI;//���U���g
    [SerializeField] private Character redCharacter;//�ԃL�����N�^�[
    [SerializeField] private Character blueCharacter;//�L�����N�^�[
    public bool Play;//�ړ��\�t���O
    private bool setTime;//���U���g�o�����߂̑҂�����
    private AudioSource audio;
    [SerializeField] private GameObject GameOverText;
    [SerializeField] private AudioClip cickSE;//�L�����N�^�[�N���b�N����SE
    [SerializeField] private AudioClip endSE;//�N���ASE

    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {

        //�X�e�[�W���Ƃ̈ړ��񐔏���̐ݒ�
        if (SceneManager.GetActiveScene().name == "stage1")
        {
            PlayCount = 50;
        }
        else if (SceneManager.GetActiveScene().name == "Stage2")
        {
            PlayCount = 20;
        }
        else if (SceneManager.GetActiveScene().name == "Stage3")
        {
            PlayCount = 30;
        }
        //setTime = 0;
        GameOverText.SetActive(false);
        setTime = true;
        Play = true;
        audio = GetComponent<AudioSource>();
        tutorial = GetComponent<tutorialManager>();
    }

    // Update is called once per frame
    void Update()
    {
        playCountText.text = PlayCount.ToString();//�ړ��񐔕\��
        if (Input.GetMouseButtonDown(0))
        {
            //�ړ��\��Ԃł��ړ��\�񐔂�0�ɂȂ��Ă��Ȃ��ꍇ���s
            if (Play && PlayCount != 0)
            {
                GetCharacter();
            }
        }
        //�N���A���̉��o
        if (redCharacter.goal && blueCharacter.goal)
        {
            Debug.Log("clear");
            if (setTime)//��x��������
            {
                setTime= false;

                StartCoroutine(stageClear());
            }
        }
        //�Q�[���I�[�o�[���̉��o
        if (PlayCount == 0�@&& (!redCharacter.goal || !blueCharacter.goal))
        {
            if (setTime)
           {
                setTime = false;
                StartCoroutine(GameOver());
            }
        }
    }

    //���U���g�\��
    private IEnumerator stageClear()
    {
        yield return new WaitForSeconds(2);
        audio.PlayOneShot(endSE);
        //�Q�b�҂��Ă���\��
        yield return new WaitForSeconds(1);
        resultUI.SetActive(true);
    }

    //�ړ���Q�[���I�[�o�[�e�L�X�g�\��
    private IEnumerator GameOver()
    {
        yield return new WaitForSeconds(3);
        GameOverText.SetActive(true);
        GameOverText.transform.DOScale(new Vector3(1, 1, 1), 1f).SetEase(Ease.OutBack); ;
    }
    
    //�I���L�����N�^�[���擾
    public void GetCharacter()
    {
        //�}�E�X�J�[�\�����ray���΂�
        GameObject targetObject = null;
        Vector3 mousePosition = Input.mousePosition;

        Ray ray = Camera.main.ScreenPointToRay(mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            targetObject = hit.collider.gameObject;
        }

        //ray���΂�����̎擾
        if (targetObject != null)
        {
            //�L�����N�^�[�̏ꍇ�L�����N�^�[�̈ړ��\�������擾����
            if (targetObject.tag == "Character")
            {
                Debug.Log(targetObject.name);
                audio.PlayOneShot(cickSE);
                selectCharacter = targetObject;
                HighlightManager.Instance.HighlightValidMoves(targetObject.GetComponent<Character>());
                BloomManager.Instance.GoGhost(selectCharacter);
                if (tutorial != null)//�`���[�g���A���X�e�[�W
                {
                    tutorial.nextTutorial();
                }
            }
            //�ړ��\�n�C���C�g�̏ꍇ���̒n�_�̈ʒu��n��
            if (targetObject.tag == "highlight")
            {
                audio.PlayOneShot(cickSE);
                HighlightManager.Instance.CharaMove(selectCharacter.GetComponent<Character>(), targetObject.transform);
                PlayCount--;
                Play = false;
                if (tutorial != null)//�`���[�g���A���X�e�[�W
                {
                    tutorial.nextTutorial();
                }
            }
        }
    }
}
