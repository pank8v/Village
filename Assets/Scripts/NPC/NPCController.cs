using UnityEngine;
using UnityEngine.AI;

public class NPCController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    public Animator Animator => animator;
    [SerializeField] private Transform target;
    public Transform Target => target;
    private StateMachine stateMachine;
    [SerializeField] private NavMeshAgent agent;
    public NavMeshAgent Agent => agent;
    [SerializeField] private Transform campFire;
    public Transform CampFire => campFire;
    
    private void Start() {
        stateMachine = new StateMachine();
        stateMachine.ChangeState(new IdleState(this));
    }

    private void Update() {
        stateMachine.Update();
    }

    public float GetDistanceToTarget() {
        return Vector3.Distance(transform.position, target.position);
    }
    
    public float GetDistanceToCampFire() {
        return Vector3.Distance(transform.position, campFire.position);
    }

    public void SwitchToIdle() {
        stateMachine.ChangeState(new IdleState(this));
    }

    public void SwitchToChase() {
        stateMachine.ChangeState(new ChaseState(this));
    }

    public void SwitchToPatrol() {
      stateMachine.ChangeState(new PatrolState(this));
    }

    public void SwitchToAlert() {
        stateMachine.ChangeState(new AlertState(this));
    }

    public void SwitchToSearch() {
        stateMachine.ChangeState(new SearchState(this));
    }

    public void SwitchToAttack() {
        stateMachine.ChangeState(new AttackState(this));
    }

}
