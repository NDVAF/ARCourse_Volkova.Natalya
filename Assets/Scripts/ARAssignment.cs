using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ARAssignment : MonoBehaviour
{
    [Space(10)]
    [Header("1. Basic Types")]
    public int IntValue = 5;
    public float FloatValue = 3.14f;
    public string StringValue = "Hello";
    public bool BoolValue = true;

    [Tooltip("Choose color for visualization")]
    public Color ColorValue = Color.blue;

    [Space(10)]
    [Header("2. Collection Field")]
    [Tooltip("List of string items")]
    public List<string> Items = new List<string>();

    [Space(10)]
    [Header("3. Reference to another component")]
    [SerializeField] private MessageLogger _logger;

    [Header("4. Prefab")]
    public GameObject PrefabToSpawn;

    private bool hasSpawned = false;

    void Start()
    {
        
        if (Items.Count == 0)
        {
            
            Items.Add("First");
            Items.Add("Second");
            Items.Add("Third");
        }

        
        if (_logger != null)
        {
            _logger.LogMessage();
        }
    }

    void Update()
    {
        if (!hasSpawned && Time.frameCount == 1)
        {
            SpawnPrefab();
            hasSpawned = true;
        }
    }

    void SpawnPrefab()
    {
        if (PrefabToSpawn != null)
        {
            Vector3 spawnPosition = transform.position + Vector3.up * 2;
            GameObject spawnedPrefab = Instantiate(PrefabToSpawn, spawnPosition, Quaternion.identity);

            Debug.Log("Куб создан на сцене!");

            MaterialColorChanger colorChanger = spawnedPrefab.GetComponent<MaterialColorChanger>();
            if (colorChanger == null)
            {
                colorChanger = spawnedPrefab.AddComponent<MaterialColorChanger>();
            }

            colorChanger.SetColor(ColorValue);

            
            Debug.Log($"Цвет куба: {ColorValue}");
        }
        else
        {
            Debug.LogWarning("Prefab не назначен!");
        }
    }
}
