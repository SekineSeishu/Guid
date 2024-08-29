using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum characterType//キャラクターの種類
{
    Red,
    Blue
}

public class Character : MonoBehaviour
{
    public characterType type;//キャラクターの種類
    public static Character Instance;
    public MoveDirections moveDirection;//キャラクターの移動方向データ
    public Transform targetPosition;//移動先
    public Transform defaultRotation;//基本の向き
    private float movespeed = 0.7f;//移動スピード
    private Animator animator;
    public bool goal;//赤幽霊のゴールフラグ
    public int nowXpos;//現在のx値
    public int nowZpos;//現在のy値
    public bool OnWorp;//ワープフラグ

    public void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        //初期化　ゴールフラグをOFF
        OnWorp = false;//移動時以外ワープフラグをOFF
        goal = false;
        animator = GetComponent<Animator>();
        //現代の初期位置を渡す
        nowXpos = (int)transform.position.x;
        nowZpos = (int)transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        //キャラクターの移動
        if (targetPosition != null)
        {
            Debug.Log("移動中！");
            transform.LookAt(targetPosition);
            animator.SetBool("run", true);
            transform.position = Vector3.MoveTowards(transform.position, targetPosition.position, movespeed * Time.deltaTime);
            OnWorp = true;//移動中はワープフラグをオンにする
            if (transform.position == targetPosition.position)
            {
                transform.rotation = Quaternion.Euler(-30, 180, 0);
                nowXpos = (int)transform.position.x;
                nowZpos = (int)transform.position.z;
                animator.SetBool("run", false);
                BloomManager.Instance.ClearBloom();
                Destroy(HighlightManager.Instance.selectHighlight);
                targetPosition = null;
                GameManager.Instance.Play = true;
            }
        }
    }
}
