// Oz
using UnityEngine;
using UnityEngine.AI;
public class LookAround : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private Touch touch;
    [SerializeField] private LayerMask PlayerLayer, FoodLayer, BushLayer, GroundLayer;
    public Interactable Search()
    {
        GameManager.instance.Print(player.name, "Looking around...");
        Interactable interactable = new Interactable();
        // collider ekle
        Collider[] enemies = Physics.OverlapSphere(transform.position, player.stats.GetSightRange(), PlayerLayer, QueryTriggerInteraction.Ignore);
        Collider[] foods = Physics.OverlapSphere(transform.position, player.stats.GetSightRange(), FoodLayer, QueryTriggerInteraction.Ignore);
        Collider[] bushes = Physics.OverlapSphere(transform.position, player.stats.GetSightRange(), BushLayer, QueryTriggerInteraction.Ignore);
        GameManager.instance.Print(player.name, "Found " + enemies.Length + " enemies, " + foods.Length + " foods, and " + bushes.Length + " bushes.");
        if (enemies.Length != 0)
        {
            Transform enemy = GetNearestTarget(enemies);
            GameManager.instance.Print(player.name, "Found enemy: " + enemy.name + ". Comparing powers...");
            if (touch.ComparePowers(enemy))
            {
                GameManager.instance.Print(player.name, "I'm stronger than " + enemy.name + "! I'll attack!");
                interactable.transform = enemy;
                interactable.type = Interactable.Type.Enemy;
            }
            else
            {
                GameManager.instance.Print(player.name, "I'm weaker than " + enemy.name + "! I'll flee!");
                interactable.Position = GetRandomBasePoint();
                interactable.type = Interactable.Type.None;
            }
        }
        else if (!player.stats.GetIsHungry())
        {
            GameManager.instance.Print(player.name, "I'm not hungry! I'll go back to base!");
            interactable.Position = GetRandomBasePoint();
            interactable.type = Interactable.Type.ToBase;
        }
        else if (foods.Length != 0)
        {
            GameManager.instance.Print(player.name, "I'm hungry and Found food! I'll eat it!");
            Transform food = GetNearestTarget(foods);

            interactable.transform = food.transform;
            interactable.type = Interactable.Type.Food;
        }
        else if (bushes.Length != 0)
        {
            GameManager.instance.Print(player.name, "I can't see anything but bushes! I'll go there.");
            Transform bush = GetNearestTarget(bushes);

            interactable.transform = bush.transform;
            interactable.type = Interactable.Type.Bush;
        }
        else
        {
            GameManager.instance.Print(player.name, "I can't see anything! I'll go randomly.");
            interactable.Position = GetRandomPoint();
            interactable.type = Interactable.Type.None;
        }
        return interactable;
    }

    public Vector3 GetRandomBasePoint() => DummyPoints.instance.GetRandomBasePoint(player.playerType);

    private Vector3 GetRandomPoint()
    {
        float walkPointRange = player.stats.GetSightRange();
        
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);
        
        Vector3 walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);
        
        if (Physics.Raycast(walkPoint, -transform.up, 2, GroundLayer, QueryTriggerInteraction.Ignore))
            return walkPoint;
        else
            return GetRandomPoint();
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
