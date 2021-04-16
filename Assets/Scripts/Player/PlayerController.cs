using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    internal PlayerMovement movementScript;

    public string playerColor;
    // Start is called before the first frame update
    void Start()
    {
        playerColor = "Colorless";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeToBlue()
    {
        SpriteRenderer Sprite = GetComponent<SpriteRenderer>();
        Sprite.color = new Color(0, 0.5f, 1, 1);
    }

    public void ChangeToOrange()
    {
        SpriteRenderer Sprite = GetComponent<SpriteRenderer>();
        Sprite.color = new Color(1, 0.5f, 0, 1);
    }
}
