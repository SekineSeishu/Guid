using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BloomManager : MonoBehaviour
{
    public static BloomManager Instance;
    public GameObject cameraA;
    public GameObject BloomA;
    public GameObject tutorialText1;
    public GameObject tutorialText2;
    public GameObject tutorialText3;
    public GameObject tutorialText4;
    private GameObject selectBloom;
    public int layerNumber1;
    public int layerNumber2;
    private bool playTutorial;

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
        if (playTutorial)
        {
            tutorialText1.SetActive(false);
            tutorialText2.SetActive(true);
        }
        selectBloom = selectCharacter;
        selectCharacter.SetLayerRecursively(layerNumber2);
        BloomA.layer = layerNumber2;
    }
    public void ChangeBloom()
    {
        if (playTutorial)
        {
            tutorialText2.SetActive(false);
            tutorialText3.SetActive(true);
        }
            Invoke("tutorial2", 2);
    }
    public void tutorial2()
    {
        tutorialText3.SetActive(false);
        if (playTutorial)
        {
            tutorialText4.SetActive(true);
            playTutorial = false;
        }
    }
    public void ClearBloom()
    {
        selectBloom.SetLayerRecursively(layerNumber1);
    }
}
