using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BloomManager : MonoBehaviour
{
    //チュートリアル時の演出
    public static BloomManager Instance;
    public GameObject cameraA;//カメラ
    public GameObject BloomA;//ブルーム
    private GameObject selectBloom;//ブルームをかけているキャラクター
    public int layerNumber1;//レイヤー１
    public int layerNumber2;//レイヤー２

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
        //選択されたキャラクターにBloomをかける
        //すでにキャラクターが選択されていた場合そのキャラクターのBloomを切る
        if (selectBloom != null)
        {
            ClearBloom();
        }
        selectBloom = selectCharacter;
        selectCharacter.SetLayerRecursively(layerNumber2);
        BloomA.layer = layerNumber2;
    }

    //ブルームを戻す
    public void ClearBloom()
    {
        selectBloom.SetLayerRecursively(layerNumber1);
    }
}
