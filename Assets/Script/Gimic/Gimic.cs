using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gimic : MonoBehaviour
{
    public static Gimic Instance; 
    public GameObject activeGimic;
    public GameObject worp;
    private GameObject chara;
    private AudioSource audio;
    public bool OnWorp;
    private Character character;

    public void Awake()
    {
        Instance = this;
    }

    private void OnTriggerEnter(Collider other)
    {
        Character c = other.gameObject.GetComponent<Character>();
        if (c.red && gameObject.tag == "RedGoal")
        {
                audio.Play();
                activeGimic.SetActive(true);
            if (SceneManager.GetActiveScene().name == "stage")
            {
                BloomManager.Instance.tutorialText4.SetActive(false);
            }
        }
        if (c.blue && gameObject.tag == "BlueGoal")
        {
            audio.Play();
            activeGimic.SetActive(true);
        }
        if (gameObject.tag == "worp")
        {
            if (other.gameObject.tag == "Character")
            {
                if (SceneManager.GetActiveScene().name == "Stage2" || SceneManager.GetActiveScene().name == "Stage3")
                {
                    if (c.OnWorp && GetWorp(worp.transform))
                    {
                        chara = other.gameObject;
                        character = other.GetComponent<Character>();
                        Invoke("Worp", 1);
                    }
                }
            }
        }
    }

    public void Worp()
    {
        if (worp.activeInHierarchy)
        {
            audio.Play();
            chara.transform.position = worp.transform.position;
            character.nowXpos = (int)chara.gameObject.transform.position.x;
            character.nowZpos = (int)chara.gameObject.transform.position.z;
            character.OnWorp = false;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private bool GetWorp(Transform worpPosition)
    {
        Collider[] colliders = Physics.OverlapSphere(new Vector3(worpPosition.position.x, worpPosition.position.y, worpPosition.position.z), 0.3f);

        //ワープ先にキャラクターがいた場合ワープしない
        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag("Character"))
            {
                return false;
            }
        }
        return true;
    }
}
