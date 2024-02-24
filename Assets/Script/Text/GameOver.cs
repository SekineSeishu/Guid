using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class GameOver : MonoBehaviour
{
    private float OnTime;
    private AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        OnTime += Time.deltaTime;
        audio = GetComponent<AudioSource>();
        transform.localScale = new Vector3(0, 0, 0);
        transform.DOScale(new Vector3(1, 1, 1), 1f).SetEase(Ease.InBack);
        audio.Play();
        if (OnTime >= 1f)
        {
            transform.DOScale(new Vector3(1, 1, 1), 1f).SetEase(Ease.InBack);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
