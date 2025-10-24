using UnityEngine;
using System;
using TMPro;

public class Phone : MonoBehaviour
{
   [SerializeField] private TextMeshPro text;
   private string _currentNumber = "";
   
   public void OnDigitButton(int digit) {
      if (_currentNumber.Length < 10) {
         _currentNumber += digit;
         text.text = _currentNumber;
      }
   }

   public void OnCallButton() {
      Debug.Log("call");
   }

   public void OnClearButton() {
      _currentNumber = "";
      text.text = "";
   }
}
