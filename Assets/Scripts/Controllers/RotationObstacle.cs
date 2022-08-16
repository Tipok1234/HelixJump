using UnityEngine;

namespace Assets.Scripts.Controllers
{
    public class RotationObstacle : MonoBehaviour
    {
        [SerializeField] private float _rotationObstacle;
        private void Update()
        {
            if (Input.GetMouseButton(0))
            {
                float mouseX = Input.GetAxisRaw("Mouse X");
                transform.Rotate(0, -mouseX * _rotationObstacle * Time.deltaTime, 0);
            }
        }
    }
}
