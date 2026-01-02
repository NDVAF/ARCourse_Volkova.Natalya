using UnityEngine;

public class Coin : MonoBehaviour
{
    public float rotationSpeed = 100f;

    void Update()
    {
        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Найти PlayerController на сцене
            PlayerController player = FindObjectOfType<PlayerController>();
            
            if (player != null)
            {
                player.AddCoin();
                Debug.Log("Монетка собрана через триггер!");
            }
            else
            {
                Debug.LogError("PlayerController не найден на сцене!");
            }
            
            Destroy(gameObject);
        }
    }
}