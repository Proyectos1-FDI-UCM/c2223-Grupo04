using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MercedesSoundController : MonoBehaviour
{
    //Sonidos
    private AudioSource _merche;
    [SerializeField] private AudioClip _mercheCome, _mercheMueve, mercheTierra;
    //Pitch
    [Range(-3, 3)]
    [SerializeField] float _minPitch;

    [Range(-3, 3)]
    [SerializeField] float _maxPitch;

    // Start is called before the first frame update
    void Start()
    {
        _merche = this.gameObject.AddComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void MercedesMastica() 
    {
        _merche.pitch = Random.Range(_minPitch, _maxPitch);
        _merche.PlayOneShot(_mercheCome);
    }
    public void MercedesDesliza() 
    {
        _merche.pitch = Random.Range(_minPitch, _maxPitch);
        _merche.PlayOneShot(_mercheMueve);
    }
    public void MercedesTierra() 
    {
        _merche.pitch = Random.Range(_minPitch, _maxPitch);
        _merche.PlayOneShot(mercheTierra);
    }
}
