using UnityEngine;

public class ChaseState : IState
{

    private NPCController controller;
    public ChaseState(NPCController newController) {
        controller = newController;
    }
    public void Enter() {
        controller.Agent.isStopped = false;
        controller.Agent.speed = 4f;
    }

    public void Update() {
        Debug.Log("Chasing");
        var distance = controller.GetDistanceToTarget();
        controller.Agent.SetDestination(controller.Target.position); 
        if (distance <= controller.Agent.stoppingDistance) {
            controller.SwitchToAttack();
        }
        if (distance > 10f) {
            controller.SwitchToIdle();
        }
    }

    public void Exit() {
        
    }
    
    
}
