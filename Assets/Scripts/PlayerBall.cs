using System;
using UnityEngine;

public class PlayerBall : MonoBehaviour
{
    public event Action LevelFailedAction;
    public event Action LevelCompletedAction;
    public event Action FloorPassedAction;

    [SerializeField] private Rigidbody _playerBallRB;
    [SerializeField] private float _jumpForce;
    [SerializeField] private Material _myMaterial;

    private Vector3 posBall = new Vector3(0, 1.6f, -1.95f);

    private void OnCollisionEnter(Collision collision)
    {
        _playerBallRB.velocity = new Vector3(_playerBallRB.velocity.x, _jumpForce, _playerBallRB.velocity.z);
        string materialName = collision.transform.GetComponent<MeshRenderer>().material.name;

        if(materialName == "SaveMat (Instance)")
        {
            SoundManager.Instance.JumpSound();
        }
        else if (materialName == "UnSaveMat (Instance)")
        {
            LevelFailedAction?.Invoke();
            SoundManager.Instance.DeathSound();
        }
        else if(materialName == "FinishMaterial (Instance)")
        {
            LevelCompletedAction?.Invoke();
            SoundManager.Instance.FinishSound();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "FloorTrigger")
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
        switch(colorType)
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
        }
    }
}
