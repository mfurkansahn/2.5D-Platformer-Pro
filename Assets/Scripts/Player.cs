using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{   
    private CharacterController _controller;
    [SerializeField]
    private float _speed = 5.0f;
    [SerializeField]
    private float _gravity = 1.0f;
    [SerializeField]
    private float _jumpHeight = 15.0f;
    private float _yVelocity;
    [SerializeField]
    private bool _canDoubleJump = false;
    //variable for player coins
    [SerializeField]
    private int _coins;
    [SerializeField]
    private UIManager _uiManager;
    [SerializeField]
    private int _lives = 3;


    // Start is called before the first frame update
    void Start()
    {
        _controller = GetComponent<CharacterController>();
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();

        if(_uiManager == null)
        {
            Debug.LogError("The UI Manager is NULL.");
        }
        _uiManager.UpdateLivesDisplay(_lives);

    }

    // Update is called once per frame
    void Update()
    {
        //get horizantal input
        float horizontalInput = Input.GetAxis("Horizontal");
        //define direction based on that input
        Vector3 direction = new Vector3(horizontalInput, 0, 0);
        //direction with speed
        //velocity = direction with speed 
        Vector3 velocity = direction * _speed;


        //if grounded
        //do nothing
        //else
        //apply gravity

        if(_controller.isGrounded == true)
        {
            //do nothing maybe jump later 
            //(if i hit the space key)
            //(jump! assign y velocity to  jumpHeight)
            if(Input.GetKeyDown(KeyCode.Space))
            {
                //check for double jump
                //current _yVelocity += jumpHeight 
                _yVelocity = _jumpHeight;
                _canDoubleJump = true;
            }
        }
        else
        {   
            if(Input.GetKeyDown(KeyCode.Space))
            {   
                if(_canDoubleJump == true)
                {
                    _yVelocity += _jumpHeight*2;
                    _canDoubleJump = false;
                }
                
            }
            _yVelocity -= _gravity;
        }

        velocity.y = _yVelocity;

        //MOVE based on that direction
        _controller.Move(velocity * Time.deltaTime);
    }
    public void AddCoins()
    {
        _coins++;

        _uiManager.UpdateCoinDisplay(_coins);
    }
    public void Damage()
    {
        _lives--;

        //updateUI display 
        _uiManager.UpdateLivesDisplay(_lives);
        
        if(_lives < 1)
        {
            SceneManager.LoadScene(0);
        }
    }
}
