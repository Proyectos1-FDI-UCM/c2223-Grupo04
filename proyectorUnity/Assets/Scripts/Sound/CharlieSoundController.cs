using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharlieSoundController : MonoBehaviour
{
    //Variables locales para sonidos de charlie
    int _sonidoPasos; 
    //Sonidos
    private AudioSource _charlie;
    [SerializeField] private AudioClip[] _charlieCamina;
    //Pitch
    [Range(-3, 3)]
    [SerializeField] float _minPitch;

    [Range(-3, 3)]
    [SerializeField] float _maxPitch;

    // Start is called before the first frame update
    void Start()
    {
        _charlie = this.gameObject.AddComponent<AudioSource>();
        _charlie.volume = 5;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CharlieCamina() 
    {
        AudioClip currentSound = _charlieCamina[Random.Range(0, _charlieCamina.Length)];
        StartCoroutine(PasosCharlie(currentSound));
        
    }
    public IEnumerator PasosCharlie(AudioClip currentCharlie) 
    {
        yield return new WaitForSeconds(0.17f);
        _charlie.PlayOneShot(currentCharlie);
    }
}
