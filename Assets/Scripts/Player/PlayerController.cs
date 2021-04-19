using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Classe responsável por controllar algumas propriedades do jogador
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    internal PlayerMovement movementScript;

    public AnimatorOverrideController orangeAnim;
    public AnimatorOverrideController blueAnim;

    public string playerColor;

    private float mx;
    private float my;

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
        mx = GetComponent<Animator>().GetFloat("moveX");
        my = GetComponent<Animator>().GetFloat("moveY");
        GetComponent<Animator>().runtimeAnimatorController = blueAnim as RuntimeAnimatorController;
        GetComponent<Animator>().SetFloat("moveX", mx);
        GetComponent<Animator>().SetFloat("moveY", my);
    }

    // Método que altera o slime para laranja
    public void ChangeToOrange()
    {
        mx = GetComponent<Animator>().GetFloat("moveX");
        my = GetComponent<Animator>().GetFloat("moveY");
        GetComponent<Animator>().runtimeAnimatorController = orangeAnim as RuntimeAnimatorController;
        GetComponent<Animator>().SetFloat("moveX", mx);
        GetComponent<Animator>().SetFloat("moveY", my);
    }
}
