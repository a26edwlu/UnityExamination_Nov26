using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class DangerObject : MonoBehaviour
{
  public UnityEvent onTouch;
  private void OnTriggerEnter2D(Collider2D other)
  {
    onTouch.Invoke(); 
    Destroy(other.gameObject);
  }
}
