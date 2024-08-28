using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class BloomAnimation : MonoBehaviour
{
    //キャラクター等を選択した際に光度を上げて点滅する
    [SerializeField]
    private Volume postFXvolume;

    private Bloom bloom;//ブルーム
    private float intensity;//ブルームの光度
    private float time;//光度の周期
    public float OneCount;//1秒ごとのカウント
    public float downCount;//光度の最低値
    public float upCount;//光度の最高値

    void Start()
    {
        //光度や時間を初期化
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
        //ブルームの点滅アニメーション
        bloom.intensity.value = intensity;
        intensity += time * Time.deltaTime;
        //光度が最低値を下回ったら光度をプラスにする
        if (intensity <= downCount)
        {
            time = OneCount;
        }
        //光度が最高値を上回ったら光度をマイナスにする
        if (intensity >= upCount)
        {
            time = -OneCount;
        }
    }

    //ブルームの強さを上げる
    public void ChangeBloomIntesity()
    {
        bloom.intensity.value = 100;
    }
}
