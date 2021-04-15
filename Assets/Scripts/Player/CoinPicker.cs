using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CoinPicker : MonoBehaviour
{
    private float coin;

    public TextMeshProUGUI textCoins;

    private void Start()
    {
        coin = GameObject.FindGameObjectsWithTag("Coin").Length;
        textCoins.text = coin.ToString();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "Coin")
        {
            coin--;
            textCoins.text = coin.ToString();
            Destroy(collision.gameObject);
        }
    }
}
