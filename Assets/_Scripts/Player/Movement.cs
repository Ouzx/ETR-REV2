// Oz
using UnityEngine;
using UnityEngine.AI;
using System.Collections;
public class Movement : MonoBehaviour
{
    /*
     * Hard Coded:
     * Quarenion.Slerp : 50f* time.deltaTime
     */
    public enum Locations
    {
        Base,
        Wilderness
    }

    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private LayerMask baseLayer;
    private StateMachine stateMachine;
    private Player player;

    private Vector3 startPosition;
    private Vector3 targetPoint;

    private void Start()
    {
        stateMachine = GetComponent<StateMachine>();
        player = GetComponent<Player>();
        startPosition = new Vector3();
    }

    public void Walk(Vector3 point)
    {
        StepCheck();
        if (point == targetPoint)
            return;
        targetPoint = point;
        Look(point);
        stateMachine.SetState(StateMachine.State.Walk);
        agent.SetDestination(point);
    }

    private void StepCheck()
    {
        if (startPosition == new Vector3()) startPosition = transform.position;
        
        if (WhereAmI() == Locations.Wilderness)
        {
            float distance = GetDistance(startPosition);
            player.GetTired(distance);
            startPosition = transform.position;
        }
    }

    private void Look(Vector3 target)
    {
        Vector3 directon = (target - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(directon.x, 0f, directon.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 50f);
    }

    private float GetDistance(Vector3 point) => Vector3.Distance(transform.position, point);

    public Locations WhereAmI()
    {
        bool isBase = Physics.CheckSphere(transform.position, 0.5f, baseLayer);
        if (isBase)
            return Locations.Base;
        else
            return Locations.Wilderness;
    }
}
