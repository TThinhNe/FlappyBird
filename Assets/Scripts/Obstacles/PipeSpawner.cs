using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField] private float _spawnInterval;
    [SerializeField] private float _minSpawnY;
    [SerializeField] private float _maxSpawnY;

    private float _timer;
    private bool _isSpawning = true;

    void Update()
    {
        if (!GameManager.Instance.IsRunning) return;
        if (!_isSpawning) return;

        _timer += Time.deltaTime;

        if (_timer >= _spawnInterval)
        {
            _timer = 0f;
            SpawnPipe();
        }
    }

    private void SpawnPipe()
    {
        float randomY = Random.Range(_minSpawnY, _maxSpawnY);
        Vector3 spawnPosition = new Vector3(transform.position.x, randomY, 0f);

        GameObject pipe = PipePool.Instance.GetPipe();
        pipe.transform.position = spawnPosition;
        pipe.transform.rotation = Quaternion.identity;

        pipe.GetComponentInChildren<ScoreZone>().ResetScoreState();
    }
    
}