using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightManager : MonoBehaviour
{ 
    public static HighlightManager Instance;
    private string characterName;
    public GameObject selectHighlight;
    public GameObject higlightPrefab;
    private List<GameObject> highlights = new List<GameObject>();
    public Transform highlightParet;
    //private ParticleSystem p;

    public void Awake()
    {
        Instance = this;
    }

    public void HighlightValidMoves(Character selectCharacter)
    {
        //�I�������L�����N�^�[�̌��݈ʒu����ړ��ł���ꏊ�Ƀn�C���C�g�𐶐�����
        //���łɂ���n�C���C�g���폜����
        ClearHighlights();
        if (selectCharacter.redGoal || selectCharacter.blueGoal)
        {
            Debug.Log("null");
        }
        else
        {
            if (selectCharacter.red)
            {
                characterName = "red";
            }

            if (selectCharacter.blue)
            {
                characterName = "red";
            }

            List<Vector3> validMoves = selectCharacter.moveDirection.GetValidMove(characterName, selectCharacter.nowXpos,selectCharacter.nowZpos);

            foreach (Vector3 move in validMoves)
            {
                GameObject higlightObject = Instantiate(higlightPrefab, highlightParet);
                higlightObject.transform.position = move;
                highlights.Add(higlightObject);

                //�X�e�[�W�u���b�N���Ȃ����L�����N�^�[�������ꍇ�n�C���C�g���폜����
                if (!IsStageBlockPresentAt(move.x, move.z) || !IsCharacterPresentAt(move.x, move.z))
                {
                    Destroy(higlightObject);
                }

            }
        }
    }

    private bool IsStageBlockPresentAt(float x, float z)
    {
        Collider[] colliders = Physics.OverlapSphere(new Vector3(x, 0.5f, z), 0.3f);

    foreach (Collider collider in colliders)
    {
        if (collider.CompareTag("StageBlock"))
        {
                Debug.Log("�n�ʃu���b�N����܂�");
            return true; // StageBlock�����݂���
        }
    }

    return false; // StageBlock�����݂��Ȃ�
    }

    private bool IsCharacterPresentAt(float x, float z)
    {
        Collider[] colliders = Physics.OverlapSphere(new Vector3(x, 0.5f, z), 0.3f);

        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag("Character"))
            {
                Debug.Log("�L�����N�^�[�͂��܂���");
                return false;//�L�����N�^�[�����݂��Ȃ�
            }
        }
        return true;//�L�����N�^�[�����݂���
    }

    public void CharaMove(Character selectCharacter,Transform targetpos)
    {
            selectCharacter.targetPosition = targetpos;
            selectHighlight = targetpos.gameObject;
            ClearHighlights();
    }

    public void ClearHighlights()
    {
        foreach(GameObject highlight in highlights)
        {
            if (highlight != selectHighlight)
            {
                Destroy(highlight);
            }
        }
        highlights.Clear();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
