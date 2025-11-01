using UnityEngine;

public abstract class MapMoveable : MonoBehaviour
{
    protected Rigidbody2D rb;
    public float speed = 10;


    protected float x, y;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    protected abstract void Move();
    protected abstract void CheckStop();
    void Update()
    {
        Move();

        CheckStop();

    }
}
