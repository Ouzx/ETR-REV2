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


    public Interactable Search()
    {
        Interactable interactable = new Interactable();

        Collider[] enemies = Physics.OverlapSphere(transform.position, player.stats.GetSightRange(), PlayerLayer, QueryTriggerInteraction.Ignore);
        Collider[] foods = Physics.OverlapSphere(transform.position, player.stats.GetSightRange(), FoodLayer, QueryTriggerInteraction.Ignore);
        Collider[] bushes = Physics.OverlapSphere(transform.position, player.stats.GetSightRange(), BushLayer, QueryTriggerInteraction.Ignore);

        if (enemies.Length != 0)
        {
            Transform enemy = GetNearestTarget(enemies);
            if (attack.ComparePowers(enemy))
            {
                interactable.transform = enemy;
                interactable.type = Interactable.Type.Enemy;
            }
            else {
                interactable.position = GetRandomBasePoint();
                interactable.type = Interactable.Type.None;
            }
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
            interactable.position = GetRandomPoint();
            interactable.type = Interactable.Type.None;
        }
        return interactable;
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
