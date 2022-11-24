using System;
using UnityEngine;
using Assets.Scripts.Enums;
using Assets.Scripts.Managers;

namespace Assets.Scripts.Models
{
    public class PlayerBall : MonoBehaviour
    {
        public event Action LevelFailedAction;
        public event Action LevelCompletedAction;
        public event Action FloorPassedAction;

        [SerializeField] private Rigidbody _playerBallRB;
        [SerializeField] private float _jumpForce;
        [SerializeField] private Material _myMaterial;
        [SerializeField] private GameObject _splash;

        private Vector3 posBall = new Vector3(0, 1.6f, -1.95f);

        private void OnMouseDown()
        {
            float mouseX = Input.GetAxisRaw("Mouse X");
            transform.Rotate(0, -mouseX * 400 * Time.deltaTime, 0);
        }
        private void OnCollisionEnter(Collision collision)
        {
            _playerBallRB.velocity = new Vector3(_playerBallRB.velocity.x, _jumpForce, _playerBallRB.velocity.z);
            string materialName = collision.transform.GetComponent<MeshRenderer>().material.name;

            if (materialName == "SaveMat (Instance)")
            {
                SoundManager.Instance.JumpSound();
                AddSplash();
            }
            else if (materialName == "UnSaveMat (Instance)")
            {
                LevelFailedAction?.Invoke();
                SoundManager.Instance.DeathSound();
                AddSplash();
            }
            else if (collision.transform.tag == "FloorDestroyTrigger")
            {
                Destroy(collision.gameObject);
                SoundManager.Instance.JumpSound();
                AddSplash();
            }
            else if (materialName == "FinishMaterial (Instance)")
            {
                LevelCompletedAction?.Invoke();
                SoundManager.Instance.FinishSound();
                AddSplash();
            }
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "FloorTrigger")
            {
                FloorPassedAction?.Invoke();
            }
        }

        public void ResetPosition()
        {
            transform.position = posBall;
        }

        public void SetColorType(ColorType colorType)
        {
            switch (colorType)
            {
                case ColorType.Standart_Color:
                    _myMaterial.color = Color.yellow;
                    break;

                case ColorType.Green_Color:
                    _myMaterial.color = Color.green;
                    break;

                case ColorType.Blue_Color:
                    _myMaterial.color = Color.blue;
                    break;

                case ColorType.Black_Color:
                    _myMaterial.color = Color.black;
                    break;

                case ColorType.Red_Color:
                    _myMaterial.color = Color.red;
                    break;

                case ColorType.Purple_Color:
                    _myMaterial.color = Color.magenta;
                    break;

                case ColorType.Orange_Color:
                    _myMaterial.color = new Color(255f,101f,0f,255f);
                    break;

                case ColorType.Grey_Color:
                    _myMaterial.color = Color.grey;
                    break;

                case ColorType.Clear_Color:
                    _myMaterial.color = Color.white;
                    break;
            }
        }
        public void AddSplash()
        {
            _splash.SetActive(true);
            GameObject splash = Instantiate(_splash);
            splash.transform.position = _playerBallRB.transform.position;
            _splash.SetActive(false);
            Destroy(splash, 0.3f);
        }
    }
}
