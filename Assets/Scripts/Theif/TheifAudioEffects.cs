using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Theif))]
[RequireComponent(typeof(TheifMovement))]

public class TheifAudioEffects : MonoBehaviour
{
    [SerializeField] private AudioSource _audio;

    private Theif _theif;
    private TheifMovement _theifMovement;

    private void OnEnable()
    {
        _theifMovement.Moved += OnMovedHorizontal;
        _theifMovement.Stayed += OnStayed;
        _theif.Died += OnDied;
    }

    private void OnDisable()
    {
        _theifMovement.Moved -= OnMovedHorizontal;
        _theifMovement.Stayed -= OnStayed;
        _theif.Died -= OnDied;
    }

    private void Awake()
    {
        _theif = GetComponent<Theif>();
        _theifMovement = GetComponent<TheifMovement>();
    }

    private void OnMovedHorizontal()
    {
        if (_audio.isPlaying == false)
            _audio.Play();
    }

    private void OnStayed()
    {
        _audio.Stop();
    }

    private void OnDied()
    {
        _audio.Stop();
    }
}
