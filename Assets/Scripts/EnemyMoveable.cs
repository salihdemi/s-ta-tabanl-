using UnityEngine;

public class EnemyMoveable : MapMoveable
{
    [SerializeField] private Enemy[] enemies;




    //public bool trigger;
    protected override void Move()
    {
        /*
        float targetX = MainCharacterMoveable.instance.transform.position.x;
        float targetY = MainCharacterMoveable.instance.transform.position.y;

        float currentX = transform.position.x;
        float currentY = transform.position.y;
        if(trigger)
        {
            //x uzaksa
            if (Mathf.Abs(currentX - targetX) >= Mathf.Abs(currentY - targetY))
            {
                x = Mathf.Sign(currentX - targetX);
            }
            //y uzaksa
            else
            {
                y = Mathf.Sign(currentY - targetY);
            }

            rb.linearVelocity = new Vector3(x * speed, y * speed, 0);
        }
        */
    }

    protected override void CheckStop()
    {

    }

    //Savaþa giriþ
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<MapMoveable>(out MapMoveable character))
        {
            FightManager.instance.StartFight(enemies);
        }
    }
    /*
    //Tetikleniþ
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(!trigger && other.gameObject.GetComponent<MainCharacterMoveable>())
        {
            trigger = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (trigger && other.gameObject.GetComponent<MainCharacterMoveable>())
        {
            trigger = false;
        }
    }
    */
}
