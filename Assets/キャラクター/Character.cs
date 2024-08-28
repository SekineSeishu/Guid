using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Character : MonoBehaviour
{
    public static Character Instance;
    public Transform targetPosition;
    public Transform defaultRotation;
    private float movespeed = 0.7f;
    private Animator animator;
    public bool redGoal;
    public bool blueGoal;
    public bool red;
    public bool blue;
    public int nowXpos;
    public int nowZpos;
    public bool OnWorp;

    public void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        OnWorp = false;
        redGoal = false;
        blueGoal = false;
        animator = GetComponent<Animator>();
        nowXpos = (int)transform.position.x;
        nowZpos = (int)transform.position.z;
    }

    //それぞれの移動可能方向一覧
    public List<Vector3> GetValidMove()
    {
        List<Vector3> validMoves = new List<Vector3>();
        if (blue)
        {
            Debug.Log("x:" + nowXpos + "z:" + nowZpos);
            if (SceneManager.GetActiveScene().name == "stage")
            {
                //上
                validMoves.Add(new Vector3(nowXpos, 0.5f, nowZpos + 1));
                //下
                validMoves.Add(new Vector3(nowXpos, 0.5f, nowZpos - 1));
                //右
                validMoves.Add(new Vector3(nowXpos + 1, 0.5f, nowZpos));
                //左
                validMoves.Add(new Vector3(nowXpos - 1, 0.5f, nowZpos));
            }
            else if (SceneManager.GetActiveScene().name == "Stage2")
            {
                //左上
                validMoves.Add(new Vector3(nowXpos - 1, 0.5f, nowZpos + 1));
                //左下
                validMoves.Add(new Vector3(nowXpos - 1, 0.5f, nowZpos - 1));
                //右
                validMoves.Add(new Vector3(nowXpos + 1, 0.5f, nowZpos));
            }
            else if (SceneManager.GetActiveScene().name == "Stage3")
            {
                //上
                validMoves.Add(new Vector3(nowXpos, 0.5f, nowZpos + 1));
                //右
                validMoves.Add(new Vector3(nowXpos + 1, 0.5f, nowZpos));
                //左
                validMoves.Add(new Vector3(nowXpos - 1, 0.5f, nowZpos));
                //左下
                validMoves.Add(new Vector3(nowXpos - 1, 0.5f, nowZpos - 1));
                //右下
                validMoves.Add(new Vector3(nowXpos + 1, 0.5f, nowZpos - 1));
            }
        }
        if (red)
        {
            if (SceneManager.GetActiveScene().name == "stage")
            {
                //右上
                validMoves.Add(new Vector3(nowXpos + 1, 0.5f, nowZpos + 1));
                //左上
                validMoves.Add(new Vector3(nowXpos - 1, 0.5f, nowZpos + 1));
                //左下
                validMoves.Add(new Vector3(nowXpos - 1, 0.5f, nowZpos - 1));
                //右下
                validMoves.Add(new Vector3(nowXpos + 1, 0.5f, nowZpos - 1));
            }
            else if (SceneManager.GetActiveScene().name == "Stage2")
            {
                //右上
                validMoves.Add(new Vector3(nowXpos + 1, 0.5f, nowZpos + 1));
                //右下
                validMoves.Add(new Vector3(nowXpos + 1, 0.5f, nowZpos - 1));
                //左
                validMoves.Add(new Vector3(nowXpos - 1, 0.5f, nowZpos));
            }
            else if (SceneManager.GetActiveScene().name == "Stage3")
            {
                //右上
                validMoves.Add(new Vector3(nowXpos + 1, 0.5f, nowZpos + 1));
                //左上
                validMoves.Add(new Vector3(nowXpos - 1, 0.5f, nowZpos + 1));
                //下
                validMoves.Add(new Vector3(nowXpos, 0.5f, nowZpos - 1));
                //右
                validMoves.Add(new Vector3(nowXpos + 1, 0.5f, nowZpos));
                //左
                validMoves.Add(new Vector3(nowXpos - 1, 0.5f, nowZpos));
            }
        }
        return validMoves;
    }

    //移動可能方向
    public void AddMove(int x,int z,List<Vector3Int>vailMoves)
    {
        vailMoves.Add(new Vector3Int(x, z));
    }

    //移動位置の取得
    public void MoveCharacter(Transform targetpos)
    {
        targetPosition.position = targetpos.position;
        transform.position = targetPosition.position;
        nowXpos = (int)transform.position.x;
        nowZpos = (int)transform.position.z;
        Debug.Log("x:" + nowXpos + "z:" + nowZpos);
    }

    // Update is called once per frame
    void Update()
    {
        //キャラクターの移動
        if (targetPosition != null)
        {
            Debug.Log("aiueo");
            transform.LookAt(targetPosition);
            animator.SetBool("run", true);
            transform.position = Vector3.MoveTowards(transform.position, targetPosition.position, movespeed * Time.deltaTime);
            OnWorp = true;
            if (transform.position == targetPosition.position)
            {
                transform.rotation = Quaternion.Euler(-30,180,0);
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
