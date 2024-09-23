using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int id;  
    public bool isAlive = true;

    public void OnDeath()
    {
        isAlive = false;
    }
}
