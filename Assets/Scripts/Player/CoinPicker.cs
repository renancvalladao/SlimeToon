using UnityEngine;
using TMPro;
using UnityEngine.UI;

// Classe respons�vel pela coleta das moedas e atualiza��o do texto do contador
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

    // Na colis�o com uma moeda, diminui o contador e verifica se chegou a 0, que � condi��o de vit�ria
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
