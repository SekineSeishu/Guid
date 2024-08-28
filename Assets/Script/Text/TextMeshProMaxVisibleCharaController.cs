using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[ExecuteInEditMode]
[RequireComponent(typeof(TextMeshPro))]
public class TextMeshProMaxVisibleCharaController : MonoBehaviour
{
    public int maxVisibleCharacters;
    private TextMeshPro text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (this.text == null)
            this.text = GetComponent<TextMeshPro>();

        this.text.maxVisibleCharacters = this.maxVisibleCharacters;
    }
}
