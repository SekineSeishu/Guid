using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextFlicker : MonoBehaviour
{
    TextMeshProUGUI tmp;
    public float a;
    public float b = 1.0f;
    [SerializeField]
    Color32 startColor = new Color32(255, 50, 68,0);
    [SerializeField]
    Color32 endColor = new Color32(151,0,18,0);
    // Start is called before the first frame update
    void Start()
    {
        tmp = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        tmp.alpha = a;//•Ï”a‚Ìalpha’l‚ð•ÏX
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
