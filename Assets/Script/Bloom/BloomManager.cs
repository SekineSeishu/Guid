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
    private GameObject selectBloom;//�u���[���������Ă���L�����N�^�[
    public int layerNumber1;//���C���[�P
    public int layerNumber2;//���C���[�Q

    public void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {

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
        selectBloom = selectCharacter;
        selectCharacter.SetLayerRecursively(layerNumber2);
        BloomA.layer = layerNumber2;
    }

    //�u���[����߂�
    public void ClearBloom()
    {
        selectBloom.SetLayerRecursively(layerNumber1);
    }
}
