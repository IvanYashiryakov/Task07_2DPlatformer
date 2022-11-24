using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{
    [SerializeField] private ExitText _template;

    private const string _levelFinished = "Level complete!";
    private const string _levelNotFinished = "Collect all coins";

    private ExitText _text;
    private Vector3 _textPosition = new Vector3(0, 1.9f, 0);
    private float _destroyDelay = 2f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Theif>(out Theif theif))
        {
            if (_text != null)
                Destroy(_text.gameObject);

            _text = Instantiate(_template, transform);
            _text.transform.localPosition = _textPosition;

            Coin[] coins = FindObjectsOfType<Coin>();

            if (coins.Length > 0)
            {
                _text.GetComponent<TextMesh>().text = _levelNotFinished;
            }
            else
            {
                _text.GetComponent<TextMesh>().text = _levelFinished;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Theif>(out Theif theif))
        {
            Destroy(_text.gameObject, _destroyDelay);
        }
    }
}
