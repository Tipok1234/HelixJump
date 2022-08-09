using System;
using UnityEngine;

public class PlayerBall : MonoBehaviour
{
    public event Action LevelFailedAction;
    public event Action LevelCompletedAction;
    public event Action FloorPassedAction;

    [SerializeField] private Rigidbody _playerBallRB;
    [SerializeField] private float _jumpForce;

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
}
