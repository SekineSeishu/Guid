using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Clear : MonoBehaviour
{
    public static Clear Instance;
    public GameObject activeParticle;//ゴール到着時に出現するパーティクル
    [SerializeField] private AudioClip goalSE;//ゴール時SE
    private AudioSource audio;

    void Start()
    {
        audio = GetComponent<AudioSource>();
    }
    private void Awake()
    {
        Instance = this;
    }
    private void OnTriggerEnter(Collider other)
    {
        //キャラクターがゴールインしたらパーティクルを出現する
        Character character = other.gameObject.GetComponent<Character>();
        audio.PlayOneShot(goalSE);
        GameObject FX = Instantiate(activeParticle);
         FX.transform.position = gameObject.transform.position;
         character.goal = true;
         Debug.Log("RedGoal");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
