using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helix : MonoBehaviour
{
    private Transform _player;
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if(transform.position.y > _player.position.y)
        {
            GameManager._numberOfPassedHelixs++;
            Destroy(gameObject);
        }
    }
}
