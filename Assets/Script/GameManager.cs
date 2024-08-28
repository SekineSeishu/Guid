using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    private GameObject selectCharacter;
    public int PlayCount;
    public TMP_Text playCountText;
    public GameObject resultUI;
    public Character redGoal;
    public Character blueGoal;
    public static GameManager Instance;
    public bool Play;
    private float SETime;
    private AudioSource audio;
    public GameObject GameOverText;
    public GameObject endSE;

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
        SETime = 0;
        endSE.SetActive(false);
        GameOverText.SetActive(false);
        Play = true;
        audio = GetComponent<AudioSource>();
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
        if (redGoal.redGoal && blueGoal.blueGoal)
        {
            Debug.Log("c");
            SETime += Time.deltaTime;
            if (SETime >= 1f)
            {
                endSE.SetActive(true);
            }
            Invoke("stageClear", 2f);
        }
        //�Q�[���I�[�o�[���̉��o
        if (PlayCount == 0�@&& (!redGoal.redGoal || !blueGoal.blueGoal))
        {
            SETime += Time.deltaTime;
            if (SETime >= 2f)
            {
                GameOverText.SetActive(true);
            }
        }
        playCountText.text = PlayCount.ToString();
    }

    private void stageClear()
    {
        resultUI.SetActive(true);
    }
    
    public void GetCharacter()
    {
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
            }
            //�ړ��\�n�C���C�g�̏ꍇ���̒n�_�̈ʒu��n��
            if (targetObject.tag == "highlight")
            {
                audio.Play();
                HighlightManager.Instance.CharaMove(selectCharacter.GetComponent<Character>(), targetObject.transform);
                PlayCount--;
                Play = false;
                BloomManager.Instance.ChangeBloom();
            }
        }
    }
}
