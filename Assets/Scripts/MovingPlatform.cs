using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField]
    private Transform _targetA, _targetB;
    [SerializeField]
    private float _speed = 1.0f;
    private bool _switching = false;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (_switching == false)
        {   
            //current transform = Vector3.Movetowards (current pos, target?)
            transform.position = Vector3.MoveTowards(transform.position, _targetB.position, _speed * Time.deltaTime);
        }
        else if (_switching == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, _targetA.position, _speed * Time.deltaTime);
        }

        //if cureent position == targetB
        //go to targetA

        if(transform.position == _targetB.position)
        {
            _switching = true;
        }
        else if ( transform.position == _targetA.position)
        {
            _switching = false;
        }
        //go to point b 
        //if at point b
        //go to point a
        //if at point a 
        //go to point b

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.transform.parent = this.transform;
        }
    } 
    
    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            other.transform.parent = null;
        }
    }



    //collison detection with player 
    //if we collide with player 
    //take the player parent = this game object 

    //exit collison 
    //check if the player exited 
    //take the player parent == null
}
