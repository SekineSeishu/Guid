using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class result : MonoBehaviour
{
    [SerializeField] private GameManager GM;
    //�X�e�[�W���ƂɎ��т�����ă��U���g�ŕ\������
    [SerializeField] private GameObject OneStar;//���U���g�ŏo����1
    [SerializeField] private GameObject TwoStar;//���U���g�ŏo����2
    [SerializeField] private GameObject ThreeStar;//���U���g�ŏo����3
    [SerializeField] private AudioClip getStarSE;
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
        StartCoroutine(GetStar());
    }

    private IEnumerator GetStar()
    {
        yield return new WaitForSeconds(1);
        Debug.Log("clear");
        Debug.Log(GM.PlayCount);

        //�N���A���ɂ��ꂼ��̏�����B�����Ă��邩�̊m�F
        //�B�����Ă����ꍇ���̊l�����o�����s����
        if (GM.PlayCount > OneCount)//�c��ړ��񐔂��w��񐔈ȓ�
        {
            yield return new WaitForSeconds(1);
            Debug.Log("one");
            audio.PlayOneShot(getStarSE);
            OneStar.transform.DOScale(new Vector3(1, 1, 1), 1f).SetEase(Ease.OutBack);
        }
        if (GM.PlayCount > TwoCount)//�c��ړ��񐔂��w��񐔈ȓ�
        {
            yield return new WaitForSeconds(1);
            Debug.Log("two");
            audio.PlayOneShot(getStarSE);
            TwoStar.transform.DOScale(new Vector3(1, 1, 1), 1f).SetEase(Ease.OutBack);
        }
        Debug.Log("Three");
        //�X�e�[�W�N���A
        yield return new WaitForSeconds(1);
        audio.PlayOneShot(getStarSE);
        ThreeStar.transform.DOScale(new Vector3(1, 1, 1), 1f).SetEase(Ease.OutBack); 
    }
    void Update()
    {
       
    }
}
