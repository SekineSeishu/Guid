using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

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
    private float setTime;//���U���g�o�����߂̑҂�����
    private AudioSource audio;
    public GameObject GameOverText;
    public AudioClip endSE;//�N���ASE

    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        //�X�e�[�W���Ƃ̈ړ��񐔏���̐ݒ�
        if (SceneManager.GetActiveScene().name == "stage")
        {
            PlayCount = 15;
        }
        else if (SceneManager.GetActiveScene().name == "Stage2")
        {
            PlayCount = 30;
        }
        else if (SceneManager.GetActiveScene().name == "Stage3")
        {
            PlayCount = 20;
        }
        setTime = 0;
        GameOverText.SetActive(false);
        Play = true;
        audio = GetComponent<AudioSource>();
        tutorial = GetComponent<tutorialManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //�ړ��\��Ԃł��ړ��\�񐔂�0�ɂȂ��Ă��Ȃ��ꍇ���s
            if (Play && PlayCount != 0)
            {
                GetCharacter();
            }
        }
        //�N���A���̉��o
        if (redCharacter.redGoal && blueCharacter.blueGoal)
        {
            //�N���A���莞�Ԍo���Ă���SE��UI���o��
            Debug.Log("c");
            setTime += Time.deltaTime;
            if (setTime >= 1f)
            {
                audio.PlayOneShot(endSE);
            }
            Invoke("stageClear", 2f);
        }
        //�Q�[���I�[�o�[���̉��o
        if (PlayCount == 0�@&& (!redCharacter.redGoal || !blueCharacter.blueGoal))
        {
            //��莞�Ԍo���Ă���UI���o��
            setTime += Time.deltaTime;
            if (setTime >= 2f)
            {
                GameOverText.SetActive(true);
            }
        }
        playCountText.text = PlayCount.ToString();
    }

    //���U���g�\��
    private void stageClear()
    {
        resultUI.SetActive(true);
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
                audio.Play();
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
                audio.Play();
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
