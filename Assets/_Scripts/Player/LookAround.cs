// Oz
using UnityEngine;
using UnityEngine.AI;
public class LookAround : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private Touch touch;
    [SerializeField] private LayerMask PlayerLayer, FoodLayer, BushLayer, BaseLayer, Walkable;

    public Interactable Search()
    {
        Interactable interactable = new Interactable();

        Collider[] enemies = Physics.OverlapSphere(transform.position, player.stats.GetSightRange(), PlayerLayer, QueryTriggerInteraction.Ignore);
        Collider[] foods = Physics.OverlapSphere(transform.position, player.stats.GetSightRange(), FoodLayer, QueryTriggerInteraction.Ignore);
        Collider[] bushes = Physics.OverlapSphere(transform.position, player.stats.GetSightRange(), BushLayer, QueryTriggerInteraction.Ignore);

        if (enemies.Length != 0)
        {
            Transform enemy = GetNearestTarget(enemies);
            if (touch.ComparePowers(enemy))
            {
                interactable.transform = enemy;
                interactable.type = Interactable.Type.Enemy;
            }
            else
            {
                interactable.Position = GetRandomBasePoint();
                interactable.type = Interactable.Type.None;
            }
        }
        else if (!player.stats.GetIsHungry())
        {
            interactable.Position = GetRandomBasePoint();
            interactable.type = Interactable.Type.ToBase;
        }
        else if (foods.Length != 0)
        {
            Transform food = GetNearestTarget(foods);

            interactable.transform = food.transform;
            interactable.type = Interactable.Type.Food;
        }
        else if (bushes.Length != 0)
        {
            Transform bush = GetNearestTarget(bushes);

            interactable.transform = bush.transform;
            interactable.type = Interactable.Type.Bush;
        }
        else
        {
            interactable.Position = GetRandomPoint();
            interactable.type = Interactable.Type.None;
        }
        return interactable;
    }

    public Vector3 GetRandomBasePoint()
    {
        Vector3 randomDirection = Random.insideUnitSphere * 5;

        randomDirection += transform.position;

        NavMeshHit navHit;

        NavMesh.SamplePosition(randomDirection, out navHit, 5, BaseLayer);

        return navHit.position;
    }

    private Vector3 GetRandomPoint()
    {
        Vector3 randomDirection = Random.insideUnitSphere * 5;

        randomDirection += transform.position;

        NavMeshHit navHit;

        NavMesh.SamplePosition(randomDirection, out navHit, 5, Walkable);

        return navHit.position;
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
