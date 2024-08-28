using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class result : MonoBehaviour
{
    public GameManager GM;
    //�X�e�[�W���ƂɎ��т�����ă��U���g�ŕ\������
    public GameObject OneStar;//���U���g�ŏo����1
    public GameObject TwoStar;//���U���g�ŏo����2
    public GameObject ThreeStar;//���U���g�ŏo����3
    public int OneCount;//�ړ��񐔈ȓ��P
    public int TwoCount;//�ړ��񐔈ȓ��Q
    private AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        //���̃T�C�Y��0�ɂ��Č����Ȃ�����
        OneStar.transform.localScale = new Vector3(0, 0, 0);
        TwoStar.transform.localScale = new Vector3(0, 0, 0);
        ThreeStar.transform.localScale = new Vector3(0, 0, 0);

        //DoTween���g���ă��[�V������t���Ȃ��烊�U���g��\������
        this.transform.DOScale(new Vector3(1, 1, 1), 1f).SetEase(Ease.OutBack);
        //���U���g���\�����ꂽ����т̊m�F������
        if (gameObject.transform.localScale == new Vector3(1,1,1))
        {
            Debug.Log("clear");
            Debug.Log(GM.PlayCount);
            //�N���A���ɂ��ꂼ��̏�����B�����Ă��邩�̊m�F
            if (GM.PlayCount > OneCount)//�c��ړ��񐔂��w��񐔈ȓ�
            {
                Invoke("oneStar", 1);
            }
            if (GM.PlayCount > TwoCount)//�c��ړ��񐔂��w��񐔈ȓ�
            {
                Invoke("twoStar", 2);
            }
            Invoke("threeStar", 3);//�X�e�[�W�N���A
        }
    }

    void Update()
    {

    }

    //�B�����Ă����ꍇ���̊l�����o�����s����
    private void oneStar()
    {
        OneStar.SetActive(true);
        OneStar.transform.DOScale(new Vector3(1, 1, 1), 1f).SetEase(Ease.OutBack);
    }
    private void twoStar()
    {
        TwoStar.SetActive(true);
        TwoStar.transform.DOScale(new Vector3(1, 1, 1), 1f).SetEase(Ease.OutBack);
    }
    private void threeStar()
    {
        ThreeStar.SetActive(true);
        ThreeStar.transform.DOScale(new Vector3(1, 1, 1), 1f).SetEase(Ease.OutBack);
    }
}
