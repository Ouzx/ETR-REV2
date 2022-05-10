// Oz
using UnityEngine;
using UnityEngine.AI;
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
    private Locations location;

    [SerializeField] private StatController statController;
    [SerializeField] private StateMachine stateMachine;
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Player player;

    private Vector3 startPosition;

    private void Start()
    {
        startPosition = new Vector3();
    }

    public bool Walk(Vector3 point)
    {
        //agent.stoppingDistance = 0;
        agent.stoppingDistance = player.stats.GetAttackRange();
        agent.speed = player.stats.GetSpeed(); // TODO: SPEED OR ACCELERATION?
        //agent.SetDestination(point);
        if (!IsArrived(point))
        {
            //GameManager.instance.Print(player.name, " is walking to " + point);
            StepCheck();
            stateMachine.SetState(StateMachine.State.Walk);
            agent.SetDestination(point);
        }

        else 
        {
            //GameManager.instance.Print(player.name, " is at position:  " + point);
            //stateMachine.SetState(StateMachine.State.Idle);
            return true;
        }
        
        return false;
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
        if (player.playerType == Player.PlayerType.Player)
        {
            if (transform.position.z < -170) location = Locations.Base;
            else location = Locations.Wilderness;
        }
        else if (transform.position.z > -86) location = Locations.Base;
        else location = Locations.Wilderness;
        
        GameManager.instance.Print(player.name, " is at location: " + location);
        return location;
    }

    public bool IsArrived(Vector3 point)
    {
        //float dist = agent.remainingDistance;
        //return (dist != Mathf.Infinity && agent.pathStatus == NavMeshPathStatus.PathComplete && agent.remainingDistance <= player.stats.GetAttackRange());
        return (transform.position - point).magnitude <= player.stats.GetAttackRange();
    }

    private float GetDistance(Vector3 point) => Vector3.Distance(transform.position, point);
}
