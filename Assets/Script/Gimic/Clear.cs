using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Clear : MonoBehaviour
{
    public static Clear Instance;
    public GameObject activeParticle;//�S�[���������ɏo������p�[�e�B�N��
    private AudioSource audio;
    //�S�[���擾
    public bool redClear;
    public bool blueClear;

    private void Awake()
    {
        Instance = this;
    }
    private void OnTriggerEnter(Collider other)
    {
        //���ꂼ��̃L�����N�^�[���S�[���C��������p�[�e�B�N�����o������
        Character c = other.gameObject.GetComponent<Character>();
        if (c.red && gameObject.tag == "RedGoal")
        {
            audio.Play();
            GameObject FX = Instantiate(activeParticle);
            FX.transform.position = gameObject.transform.position;
            c.redGoal = true;
            Debug.Log("red");
        }
        if (c.blue && gameObject.tag == "BlueGoal")
        {
            audio.Play();
            GameObject FX = Instantiate(activeParticle);
            FX.transform.position = gameObject.transform.position;
            c.blueGoal = true;
            Debug.Log("Blue");
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
        if (redClear && blueClear)
        {
            Debug.Log("Clear");
        }
    }
}
