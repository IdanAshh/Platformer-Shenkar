using UnityEngine;
using UnityEngine.InputSystem;

public class BasicPlayer : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 moveSide;
    Vector2 moveUp;
    public float speed = 10;



    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Application.targetFrameRate = 60;
        if(rb == null)
        {
            Debug.Log("can't find the rigidbody on the player gameobject");
        }
    }
    private void Update()
    {
        var keboard = Keyboard.current;
        if (keboard != null)
        {
            if (keboard.aKey.IsPressed())
            {
                moveSide = new Vector2(-1, 0);
            }
            else
            {
                if (keboard.dKey.IsPressed())
                {
                    moveSide = new Vector2(1, 0);
                }
                else
                {
                    moveSide = Vector2.zero;
                }
            }
            if (keboard.sKey.IsPressed())
            {
                moveUp = new Vector2(0, -1);
            }
            else
            {
                if (keboard.wKey.IsPressed())
                {
                    moveUp = new Vector2(0, 1);
                }
                else
                {
                    moveUp = Vector2.zero;
                }
            }
        }
    }
    private void FixedUpdate()
    {
        if (rb != null)
        {
            Vector2 movement = moveUp + moveSide;
            rb.AddForce(movement * speed, ForceMode2D.Force);
        }
    }
}
