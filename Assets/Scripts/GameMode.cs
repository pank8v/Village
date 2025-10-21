using UnityEngine;

public abstract class GameMode : MonoBehaviour
{
    public static GameMode Current { get; private set; }
    [SerializeField] protected GameObject defaultPlayerPrefab;
    public GameState GameState { get; protected set; }

    protected virtual void Awake() {
        if (Current != null) {
            Destroy(gameObject);
            return;
        }
        Current = this;
        DontDestroyOnLoad(gameObject);
    }


    protected virtual void Start() {
        InitGame();
    }

    protected virtual void InitGame() {
        GameState = new GameState();
        SpawnPlayers();
    }

    protected virtual void SpawnPlayers() {
        
    }


    public abstract void OnPlayerKilled(Player player);
    
    public abstract void OnGameEnd();
}
