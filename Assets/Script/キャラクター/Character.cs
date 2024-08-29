using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum characterType
{
    Red,
    Blue
}

public class Character : MonoBehaviour
{
    public characterType type;
    public static Character Instance;
    public MoveDirections moveDirection;//�L�����N�^�[�̈ړ������f�[�^
    public Transform targetPosition;//�ړ���
    public Transform defaultRotation;//��{�̌���
    private float movespeed = 0.7f;//�ړ��X�s�[�h
    private Animator animator;
    public bool goal;//�ԗH��̃S�[���t���O
    public int nowXpos;//���݂�x�l
    public int nowZpos;//���݂�y�l
    public bool OnWorp;//���[�v�t���O

    public void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        //�������@�S�[���t���O��OFF
        OnWorp = false;//�ړ����ȊO���[�v�t���O��OFF
        goal = false;
        animator = GetComponent<Animator>();
        //����̏����ʒu��n��
        nowXpos = (int)transform.position.x;
        nowZpos = (int)transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        //�L�����N�^�[�̈ړ�
        if (targetPosition != null)
        {
            Debug.Log("�ړ����I");
            transform.LookAt(targetPosition);
            animator.SetBool("run", true);
            transform.position = Vector3.MoveTowards(transform.position, targetPosition.position, movespeed * Time.deltaTime);
            OnWorp = true;//�ړ����̓��[�v�t���O���I���ɂ���
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
