using UnityEngine;
using System;

public class GameEvents : MonoBehaviour
{
   public static event Action<Player> OnPlayerSpawned;
   public static event Action<Player> OnPlayerKilled;

   public static void PlayerSpawned(Player player) {
      OnPlayerSpawned?.Invoke(player);
   }

   public static void PlayerKilled(Player player) {
      OnPlayerKilled?.Invoke(player);
   }
   
   
}
