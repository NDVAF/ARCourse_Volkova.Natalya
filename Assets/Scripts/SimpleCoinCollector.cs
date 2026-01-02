using UnityEngine;

public class SimpleCoinCollector : MonoBehaviour
{
    private int coins = 0;
    
    void Update()
    {
        // Проверяем монетки каждый кадр
        GameObject[] coinsArray = GameObject.FindGameObjectsWithTag("Coin");
        
        foreach (GameObject coin in coinsArray)
        {
            float distance = Vector3.Distance(transform.position, coin.transform.position);
            
            if (distance < 1f) // Если ближе чем 1 единица
            {
                coins++;
                Debug.Log("Монетка собрана ! Всего: " + coins);
                Destroy(coin);
            }
        }
    }
}