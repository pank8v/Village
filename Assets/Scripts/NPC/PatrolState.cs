using UnityEngine;

public class PatrolState : IState
{
    private NPCController controller;

    public PatrolState(NPCController newController) {
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
