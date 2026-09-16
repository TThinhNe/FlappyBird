using System.Collections.Generic;
using UnityEngine;

public class PipePool : MonoBehaviour
{
    public static PipePool Instance;

    [SerializeField] private GameObject _pipePrefab;
    [SerializeField] private int _poolSize;

    private Queue<GameObject> _pool = new Queue<GameObject>();

    void Awake()
    {
        Instance = this;
        CreatePool();
    }

    private void CreatePool()
    {
        for (int i = 0; i < _poolSize; i++)
        {
            GameObject pipe = Instantiate(_pipePrefab, transform);
            pipe.SetActive(false);
            _pool.Enqueue(pipe);
        }
    }

    public GameObject GetPipe()
    {
        if (_pool.Count == 0)
        {
            GameObject extra = Instantiate(_pipePrefab, transform);
            extra.SetActive(false);
            _pool.Enqueue(extra);
        }

        GameObject pipe = _pool.Dequeue();
        pipe.SetActive(true);
        return pipe;
    }

    public void ReturnPipe(GameObject pipe)
    {
        pipe.SetActive(false);
        _pool.Enqueue(pipe);
    }
}