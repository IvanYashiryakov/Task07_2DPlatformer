using UnityEngine;

public class CoinPickUpSound : MonoBehaviour
{
    private float _lifeTime = 1f;

    private void Start()
    {
        Destroy(gameObject, _lifeTime);
    }
}
