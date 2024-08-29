using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using DG.Tweening;

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
    private bool setTime;//リザルト出すための待ち時間
    private AudioSource audio;
    [SerializeField] private GameObject GameOverText;
    [SerializeField] private AudioClip cickSE;//キャラクタークリック時のSE
    [SerializeField] private AudioClip endSE;//クリアSE

    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {

        //ステージごとの移動回数上限の設定
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
        playCountText.text = PlayCount.ToString();//移動回数表示
        if (Input.GetMouseButtonDown(0))
        {
            //移動可能状態でかつ移動可能回数が0になっていない場合実行
            if (Play && PlayCount != 0)
            {
                GetCharacter();
            }
        }
        //クリア時の演出
        if (redCharacter.goal && blueCharacter.goal)
        {
            Debug.Log("clear");
            if (setTime)//一度だけ流す
            {
                setTime= false;

                StartCoroutine(stageClear());
            }
        }
        //ゲームオーバー時の演出
        if (PlayCount == 0　&& (!redCharacter.goal || !blueCharacter.goal))
        {
            if (setTime)
           {
                setTime = false;
                StartCoroutine(GameOver());
            }
        }
    }

    //リザルト表示
    private IEnumerator stageClear()
    {
        yield return new WaitForSeconds(2);
        audio.PlayOneShot(endSE);
        //２秒待ってから表示
        yield return new WaitForSeconds(1);
        resultUI.SetActive(true);
    }

    //移動後ゲームオーバーテキスト表示
    private IEnumerator GameOver()
    {
        yield return new WaitForSeconds(3);
        GameOverText.SetActive(true);
        GameOverText.transform.DOScale(new Vector3(1, 1, 1), 1f).SetEase(Ease.OutBack); ;
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
                audio.PlayOneShot(cickSE);
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
                audio.PlayOneShot(cickSE);
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
