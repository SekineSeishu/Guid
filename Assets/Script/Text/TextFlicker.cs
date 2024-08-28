using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextFlicker : MonoBehaviour
{
    TextMeshProUGUI text;//�_�ł�����e�L�X�g
    public float a;
    public float b = 1.0f;
    [SerializeField]
    Color32 startColor = new Color32(255, 50, 68,0);//�ŏ��̐F
    [SerializeField]
    Color32 endColor = new Color32(151,0,18,0);//�Ō�̐F
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        text.alpha = a;//�ϐ�a��alpha�l��ύX
        a += b * Time.deltaTime;
        if (a >= 1f)
        {
            b = -1.0f;
        }
        if (a <= 0.2f)
        {
            b = 1.0f;
        }
    }
}
