using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private DogNavy _template;

    private SpawnPoint[] _points;
    private Coroutine _corutine;

    private void Awake()
    {
        _points = gameObject.GetComponentsInChildren<SpawnPoint>();
        _corutine = StartCoroutine(StartSpawn());
    }

    private IEnumerator StartSpawn()
    {
        var secondsToWait = new WaitForSeconds(2);

        while (true)
        {
            int i = Random.Range(0, _points.Length);
            var dog = Instantiate(_template, _points[i].transform);
            yield return secondsToWait;
        }
    }
}
