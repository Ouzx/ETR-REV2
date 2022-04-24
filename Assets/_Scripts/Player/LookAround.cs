// Oz
using UnityEngine;

public class LookAround : MonoBehaviour
{
    private Player player;
    private Attack attack;
    [SerializeField] private LayerMask PlayerLayer, FoodLayer, BushLayer;

    private void Start()
    {
        player = GetComponent<Player>();
        attack = GetComponent<Attack>();
    }


    public Vector3 Search()
    {
        Collider[] enemies = Physics.OverlapSphere(transform.position, player.stats.GetSightRange(), PlayerLayer, QueryTriggerInteraction.Ignore);
        Collider[] foods = Physics.OverlapSphere(transform.position, player.stats.GetSightRange(), FoodLayer, QueryTriggerInteraction.Ignore);
        Collider[] bushes = Physics.OverlapSphere(transform.position, player.stats.GetSightRange(), BushLayer, QueryTriggerInteraction.Ignore);

        if (enemies.Length != 0)
        {
            Transform enemy = GetNearestTarget(enemies);
            if (attack.ComparePowers(enemy)) return enemy.position;
            else return GetRandomBasePoint();
        }
        else if (foods.Length != 0)
        {
            Transform food = GetNearestTarget(foods);
            return food.transform.position;
        }
        else if (bushes.Length != 0) {
            Transform bush = GetNearestTarget(bushes);
            return bush.transform.position;
        }
        else
        {
            return GetRandomPoint();
        }
    }

    public Vector3 GetRandomBasePoint()
    {
        return transform.position;
    }

    private Vector3 GetRandomPoint()
    {
        return transform.position;
    }

    private Transform GetNearestTarget(Collider[] targets)
    {
        Transform target = targets[0].transform;

        foreach (Collider _target in targets)
        {
            if (Vector3.Distance(transform.position, _target.transform.position) < Vector3.Distance(transform.position, target.transform.position))
            {
                target = _target.transform;
            }
        }
        return target;
    }
}
