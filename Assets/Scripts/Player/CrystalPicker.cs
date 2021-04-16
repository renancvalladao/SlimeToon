using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Classe responsável pela coleta da tinta pelo Player
public class CrystalPicker : MonoBehaviour
{
    [SerializeField]
    internal PlayerController controllerScript;

    // Trata a colisão do Player com uma tinta
    // Caso o Player esteja incolor, tem um atraso de 0.1s para mudar sua cor, previnindo que suje o tile anterior à tinta
    // Além disso, muda a cor do Player para a cor da tinta que ele coletou, destrói o objeto e chama a função que altera a sprite do Player para a cor correspondente
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Crystal"))
        {
            string color = collision.GetComponent<Crystal>().Color;
            Destroy(collision.gameObject);
            if (controllerScript.playerColor == "Colorless")
            {
                StartCoroutine(ExampleCoroutine(color));
            }
            else
            {
                controllerScript.playerColor = color;
            }
            switch (color)
            {
                case "Blue":
                    controllerScript.ChangeToBlue();
                    break;
                case "Orange":
                    controllerScript.ChangeToOrange();
                    break;
            }   
        }
    }

    IEnumerator ExampleCoroutine(string color)
    {
        yield return new WaitForSeconds(0.1f);
        controllerScript.playerColor = color;
 
    }
}
