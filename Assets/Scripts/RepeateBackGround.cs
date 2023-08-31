using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeateBackGround : MonoBehaviour
{
    private Vector3 _startingPosition;
    private float _speed = 10;
    private float _repeatPosition;
    private PlayerController _playerController;
    // Start is called before the first frame update
    void Start()
    {
        _startingPosition = transform.position;
        _repeatPosition = GetComponent<BoxCollider>().size.x/2;
        _playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (_playerController.gameOver == false)
        {
            if (_playerController._isDoubleSpeedable)
            {
                transform.Translate(Vector3.left * Time.deltaTime * (_speed * 2));
            }
            else
            {
                transform.Translate(Vector3.left * Time.deltaTime * _speed);
            }

            
            if (transform.position.x <= _startingPosition.x - _repeatPosition)
            {
                transform.position = _startingPosition;
            }
        }
    }

}
