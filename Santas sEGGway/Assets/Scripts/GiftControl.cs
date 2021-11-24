using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiftControl : MonoBehaviour
{
    public float speed;
    public float sensitivity;
    [SerializeField] int MaxX = 2;
    [SerializeField] int MaxY = 2;
    [SerializeField] int MinX = 2;
    [SerializeField] int MinY = 2;

    private Vector2 startingPos = Vector2.zero;
    private Vector2 movePos;
    // Start is called before the first frame update
    void Start()
    {
        SetGift();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal") * sensitivity;
        float vertical = Input.GetAxis("Vertical") * sensitivity;

        movePos.x += horizontal;
        movePos.y += vertical;

        movePos.x = Mathf.Clamp(movePos.x, MinX, MaxX);
        movePos.y = Mathf.Clamp(movePos.y, MinY, MaxY);

        transform.position = Vector2.Lerp(transform.position, movePos, speed * Time.deltaTime);
    }

    public void SetGift()
    {
        transform.position = startingPos;
        movePos = startingPos;
    }
}
