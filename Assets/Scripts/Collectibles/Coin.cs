using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private CoinPickUpSound _template;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Theif>(out Theif theif))
        {
            Instantiate(_template);
            Destroy(gameObject);
        }
    }
}
