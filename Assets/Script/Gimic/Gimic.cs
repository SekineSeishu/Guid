using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gimic : MonoBehaviour
{
    public static Gimic Instance;
    public GameObject activeGimic;//ブロック等を出現させるギミック
    public GameObject worp;//ワープギミック
    private AudioSource audio;//SEを流す先
    public bool onWorp;//ワープフラグ
    private Character character;//キャラクター

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
        //赤キャラクターが赤ギミックを踏んだら実行
        if (character.type == characterType.Red && gameObject.tag == "RedGimic")
        {
            //隠していたオブジェクトを表示する
            audio.Play();
            activeGimic.SetActive(true);
            Debug.Log("赤ギミック起動");
            //チュートリアルステージだったら説明を消す
            if (tutorialManager.instance.gameObject.activeInHierarchy)
            {
                tutorialManager.instance.tutorialText4.SetActive(false);
            }
        }
        //青キャラクターが青ギミックを踏んだら実行
        if (character.type == characterType.Blue && gameObject.tag == "BlueGimic")
        {
            audio.Play();
            activeGimic.SetActive(true);
        }
        //ワープギミック
        if (gameObject.tag == "worp")
        {
            if (other.gameObject.tag == "Character")
            {
                //ワープ可能＆ワープ先にキャラクターがいなかったら実行
                if (character.OnWorp && GetWorp(worp.transform))
                {
                    this.character = other.GetComponent<Character>();
                    Invoke("Worp", 1);
                }
            }
        }
    }

    //プレイヤーをワープする
    public void Worp()
    {
        if (worp.activeInHierarchy)
        {
            //キャラクターの現在位置をワープ先に更新する
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

        //ワープ先にキャラクターがいた場合ワープしない
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
