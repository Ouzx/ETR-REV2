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
        agent.stoppingDistance = player.stats.GetAttackRange();
        agent.speed = player.stats.GetSpeed(); // TODO: SPEED OR ACCELERATION?
        //agent.SetDestination(point);
        if (point != null)
        {
            GameManager.instance.Print(player.name, " is walking to " + point);
            StepCheck();
            stateMachine.SetState(StateMachine.State.Walk);
            agent.SetDestination(point);
        }

        if (IsArrived())
        {
            GameManager.instance.Print(player.name, " is at position:  " + point);
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
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Fred Base") && player.playerType == Player.PlayerType.Player)
        {
            location = Locations.Base;
        }
        else if (other.tag.Equals("Barney Base") && player.playerType == Player.PlayerType.Bot)
        {
            location = Locations.Base;
        }
    }
    public Locations WhereAmI()
    {
        GameManager.instance.Print(player.name, " is at location: " + location);
        return location;
    }

    public bool IsArrived()
    {
        float dist = agent.remainingDistance;
        return (dist != Mathf.Infinity && agent.pathStatus == NavMeshPathStatus.PathComplete && agent.remainingDistance <= player.stats.GetAttackRange());

    }

    private float GetDistance(Vector3 point) => Vector3.Distance(transform.position, point);
}
