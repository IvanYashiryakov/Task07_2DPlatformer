using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Theif))]
[RequireComponent(typeof(TheifMovement))]

public class TheifAnimation : MonoBehaviour
{
    private const string RunTrigger = "Run";
    private const string HurtTrigger = "Hurt";
    private const string DeadTrigger = "Dead";

    private Theif _theif;
    private TheifMovement _theifMovement;
    private Animator _animator;

    private void OnEnable()
    {
        _theifMovement.Moved += OnMoved;
        _theifMovement.Stayed += OnStayed;
        _theif.Hurted += OnHurted;
        _theif.Died += OnDied;
    }

    private void OnDisable()
    {
        _theifMovement.Moved -= OnMoved;
        _theifMovement.Stayed -= OnStayed;
        _theif.Hurted -= OnHurted;
        _theif.Died -= OnDied;
    }

    private void Awake()
    {
        _theif = GetComponent<Theif>();
        _theifMovement = GetComponent<TheifMovement>();
        _animator = GetComponent<Animator>();
    }

    private void OnMoved()
    {
        _animator.SetTrigger(RunTrigger);
    }

    private void OnStayed()
    {
        _animator.ResetTrigger(RunTrigger);
    }

    private void OnHurted()
    {
        _animator.SetTrigger(HurtTrigger);
    }

    private void OnDied()
    {
        _animator.SetTrigger(DeadTrigger);
    }
}
