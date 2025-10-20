using UnityEngine;

public class AlertState : IState
{
    private NPCController controller;
    
    public AlertState(NPCController newController) {
        controller = newController;
    }
    
    public void Enter() {
        controller.Agent.isStopped = false;
    }

    public void Update() {
        //ходим по точкам
    }

    public void Exit() {
        
    }
}
