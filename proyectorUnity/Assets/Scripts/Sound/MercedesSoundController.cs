using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MercedesSoundController : MonoBehaviour
{
    //Sonidos
    private AudioSource _merche;
    [SerializeField] private AudioClip _mercheCome, _mercheEntierra, mercheSale;
    //Pitch
    [Range(-3, 3)]
    [SerializeField] float _minPitch;

    [Range(-3, 3)]
    [SerializeField] float _maxPitch;

    // Start is called before the first frame update
    void Start()
    {
        _merche = this.gameObject.AddComponent<AudioSource>();
        _merche.volume = 5;
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
    public void MercedesEntierra() 
    {
        _merche.pitch = Random.Range(_minPitch, _maxPitch);
        _merche.PlayOneShot(_mercheEntierra);
    }
    public void MercedesSale() 
    {
        _merche.pitch = Random.Range(_minPitch, _maxPitch);
        _merche.PlayOneShot(mercheSale);
    }
}
