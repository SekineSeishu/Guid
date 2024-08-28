using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class BloomAnimation : MonoBehaviour
{
    //�L�����N�^�[����I�������ۂɌ��x���グ�ē_�ł���
    [SerializeField]
    private Volume postFXvolume;

    private Bloom bloom;//�u���[��
    private float intensity;//�u���[���̌��x
    private float time;//���x�̎���
    public float OneCount;//1�b���Ƃ̃J�E���g
    public float downCount;//���x�̍Œ�l
    public float upCount;//���x�̍ō��l

    void Start()
    {
        //���x�⎞�Ԃ�������
        postFXvolume.profile.TryGet(out bloom);
        intensity = OneCount;
        time = 0f;
        if (bloom == null)
        {
            Debug.Log("No,Bloom");
        }
    }

    void Update()
    {
        //�u���[���̓_�ŃA�j���[�V����
        bloom.intensity.value = intensity;
        intensity += time * Time.deltaTime;
        //���x���Œ�l�������������x���v���X�ɂ���
        if (intensity <= downCount)
        {
            time = OneCount;
        }
        //���x���ō��l������������x���}�C�i�X�ɂ���
        if (intensity >= upCount)
        {
            time = -OneCount;
        }
    }

    //�u���[���̋������グ��
    public void ChangeBloomIntesity()
    {
        bloom.intensity.value = 100;
    }
}
