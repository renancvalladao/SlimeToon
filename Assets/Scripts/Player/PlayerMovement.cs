using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Classe respons�vel pela movimenta��o do Player, tanto input quanto c�lculo de posi��o
public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    PlayerController controllerScript;

    [SerializeField]
    PaintManager paintManager;

    public float moveSpeed;

    [HideInInspector]
    public float mx = 0;
    [HideInInspector]
    public float my = 0;

    public Grid grid;

    [HideInInspector]
    public float gridSize;

    public Transform movePoint;

    public LayerMask whatStopsMovement;

    private Vector2 startTouchPosition;
    private Vector2 currentPosition;
    private Vector2 endTouchPosition;
    private bool stopTouch = false;

    public float swipRange;

    void Start()
    {
        gridSize = grid.cellSize.x; // Essa vari�vel � usada para calcular a dist�ncia baseada no tamanho do grid
        movePoint.parent = null; // Desfaz a associa��o entre Player e Player Move Point, para que ele se mova de forma livre
    }

    void Update()
    {
        if (!SceneManagement.gameIsPaused)
        {
            //MovementInput();
            MobileInput();
        }
        NextPosition();
    }

    private void FixedUpdate()
    {
        Move();
    }

    // Trata os inputs para PC, sendo que ele s� l� esses inputs no caso do Player estar parado
    void MovementInput()
    {
        if(transform.position == movePoint.position)
        {
            mx = Input.GetAxisRaw("Horizontal");
            if(mx == 0)
            {
                my = Input.GetAxisRaw("Vertical");
            }
        }        
    }

    // Realiza o movimento do Player em dire��o ao Move Point
    void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);
    }

    // Calcula o pr�ximo tile para qual o Player deve se mover
    void NextPosition()
    {
        if(Vector3.Distance(transform.position, movePoint.position) <= .5f) // Apenas permite calcular a pr�xima posi��o quando o Player j� est� pr�ximo do Move Point
        {
            if (mx != 0)
            {
                Vector3 nextPos = movePoint.position + new Vector3(gridSize * mx, 0f, 0f);
                if (!Physics2D.OverlapCircle(nextPos, .2f, whatStopsMovement)) // Verifica se o Move Point encostou em algum objeto que para o movimento
                {
                    if (paintManager.IsNextPainted(nextPos)) // Verifica se a pr�xima posi��o j� estaria pintada
                    {
                        if (paintManager.NextColor(nextPos) == controllerScript.playerColor) // Verifica se a cor do que seria a pr�xima posi��o � igual a do Player
                        {
                            movePoint.position += new Vector3(gridSize * mx, 0f, 0f);
                        }
                        else
                        {
                            mx = 0;
                        }
                    }
                    else
                    {
                        movePoint.position += new Vector3(gridSize * mx, 0f, 0f);
                    }
                }
                else
                {
                    mx = 0;
                }
            }
            else if (my != 0)
            {
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, gridSize * my, 0f), .2f, whatStopsMovement))
                {
                    Vector3 nextPos = movePoint.position + new Vector3(0f, gridSize * my, 0f);
                    if (paintManager.IsNextPainted(nextPos))
                    {
                        if (paintManager.NextColor(nextPos) == controllerScript.playerColor)
                        {
                            movePoint.position += new Vector3(0f, gridSize * my, 0f);
                        }
                        else
                        {
                            my = 0;
                        }
                    }
                    else
                    {
                        movePoint.position += new Vector3(0f, gridSize * my, 0f);
                    }
                }
                else
                {
                    my = 0;
                }
            }
        }
        
    }

    // Trata os inputs para mobile, sendo que ele s� l� esses inputs no caso do Player estar parado
    // O input � dado a partir do movimento de deslizar o dedo na tela, captando dire��o e sentido
    void MobileInput()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            startTouchPosition = Input.GetTouch(0).position;
        }
        if (transform.position == movePoint.position)
        {
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                currentPosition = Input.GetTouch(0).position;
                Vector2 Distance = currentPosition - startTouchPosition;

                if (!stopTouch)
                {
                    if (Distance.x < -swipRange)
                    {
                        mx = -1;
                        stopTouch = true;
                    }
                    else if (Distance.x > swipRange)
                    {
                        mx = 1;
                        stopTouch = true;
                    }
                    else if (Distance.y > swipRange)
                    {
                        my = 1;
                        stopTouch = true;
                    }
                    else if (Distance.y < -swipRange)
                    {
                        my = -1;
                        stopTouch = true;
                    }
                }
            }
        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            stopTouch = false;
            endTouchPosition = Input.GetTouch(0).position;
            //Vector2 Distance = endTouchPosition - startTouchPosition;
        }
    }
}
