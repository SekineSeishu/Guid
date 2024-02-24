using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ClearORGameOver : MonoBehaviour
{
    private AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        transform.localScale = new Vector3(0, 0, 0);
        transform.DOScale(new Vector3(1, 1, 1), 1f).SetEase(Ease.InBack);
        audio.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
