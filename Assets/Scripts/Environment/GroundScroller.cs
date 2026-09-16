using UnityEngine;

public class GroundScroller : MonoBehaviour
{
    [SerializeField] private Transform _groundA;
    [SerializeField] private Transform _groundB;
    [SerializeField] private float _speed;
    [SerializeField] private float _groundWidth;

    void Update()
    {
        if (!GameManager.Instance.IsGroundRunning) return;

        MoveGround(_groundA);
        MoveGround(_groundB);
    }

    private void MoveGround(Transform ground)
    {
        ground.position += Vector3.left * _speed * Time.deltaTime;

        if (ground.position.x <= -_groundWidth)
        {
            float otherX = (ground == _groundA ? _groundB : _groundA).position.x;
            ground.position = new Vector3(otherX + _groundWidth, ground.position.y, ground.position.z);
        }
    }
}