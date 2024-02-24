using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageFlicker : MonoBehaviour
{
	//�C���X�y�N�^�[����ݒ肷�邩�A����������GetComponent���āAImage�ւ̎Q�Ƃ��擾���Ă����B
	[SerializeField]
	Image img;

	[Header("1���[�v�̒���(�b�P��)")]
	[SerializeField]
	[Range(0.1f, 10.0f)]
	float duration = 0.5f;

	[Header("���[�v�J�n���̐F")]
	[SerializeField]
	Color32 startColor = new Color32(255, 255, 255, 255);
	[Header("���[�v�I�����̐F")]
	[SerializeField]
	Color32 endColor = new Color32(255, 255, 255, 64);
    // Start is called before the first frame update
    void Start()
    {
		

	}

    // Update is called once per frame
    void Update()
    {
		img.color = Color.Lerp(startColor, endColor, Mathf.PingPong(Time.time / duration, 1.0f));
	}
}
