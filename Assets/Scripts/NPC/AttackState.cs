using UnityEngine;

public class AttackState : IState
{
    private NPCController controller;

    public AttackState(NPCController newController) {
        controller = newController;
    }
    
    public void Enter() {
        controller.Agent.isStopped = true;
    }

    public void Update() {
        Debug.Log("atttttacking");
        var distance = controller.GetDistanceToTarget();
        if (distance > 3f) {
            controller.SwitchToChase();
        }
    }

    public void Exit() {
        
    }
}
