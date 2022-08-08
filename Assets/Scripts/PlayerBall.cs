using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBall : MonoBehaviour
{
    public event Action LevelFailedAction;
    public event Action LevelCompletedAction;

    [SerializeField] private Rigidbody _playerBallRB;
    [SerializeField] private float _jumpForce;

    private void OnCollisionEnter(Collision collision)
    {
        _playerBallRB.velocity = new Vector3(_playerBallRB.velocity.x, _jumpForce, _playerBallRB.velocity.z);
        string materialName = collision.transform.GetComponent<MeshRenderer>().material.name;

        if(materialName == "SaveMat (Instance)")
        {

        }
        else if (materialName == "UnSaveMat (Instance)")
        {
            LevelFailedAction?.Invoke();
        }
        else if(materialName == "FinishMaterial (Instance)")
        {
            LevelCompletedAction?.Invoke();
        }
    }
}
