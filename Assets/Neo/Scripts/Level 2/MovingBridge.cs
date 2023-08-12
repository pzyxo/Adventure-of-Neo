using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBridge : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;
    [SerializeField] private GameObject NoCrossCollider; 
    private int currentWaypointIndex = 0;

    [SerializeField] private float speed = 2f;


    private void Update() {
        
        
            if(Vector2.Distance(waypoints[currentWaypointIndex].transform.position, transform.position) < .1f)
            {
                if(currentWaypointIndex < 1){
                    currentWaypointIndex++;
                }
                
                // if(currentWaypointIndex >= waypoints.Length)
                // {
                //     currentWaypointIndex = 0;
                // }
                
            }
            transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, Time.deltaTime * speed);
            if((Vector2.Distance(waypoints[currentWaypointIndex].transform.position, transform.position)) == 0)
            {
                NoCrossCollider.SetActive(false);
            }
        
    }
}
