using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSounds : MonoBehaviour
{
    //Sonidos
    private AudioSource _menu;
    [SerializeField] private AudioClip _menuButton;

    // Start is called before the first frame update
    void Start()
    {
        _menu = this.gameObject.AddComponent<AudioSource>();
        _menu.volume = 5;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ButtonSound()
    {
        _menu.PlayOneShot(_menuButton);
    }
}

