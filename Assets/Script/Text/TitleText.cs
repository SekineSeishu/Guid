using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[ExecuteAlways] [RequireComponent(typeof(TextMeshProUGUI))]

public class TitleText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _tmPro;
    private TextMeshProUGUI tmPro => _tmPro ? _tmPro : _tmPro = GetComponent<TextMeshProUGUI>();

    private Material material
    {
        get
        {
            if (Application.isPlaying)
            {
                //fontMaterialにアクセスすると複製されたmaterial instanceを操作する事になる
                return tmPro.fontMaterial;
            }
            return tmPro.font.material;
        }
    }

    [SerializeField, ColorUsage(true, true)]
    private Color _faceColorHDR = Color.white;

    private Color FaceColorHDR
    {
        get { return material.GetColor(ShaderUtilities.ID_FaceColor);}

        set
        {
            if (_faceColorHDR.Compare(value)) return;
            _faceColorHDR = value;
            UpdateMaterial();
        }
    }

    private void UpdateMaterial()
    {
        material.SetColor(ShaderUtilities.ID_FaceColor, _faceColorHDR);
        tmPro.havePropertiesChanged = true; //fallback fontに反映される場合に必要
    }

    private void OnDidApplyAnimationProperties()
    {
        UpdateMaterial();
    }

#if UNITY_EDITOR
    private void OnValidate()
    {
        UpdateMaterial();
    }
#endif
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
