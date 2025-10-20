using Unity.VisualScripting;
using UnityEngine;

public class IdleState : IState
{
    
    private NPCController controller;

    public IdleState(NPCController newController) {
        controller = newController;
    }
    
    public void Enter() {
        var distanceToCampfire = controller.GetDistanceToCampFire();
        if (distanceToCampfire > 2.5f) {
            controller.Agent.SetDestination(controller.CampFire.transform.position);
        }
        else {
            controller.Agent.isStopped = true;
        }
    }

    public void Update() {
        var distance = controller.GetDistanceToTarget();
        if (distance < 10f) {
            controller.SwitchToChase();
        }
        Debug.Log("маячим вхолостую");
    }

    public void Exit() {
        //встал
    }
}
