// Oz
using UnityEngine;
using UnityEngine.AI;
using System.Collections;
public class Movement : MonoBehaviour
{

    [SerializeField] NavMeshAgent agent;
    [SerializeField] StateMachine stateMachine;

    public LayerMask GroundLayer, BaseLayer, PlayerLayer, FoodLayer;

    private bool isWalkPointSet;
    private Vector3 walkPoint;
    private Transform target;

    public Transform PlayerBase;

    [SerializeField] float baseRandomRange;
    [SerializeField] Vector3 baseWalkPoint;
    [SerializeField] bool isBaseWalkPointSet;

    public void Walk() 
    { 
        // first, look for a target: food or enemy
        // if there is no target patrol
        // when player ready to interact: change player state to eat / attack
    }

    private Vector3 oldPos;
    IEnumerator Stepper()
    {
        oldPos = transform.position;
        while (true)
        {
            if (!isBase())
                if (Vector3.Distance(oldPos, transform.position) > 1)
                {
                    oldPos = transform.position;
                    //player.GetTired(player.walkingCost);
                }
            yield return new WaitForSeconds(Time.deltaTime * 1.5f);
        }
    }

    IEnumerator TargetChecker()
    {
        while (true)
        {
            if (target != null)
            {
                MoveToPoint(target.position);
                LookTarget();
                // transform.LookAt(target);
            }
            yield return new WaitForSeconds(0.1f);
        }
    }

    public void MoveToPoint(Vector3 point)
    {
        point.y = 0;
        //pc.stateController.OnStateChanged(State.Patrolling);
        agent.SetDestination(point);
    }

    public void FollowTarget(GameObject newTarget)
    {
        isWalkPointSet = false;
        isBaseWalkPointSet = false;
        //agent.stoppingDistance = player.attackRange.GetMaxValue() * 0.8f;
        agent.updateRotation = false;
        target = newTarget.transform;
    }
    public void StopFollowingTarget()
    {
        agent.stoppingDistance = 0;
        agent.updateRotation = true;
        target = null;
    }
    void LookTarget()
    {
        Vector3 directon = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(directon.x, 0f, directon.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 50f);
    }

    public void SetSpeed(float speed)
    {
        if (speed <= 0) speed = 1;
        agent.acceleration = speed;
    }

    public void Patrol()
    {
        if (target == null)
        {
            if (!isWalkPointSet) SearchWalkPoint();
            if (isWalkPointSet)
            {
                MoveToPoint(walkPoint);
            }
            Vector3 distanceToWalkPoint = transform.position - walkPoint;
            if (distanceToWalkPoint.magnitude < 1f) isWalkPointSet = false;
        }
    }
    void SearchWalkPoint()
    {
        //float walkPointRange = player.walkPointRange;
        ////if (isAtBase()) walkPointRange *= .5f; 
        //float randomZ = Random.Range(-walkPointRange, walkPointRange);
        //float randomX = Random.Range(-walkPointRange, walkPointRange);

        //walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2, GroundLayer))
            isWalkPointSet = true;
    }

    public void GoBase()
    {
        if (target == null)
        {
            if (!isBaseWalkPointSet) { baseWalkPoint = RandomPointInBase(6, 5); isBaseWalkPointSet = true; }
            if (isBaseWalkPointSet)
            {
                MoveToPoint(baseWalkPoint);
            }
            Vector3 distanceToWalkPoint = transform.position - baseWalkPoint;
            if (distanceToWalkPoint.magnitude < 1f) isBaseWalkPointSet = false;
        }
    }
    public void ToBase()
    {
        MoveToPoint(PlayerBase.position);
    }

    public Vector3 RandomPointInBase(float radiusX, float radiusZ)
    {
        return PlayerBase.position + new Vector3(
           (Random.value - 0.5f) * radiusX,
           transform.position.y,
           (Random.value - 0.5f) * radiusZ
        );
    }

    public bool isBase() => Physics.Raycast(transform.position, -transform.up, 2f, BaseLayer);

}
