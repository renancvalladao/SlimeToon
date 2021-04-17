using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Classe responsável por controllar algumas propriedades do jogador
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    internal PlayerMovement movementScript;

    public string playerColor;

    // Inicia o jogador como incolor
    void Start()
    {
        playerColor = "Colorless";
    }

    void Update()
    {
        
    }

    // Método que altera o slime para azul
    public void ChangeToBlue()
    {
        SpriteRenderer Sprite = GetComponent<SpriteRenderer>();
        Sprite.color = new Color(0, 0.5f, 1, 1);
    }

    // Método que altera o slime para laranja
    public void ChangeToOrange()
    {
        SpriteRenderer Sprite = GetComponent<SpriteRenderer>();
        Sprite.color = new Color(1, 0.5f, 0, 1);
    }
}
