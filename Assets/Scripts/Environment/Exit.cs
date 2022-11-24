using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{
    [SerializeField] private ExitText _template;
    [SerializeField] private Coin[] _coins;

    private const string LevelFinished = "Level complete!";
    private const string LevelNotFinished = "Collect all coins";

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

            bool allCoinsCollected = true;

            foreach (var coin in _coins)
            {
                if (coin != null)
                {
                    allCoinsCollected = false;
                    break;
                }
            }

            if (allCoinsCollected)
            {
                _text.GetComponent<TextMesh>().text = LevelFinished;
            }
            else
            {
                _text.GetComponent<TextMesh>().text = LevelNotFinished;
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
