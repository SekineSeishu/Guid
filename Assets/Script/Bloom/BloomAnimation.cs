using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class BloomAnimation : MonoBehaviour
{
    [SerializeField]
    private Volume postFXvolume;

    private Bloom bloom;
    private float intensity;
    private float time;
    public float OneCount;
    public float downCount;
    public float upCount;

    void Start()
    {
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
        bloom.intensity.value = intensity;
        intensity += time * Time.deltaTime;
        if (intensity <= downCount)
        {
            time = OneCount;
        }
        if (intensity >= upCount)
        {
            time = -OneCount;
        }
    }

    public void ChangeBloomIntesity()
    {
        bloom.intensity.value = 100;
    }
}
