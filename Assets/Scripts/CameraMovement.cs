
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform _target;

    private Vector3 _offset;

    void Start()
    {
        _offset = transform.position - _target.position;   
    }

    void LateUpdate()
    {
        Vector3 newPos = Vector3.Lerp(transform.position, _target.position + _offset, 0.04f);
        transform.position = newPos;
    }
}
