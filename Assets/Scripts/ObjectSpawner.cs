using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[AddComponentMenu("ARCourse/Object Spawner")]
public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _gameObjectToSpawn;

    void Start()
    {
        Instantiate(_gameObjectToSpawn);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
