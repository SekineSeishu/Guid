using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Character : MonoBehaviour
{
    public static Character Instance;
    public MoveDirections moveDirection;
    public Transform targetPosition;
    public Transform defaultRotation;
    private float movespeed = 0.7f;
    private Animator animator;
    public bool redGoal;
    public bool blueGoal;
    public bool red;
    public bool blue;
    public float nowXpos;
    public float nowZpos;
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
        nowXpos = transform.position.x;
        nowZpos = transform.position.z;
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
