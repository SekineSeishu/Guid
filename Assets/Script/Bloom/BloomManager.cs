using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BloomManager : MonoBehaviour
{
    //�`���[�g���A�����̉��o
    public static BloomManager Instance;
    public GameObject cameraA;//�J����
    public GameObject BloomA;//�u���[��
    public GameObject tutorialText1;//�`���[�g���A���e�L�X�g�P
    public GameObject tutorialText2;//�`���[�g���A���e�L�X�g�Q
    public GameObject tutorialText3;//�`���[�g���A���e�L�X�g�R
    public GameObject tutorialText4;//�`���[�g���A���e�L�X�g�S
    private GameObject selectBloom;//�u���[���������Ă���L�����N�^�[
    public int layerNumber1;//���C���[�P
    public int layerNumber2;//���C���[�Q
    private bool playTutorial;//�`���[�g���A���t���O

    public void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        //�`���[�g���A���X�e�[�W�̏ꍇ�Ƀ`���[�g���A���e�L�X�g�̕\�����\�ɂ���
        if (SceneManager.GetActiveScene().name == "stage")
        {
            playTutorial = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Camera bloomCamera = cameraA.GetComponent<Camera>();
        bloomCamera.Render();
    }

    public void GoGhost(GameObject selectCharacter)
    {
        //�I�����ꂽ�L�����N�^�[��Bloom��������
        //���łɃL�����N�^�[���I������Ă����ꍇ���̃L�����N�^�[��Bloom��؂�
        if (selectBloom != null)
        {
            ClearBloom();
        }
        //�`���[�g���A���X�e�[�W�Ȃ玟�̃`���[�g���A���e�L�X�g���o��
        if (playTutorial)
        {
            tutorialText1.SetActive(false);
            tutorialText2.SetActive(true);
        }
        selectBloom = selectCharacter;
        selectCharacter.SetLayerRecursively(layerNumber2);
        BloomA.layer = layerNumber2;
    }
    //���̃`���[�g���A���e�L�X�g
    public void ChangeBloom()//�ړ��\����N���b�N��
    {
        if (playTutorial)
        {
            tutorialText2.SetActive(false);
            tutorialText3.SetActive(true);
        }
            Invoke("tutorial2", 2);
    }

    //�Ō�̃`���[�g���A���e�L�X�g��\������
    public void rastTutolial()
    {
        tutorialText3.SetActive(false);
        if (playTutorial)
        {
            tutorialText4.SetActive(true);
            playTutorial = false;//�`���[�g���A���t���O��OFF�ɂ���
        }
    }

    //�u���[����߂�
    public void ClearBloom()
    {
        selectBloom.SetLayerRecursively(layerNumber1);
    }
}
