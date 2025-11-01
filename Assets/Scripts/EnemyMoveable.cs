using UnityEngine;

public class EnemyMoveable : MapMoveable
{
    protected override void CheckStop()
    {

    }

    protected override void Move()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<MapMoveable>(out MapMoveable character))
        {
            FightManager.instance.StartFight();
        }
    }
}
