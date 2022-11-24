using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class DogNavy : MonoBehaviour
{
    private int _damage = 1;
    private AudioSource _audio;

    private void Start()
    {
        _audio = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Theif>(out Theif theif))
        {
            if (theif.IsDead == false)
            {
                theif.TakeDamage(_damage);
                _audio.Play();
            }
        }
    }
}
