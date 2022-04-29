// Oz
using UnityEngine;
using UnityEngine.AI;
using System;
public class Movement : MonoBehaviour
{
    /*
     * Hard Coded:
     * Quarenion.Slerp : 50f* time.deltaTime
     * IsArrived: .5f
     */
    public enum Locations
    {
        Base,
        Wilderness
    }

    [SerializeField] private LayerMask baseLayer;
    private StatController statController;
    private StateMachine stateMachine;
    private NavMeshAgent agent; 
    private Player player;

    public Action DoWhenAtBase;

    private Vector3 startPosition;
    private Vector3 targetPoint;

    private void Start()
    {
        statController = GetComponent<StatController>();
        stateMachine = GetComponent<StateMachine>();
        agent = GetComponent<NavMeshAgent>();
        player = GetComponent<Player>();
        startPosition = new Vector3();
    }

    public bool Walk(Vector3 point)
    {
        if (IsArrived(point)) return true;
        StepCheck();
        if (point != targetPoint)
        {
            targetPoint = point;

            Look(point);
            stateMachine.SetState(StateMachine.State.Walk);
            agent.SetDestination(point);
        }
        return false;
    }
    
    private void Look(Vector3 target)
    {
        Vector3 directon = (target - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(directon.x, 0f, directon.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 50f);
    }

    private void StepCheck()
    {
        if (startPosition == new Vector3()) startPosition = transform.position;

        if (WhereAmI() == Locations.Wilderness)
        {
            float distance = GetDistance(startPosition);
            statController.CastWalking(distance);
            startPosition = transform.position;
        }
    }

    public Locations WhereAmI()
    {
        bool isBase = Physics.CheckSphere(transform.position, 0.5f, baseLayer);
        if (isBase)
        {
            if (DoWhenAtBase != null)
            {
                DoWhenAtBase();
                DoWhenAtBase = null;
            }
            
            return Locations.Base;
        }
        else
            return Locations.Wilderness;
    }

    public bool IsArrived(Vector3 point) => GetDistance(point) < .5f;
    private float GetDistance(Vector3 point) => Vector3.Distance(transform.position, point);
}
