using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> _gameObject;
    private PlayerController _playerController;
    private float _initialTime = 2f;
    private float _repeateGap;

    private void Awake()
    {
        _repeateGap = Random.Range(3f,5f);
    }

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Obstacles", _initialTime, _repeateGap);
        _playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    void Obstacles()
    {
        if (_playerController.gameOver == false)
        {
            Instantiate(_gameObject[Random.Range(0, _gameObject.Count)], transform.position, Quaternion.identity);
        }
    }
}
