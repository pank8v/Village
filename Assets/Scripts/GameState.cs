using UnityEngine;
using System.Collections.Generic;
using System;
public class GameState : MonoBehaviour
{
   public float TimeRemaining { get; set; }
   public int Score { get; set; }
   public List<PlayerState> Players { get; set; } = new();
   
   public event Action<int> OnScoreChanged;

   public void AddScore(int amount) {
      Score += amount;
      OnScoreChanged?.Invoke(amount);
   }
}
