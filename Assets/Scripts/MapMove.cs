using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class MapMove : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed = 10;


    float x, y;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Move()
    {
             if (Input.GetKey(KeyCode.W)) { y = +1; }
        else if (Input.GetKey(KeyCode.S)) { y = -1; }
        else if (Input.GetKey(KeyCode.D)) { x = +1; }
        else if (Input.GetKey(KeyCode.A)) { x = -1; }


        rb.linearVelocity = new Vector3(x * speed, y * speed, 0);
    }
    private void Stop()
    {
        if (Input.GetKeyUp(KeyCode.W))
        {
            y = 0;
            transform.position = new Vector3(transform.position.x, Mathf.Ceil(transform.position.y), 0);
            /*
            Vector3 target = new Vector3(transform.position.x, Mathf.Ceil(transform.position.y), 0);

            while(transform.position != target)
            {
                Vector3.MoveTowards(transform.position, target, speed);
            }
            */
        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            y = 0;
            transform.position = new Vector3(transform.position.x, Mathf.Floor(transform.position.y), 0);
            /*
            Vector3 target = new Vector3(transform.position.x, Mathf.Floor(transform.position.y), 0);

            while (transform.position != target)
            {
                Vector3.MoveTowards(transform.position, target, speed);
            }
            */
        }
        else if (Input.GetKeyUp(KeyCode.D))
        {
            x = 0;
            transform.position = new Vector3(Mathf.Ceil(transform.position.x), transform.position.y, 0);
            /*
            Vector3 target = new Vector3(Mathf.Ceil(transform.position.x), transform.position.y, 0);

            while (transform.position != target)
            {
                Debug.Log(transform.position);
                Vector3.MoveTowards(transform.position, target, speed);
            }
            */
        }
        else if (Input.GetKeyUp(KeyCode.A))
        {
            x = 0;
            transform.position = new Vector3(Mathf.Floor(transform.position.x), transform.position.y, 0);
            /*
            Vector3 target = new Vector3(Mathf.Floor(transform.position.x), transform.position.y, 0);

            while (transform.position != target)
            {
                Vector3.MoveTowards(transform.position, target, speed);
            }
            */
        }
    }
    void Update()
    {
        Move();

        Stop();

    }
}
