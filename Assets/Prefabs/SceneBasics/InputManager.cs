using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour {

    public GameObject[] players;

    public bool onePlayer;
    public bool quadKeyboardInput;
    public bool keyboardAll;
    public bool fourControllers = true;
    public bool threeControllers;
    public bool twoControllers;

    void Awake()
    {
        setMovementInput();
    }

    void Update()
    {
        setMovementInput();
    }

	void setMovementInput () {

        // This script has a series of booleans that when triggered change the input preferences
        // It sets the four inputs that the players need: horizontal input, vertical input, jump input, interact input, and sprint
        // Also sets camera moving input NOT YET

        if (onePlayer)
        {
            players[0].GetComponent<Movement>().horizontalAxis = "Controller1Horizontal";
            players[0].GetComponent<Movement>().verticalAxis = "Controller1Vertical";
            players[0].GetComponent<Movement>().jumpButton = "Controller1A";
            players[0].GetComponent<Movement>().sprint = "Controller1RTLT";



            print("OnePlayer controls set");
            onePlayer = false;
        }

        if (quadKeyboardInput)
        {
            // Makes it so that each of the four players has their own WASD type setup
            // Player one = WASD move with X jump
            // Player two = TFGH move with B jump
            // Player three = IJKL move with M jump
            // Player four = Arrow Key move with Ctrl jump (not that with Ctrl jump Player 4 cannot jump when moving diaganolly)
            // This input is super hard to use and will probably only exist for testing purposes
            // All players sprint with shift

            players[0].GetComponent<Movement>().horizontalAxis = "Keyboard1Horizontal";
            players[0].GetComponent<Movement>().verticalAxis = "Keyboard1Vertical";
            players[0].GetComponent<Movement>().jumpButton = "Space";
            //players[0].GetComponent<Movement>().jumpButton = "Keyboard1Jump";
            players[0].GetComponent<Movement>().sprint = "Shift";

            players[1].GetComponent<Movement>().horizontalAxis = "Keyboard2Horizontal";
            players[1].GetComponent<Movement>().verticalAxis = "Keyboard2Vertical";
            players[1].GetComponent<Movement>().jumpButton = "Keyboard2Jump";
            players[1].GetComponent<Movement>().sprint = "Shift";

            players[2].GetComponent<Movement>().horizontalAxis = "Keyboard3Horizontal";
            players[2].GetComponent<Movement>().verticalAxis = "Keyboard3Vertical";
            players[2].GetComponent<Movement>().jumpButton = "Keyboard3Jump";
            players[2].GetComponent<Movement>().sprint = "Shift";

            players[3].GetComponent<Movement>().horizontalAxis = "Keyboard4Horizontal";
            players[3].GetComponent<Movement>().verticalAxis = "Keyboard4Vertical";
            players[3].GetComponent<Movement>().jumpButton = "Keyboard4Jump";
            players[3].GetComponent<Movement>().sprint = "Shift";

            print("QuadKeyboardInput set");
            quadKeyboardInput = false;
        }

        if (keyboardAll)
        {
            // This is simply an input where all four players are controlled by one single input at the same time
            // These controls are: WASD or Arrow Key movement with Space Bar jump, all players sprint with shift

            players[0].GetComponent<Movement>().horizontalAxis = "Horizontal";
            players[0].GetComponent<Movement>().verticalAxis = "Vertical";
            players[0].GetComponent<Movement>().jumpButton = "Space";
            players[0].GetComponent<Movement>().sprint = "Shift";

            players[1].GetComponent<Movement>().horizontalAxis = "Horizontal";
            players[1].GetComponent<Movement>().verticalAxis = "Vertical";
            players[1].GetComponent<Movement>().jumpButton = "Space";
            players[1].GetComponent<Movement>().sprint = "Shift";

            players[2].GetComponent<Movement>().horizontalAxis = "Horizontal";
            players[2].GetComponent<Movement>().verticalAxis = "Vertical";
            players[2].GetComponent<Movement>().jumpButton = "Space";
            players[2].GetComponent<Movement>().sprint = "Shift";

            players[3].GetComponent<Movement>().horizontalAxis = "Horizontal";
            players[3].GetComponent<Movement>().verticalAxis = "Vertical";
            players[3].GetComponent<Movement>().jumpButton = "Space";
            players[3].GetComponent<Movement>().sprint = "Shift";

            print("KeyboardAll set");
            keyboardAll = false;
        }

        if (fourControllers)
        {
            // Controllers control player one-four (Xbox 360)

            players[0].GetComponent<Movement>().horizontalAxis = "Controller1Horizontal";
            players[0].GetComponent<Movement>().verticalAxis = "Controller1Vertical";
            players[0].GetComponent<Movement>().jumpButton = "Controller1A";
            players[0].GetComponent<Movement>().sprint = "Controller1RTLT";

            players[1].GetComponent<Movement>().horizontalAxis = "Controller2Horizontal";
            players[1].GetComponent<Movement>().verticalAxis = "Controller2Vertical";
            players[1].GetComponent<Movement>().jumpButton = "Controller2A";
            players[1].GetComponent<Movement>().sprint = "Controller2RTLT";

            players[2].GetComponent<Movement>().horizontalAxis = "Controller3Horizontal";
            players[2].GetComponent<Movement>().verticalAxis = "Controller3Vertical";
            players[2].GetComponent<Movement>().jumpButton = "Controller3A";
            players[2].GetComponent<Movement>().sprint = "Controller3RTLT";

            players[3].GetComponent<Movement>().horizontalAxis = "Controller4Horizontal";
            players[3].GetComponent<Movement>().verticalAxis = "Controller4Vertical";
            players[3].GetComponent<Movement>().jumpButton = "Controller4A";
            players[3].GetComponent<Movement>().sprint = "Controller4RTLT";

            print("FourControllers set");
            fourControllers = false;
        }

        if (threeControllers)
        {
            //Players 1 and 4 have their own controller, where players 2 and 3 split a third controller

            players[0].GetComponent<Movement>().horizontalAxis = "Controller1Horizontal";
            players[0].GetComponent<Movement>().verticalAxis = "Controller1Vertical";
            players[0].GetComponent<Movement>().jumpButton = "Controller1A";
            players[0].GetComponent<Movement>().sprint = "Controller1ClickL";

            players[1].GetComponent<Movement>().horizontalAxis = "Controller2Horizontal";
            players[1].GetComponent<Movement>().verticalAxis = "Controller2Vertical";
            players[1].GetComponent<Movement>().jumpButton = "Controller2LB";
            players[1].GetComponent<Movement>().sprint = "Controller2ClickL";

            players[2].GetComponent<Movement>().horizontalAxis = "Controller2HorizontalR";
            players[2].GetComponent<Movement>().verticalAxis = "Controller2VerticalR";
            players[2].GetComponent<Movement>().jumpButton = "Controller2RB";
            players[2].GetComponent<Movement>().sprint = "Controller2ClickR";

            players[3].GetComponent<Movement>().horizontalAxis = "Controller3Horizontal";
            players[3].GetComponent<Movement>().verticalAxis = "Controller3Vertical";
            players[3].GetComponent<Movement>().jumpButton = "Controller3A";
            players[3].GetComponent<Movement>().sprint = "Controller3ClickL";


            print("ThreeControllers set");
            threeControllers = false;
        }

        if (twoControllers)
        {
            // Only need to set up right analog for first two controllers
            // Moving = player 1- Controller one, left analog. player 2- Controller one, right analog. Controller 2 - left analog player 3, right analog player 4
            // Sprinting = 

            players[0].GetComponent<Movement>().horizontalAxis = "Controller1Horizontal";
            players[0].GetComponent<Movement>().verticalAxis = "Controller1Vertical";
            players[0].GetComponent<Movement>().jumpButton = "Controller1LB";
            players[0].GetComponent<Movement>().sprint = "Controller1ClickL";

            players[1].GetComponent<Movement>().horizontalAxis = "Controller1HorizontalR";
            players[1].GetComponent<Movement>().verticalAxis = "Controller1VerticalR";
            players[1].GetComponent<Movement>().jumpButton = "Controller1RB";
            players[1].GetComponent<Movement>().sprint = "Controller1ClickR";

            players[2].GetComponent<Movement>().horizontalAxis = "Controller2Horizontal";
            players[2].GetComponent<Movement>().verticalAxis = "Controller2Vertical";
            players[2].GetComponent<Movement>().jumpButton = "Controller2LB";
            players[2].GetComponent<Movement>().sprint = "Controller2ClickL";

            players[3].GetComponent<Movement>().horizontalAxis = "Controller2HorizontalR";
            players[3].GetComponent<Movement>().verticalAxis = "Controller2VerticalR";
            players[3].GetComponent<Movement>().jumpButton = "Controller2RB";
            players[3].GetComponent<Movement>().sprint = "Controller2ClickR";

            print("TwoControllers set");
            twoControllers = false;
        }
    }
}
