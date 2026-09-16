using UnityEngine;

public class PipeMovement : MonoBehaviour
{
    [SerializeField] private float _speed;

    void Update()
    {
        if (!GameManager.Instance.IsRunning) return;

        transform.position += Vector3.left * _speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("DespawnZone"))
        {
            PipePool.Instance.ReturnPipe(gameObject);
        }
    }
}