using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private GameObject selectCharacter;//選択キャラクター
    public int PlayCount;//移動可能回数
    [SerializeField] private tutorialManager tutorial;
    [SerializeField] private TMP_Text playCountText;//移動可能回数の表示テキスト
    [SerializeField] private GameObject resultUI;//リザルト
    [SerializeField] private Character redCharacter;//赤キャラクター
    [SerializeField] private Character blueCharacter;//青キャラクター
    public bool Play;//移動可能フラグ
    private float setTime;//リザルト出すための待ち時間
    private AudioSource audio;
    public GameObject GameOverText;
    public AudioClip endSE;//クリアSE

    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        //ステージごとの移動回数上限の設定
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
            //移動可能状態でかつ移動可能回数が0になっていない場合実行
            if (Play && PlayCount != 0)
            {
                GetCharacter();
            }
        }
        //クリア時の演出
        if (redCharacter.redGoal && blueCharacter.blueGoal)
        {
            //クリア後一定時間経ってからSEとUIを出す
            Debug.Log("c");
            setTime += Time.deltaTime;
            if (setTime >= 1f)
            {
                audio.PlayOneShot(endSE);
            }
            Invoke("stageClear", 2f);
        }
        //ゲームオーバー時の演出
        if (PlayCount == 0　&& (!redCharacter.redGoal || !blueCharacter.blueGoal))
        {
            //一定時間経ってからUIを出す
            setTime += Time.deltaTime;
            if (setTime >= 2f)
            {
                GameOverText.SetActive(true);
            }
        }
        playCountText.text = PlayCount.ToString();
    }

    //リザルト表示
    private void stageClear()
    {
        resultUI.SetActive(true);
    }
    
    //選択キャラクターを取得
    public void GetCharacter()
    {
        //マウスカーソル先にrayを飛ばす
        GameObject targetObject = null;
        Vector3 mousePosition = Input.mousePosition;

        Ray ray = Camera.main.ScreenPointToRay(mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            targetObject = hit.collider.gameObject;
        }

        //rayを飛ばした先の取得
        if (targetObject != null)
        {
            //キャラクターの場合キャラクターの移動可能方向を取得する
            if (targetObject.tag == "Character")
            {
                Debug.Log(targetObject.name);
                audio.Play();
                selectCharacter = targetObject;
                HighlightManager.Instance.HighlightValidMoves(targetObject.GetComponent<Character>());
                BloomManager.Instance.GoGhost(selectCharacter);
                if (tutorial != null)//チュートリアルステージ
                {
                    tutorial.nextTutorial();
                }
            }
            //移動可能ハイライトの場合その地点の位置を渡す
            if (targetObject.tag == "highlight")
            {
                audio.Play();
                HighlightManager.Instance.CharaMove(selectCharacter.GetComponent<Character>(), targetObject.transform);
                PlayCount--;
                Play = false;
                if (tutorial != null)//チュートリアルステージ
                {
                    tutorial.nextTutorial();
                }
            }
        }
    }
}
