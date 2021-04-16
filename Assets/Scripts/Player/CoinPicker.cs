using UnityEngine;
using TMPro;
using UnityEngine.UI;

// Classe responsável pela coleta das moedas e atualização do texto do contador
public class CoinPicker : MonoBehaviour
{
    private float coin;

    [SerializeField]
    private SceneManagement sceneManager;

    public TextMeshProUGUI textCoins;

    private void Start()
    {
        coin = GameObject.FindGameObjectsWithTag("Coin").Length; // Procura quantas moedas tem na fase
        textCoins.text = coin.ToString();
    }

    // Na colisão com uma moeda, diminui o contador e verifica se chegou a 0, que é condição de vitória
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "Coin")
        {
            coin--;
            textCoins.text = coin.ToString();
            Destroy(collision.gameObject);
            if(coin == 0)
            {
                sceneManager.CompleteLevel();
            }
        }
    }
}
