using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject pipePrefab;
    public float range;
    public int minDistanceBetweenPipes;
    public int maxDistanceBetweenPipes;

    private float _lastSpawnPos = 0;
    private Bird _bird;

    private void Awake()
    {
        _bird = FindObjectOfType<Bird>();
    }

    private void Update()
    {
        if (_bird.transform.position.x > _lastSpawnPos - range / 2)
        {
            StartCoroutine(SpawnNextSet(_lastSpawnPos + range));
        }
    }


    private IEnumerator SpawnNextSet(float distance)
    {
        while (_lastSpawnPos < distance)
        {
            var y = Random.Range(-2.5f, 2.5f);
            var pos = new Vector3(_lastSpawnPos + Random.Range(minDistanceBetweenPipes, maxDistanceBetweenPipes), y, 0);
            Instantiate(pipePrefab, pos, Quaternion.identity);
            _lastSpawnPos = pos.x;

            yield return null;
        }
    }
}