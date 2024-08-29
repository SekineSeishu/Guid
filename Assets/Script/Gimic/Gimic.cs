using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gimic : MonoBehaviour
{
    public static Gimic Instance;
    public GameObject activeGimic;//�u���b�N�����o��������M�~�b�N
    public GameObject worp;//���[�v�M�~�b�N
    private AudioSource audio;//SE�𗬂���
    public bool onWorp;//���[�v�t���O
    private Character character;//�L�����N�^�[

    public void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Character character = other.gameObject.GetComponent<Character>();
        Debug.Log(character.name);
        //�ԃL�����N�^�[���ԃM�~�b�N�𓥂񂾂���s
        if (character.type == characterType.Red && gameObject.tag == "RedGimic")
        {
            //�B���Ă����I�u�W�F�N�g��\������
            audio.Play();
            activeGimic.SetActive(true);
            Debug.Log("�ԃM�~�b�N�N��");
            //�`���[�g���A���X�e�[�W�����������������
            if (tutorialManager.instance.gameObject.activeInHierarchy)
            {
                tutorialManager.instance.tutorialText4.SetActive(false);
            }
        }
        //�L�����N�^�[���M�~�b�N�𓥂񂾂���s
        if (character.type == characterType.Blue && gameObject.tag == "BlueGimic")
        {
            audio.Play();
            activeGimic.SetActive(true);
        }
        //���[�v�M�~�b�N
        if (gameObject.tag == "worp")
        {
            if (other.gameObject.tag == "Character")
            {
                //���[�v�\�����[�v��ɃL�����N�^�[�����Ȃ���������s
                if (character.OnWorp && GetWorp(worp.transform))
                {
                    this.character = other.GetComponent<Character>();
                    Invoke("Worp", 1);
                }
            }
        }
    }

    //�v���C���[�����[�v����
    public void Worp()
    {
        if (worp.activeInHierarchy)
        {
            //�L�����N�^�[�̌��݈ʒu�����[�v��ɍX�V����
            audio.Play();
            character.transform.position = worp.transform.position;
            character.nowXpos = (int)character.gameObject.transform.position.x;
            character.nowZpos = (int)character.gameObject.transform.position.z;
            character.OnWorp = false;
        }
    }

    private bool GetWorp(Transform worpPosition)
    {
        Collider[] colliders = Physics.OverlapSphere(new Vector3(worpPosition.position.x, worpPosition.position.y, worpPosition.position.z), 0.3f);

        //���[�v��ɃL�����N�^�[�������ꍇ���[�v���Ȃ�
        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag("Character"))
            {
                return false;
            }
        }
        return true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
