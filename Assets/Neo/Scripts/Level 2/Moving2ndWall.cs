using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving2ndWall : MonoBehaviour
{    
    private int currentWaypointIndex = 0;
    public static bool isCompleted2 = false;

    [SerializeField] private GameObject[] waypoints;
    [SerializeField] private float speed = 1f;
    [SerializeField] private AudioSource wallSoundEffect;

    private void Update() {
        
        if(isCompleted2)
        {
            if(Vector2.Distance(waypoints[currentWaypointIndex].transform.position, transform.position) < .1f)
            {
                if(currentWaypointIndex < 1){
                    wallSoundEffect.Play();
                    currentWaypointIndex++;
                }               
            }
            transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, Time.deltaTime * speed);
        }
    }

    public static void MoveWall()
    {
        isCompleted2 = true;
    }
}
