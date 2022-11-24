using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.Controllers
{
    public class RotationObstacle : MonoBehaviour
    {
        private Touch _touch;
        private Vector2 _touchPos;
        private Quaternion _rotationY;

        private float _rotationObstacle = 0.15f;

        private void FixedUpdate()
        {
            if(Input.touchCount> 0)
            {
                _touch = Input.GetTouch(0);

                if(_touch.phase == TouchPhase.Moved)
                {
                    _rotationY = Quaternion.Euler(0f, -_touch.deltaPosition.x * _rotationObstacle, 0f);

                    transform.rotation = _rotationY * transform.rotation;
                }
            }

            //if (Input.GetMouseButton(0))
            //{
            //    float mouseX = Input.GetAxisRaw("Mouse X");
            //    transform.Rotate(0, -mouseX * _rotationObstacle * Time.deltaTime, 0);
            //}
        }

        //private void Update()
        //{
        //    if (Input.GetMouseButton(0))
        //    {
        //        float mouseX = Input.GetAxisRaw("Mouse X");
        //        transform.Rotate(0, -mouseX * _rotationObstacle * Time.deltaTime, 0);
        //    }
        //}
    }
}
