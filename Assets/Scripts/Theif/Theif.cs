using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Theif : MonoBehaviour
{
    [SerializeField] private UnityEvent _died = new UnityEvent();
    private UnityEvent _hurted = new UnityEvent();

    private int _health = 2;

    public bool IsDead => _health <= 0;

    public event UnityAction Hurted
    {
        add => _hurted.AddListener(value);
        remove => _hurted.RemoveListener(value);
    }

    public event UnityAction Died
    {
        add => _died.AddListener(value);
        remove => _died.RemoveListener(value);
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;
        _hurted.Invoke();

        if (IsDead)
        {
            _died.Invoke();
        }
    }
}
