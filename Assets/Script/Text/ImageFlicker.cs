using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageFlicker : MonoBehaviour
{
	//インスペクターから設定するか、初期化時にGetComponentして、Imageへの参照を取得しておく。
	[SerializeField]
	Image img;

	[Header("1ループの長さ(秒単位)")]
	[SerializeField]
	[Range(0.1f, 10.0f)]
	float duration = 0.5f;

	[Header("ループ開始時の色")]
	[SerializeField]
	Color32 startColor = new Color32(255, 255, 255, 255);
	[Header("ループ終了時の色")]
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
