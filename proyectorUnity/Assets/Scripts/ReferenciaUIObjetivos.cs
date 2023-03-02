using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ReferenciaUIObjetivos : MonoBehaviour
{
    [SerializeField] Image _imagen;
    [SerializeField] TextMeshProUGUI _textoVariable;
    [SerializeField] TextMeshProUGUI _textoInvariable;

    public Image DevolverImagen()
    {
        return _imagen;
    }
    public TextMeshProUGUI DevolverTxtVariable()
    {
        return _textoVariable;
    }
    public TextMeshProUGUI DevolverTxtInvariable()
    {
        return _textoInvariable;
    }
}
