using UnityEngine;

public class CoinPickUpSound : MonoBehaviour
{
    private float _destroyTime = 1f;
    private float _lifeTime = 0f;

    private void FixedUpdate()
    {
        _lifeTime += Time.fixedDeltaTime;

        if (_lifeTime > _destroyTime)
            Destroy(gameObject);
    }
}
