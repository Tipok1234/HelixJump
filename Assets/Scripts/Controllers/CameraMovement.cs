using UnityEngine;

namespace Assets.Scripts.Controllers
{
    public class CameraMovement : MonoBehaviour
    {
        [SerializeField] private Transform _target;

        private Vector3 _offset;

        private void Start()
        {
            _offset = transform.position - _target.position;
        }

        private void LateUpdate()
        {
            Vector3 newPos = Vector3.Lerp(transform.position, _target.position + _offset, 0.05f);
            transform.position = newPos;
        }
    }
}
