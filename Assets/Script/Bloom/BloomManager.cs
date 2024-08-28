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
    public GameObject tutorialText1;//チュートリアルテキスト１
    public GameObject tutorialText2;//チュートリアルテキスト２
    public GameObject tutorialText3;//チュートリアルテキスト３
    public GameObject tutorialText4;//チュートリアルテキスト４
    private GameObject selectBloom;//ブルームをかけているキャラクター
    public int layerNumber1;//レイヤー１
    public int layerNumber2;//レイヤー２
    private bool playTutorial;//チュートリアルフラグ

    public void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        //チュートリアルステージの場合にチュートリアルテキストの表示を可能にする
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
        //選択されたキャラクターにBloomをかける
        //すでにキャラクターが選択されていた場合そのキャラクターのBloomを切る
        if (selectBloom != null)
        {
            ClearBloom();
        }
        //チュートリアルステージなら次のチュートリアルテキストを出す
        if (playTutorial)
        {
            tutorialText1.SetActive(false);
            tutorialText2.SetActive(true);
        }
        selectBloom = selectCharacter;
        selectCharacter.SetLayerRecursively(layerNumber2);
        BloomA.layer = layerNumber2;
    }
    //次のチュートリアルテキスト
    public void ChangeBloom()//移動可能先をクリック時
    {
        if (playTutorial)
        {
            tutorialText2.SetActive(false);
            tutorialText3.SetActive(true);
        }
            Invoke("tutorial2", 2);
    }

    //最後のチュートリアルテキストを表示する
    public void rastTutolial()
    {
        tutorialText3.SetActive(false);
        if (playTutorial)
        {
            tutorialText4.SetActive(true);
            playTutorial = false;//チュートリアルフラグをOFFにする
        }
    }

    //ブルームを戻す
    public void ClearBloom()
    {
        selectBloom.SetLayerRecursively(layerNumber1);
    }
}
