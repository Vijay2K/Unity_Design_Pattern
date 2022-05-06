using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocomotionFSM : MonoBehaviour
{
    enum State
    {
        Grounded,
        InAir,
        Crouching
    }

    private State currentState = State.Grounded;

    private void Jump()
    {
        switch (currentState)
        {
            case State.Grounded:
                currentState = State.InAir;
                break;
            case State.Crouching:
                currentState = State.Grounded;
                break;
        }
    }

    private void Falling()
    {
        switch(currentState)
        {
            case State.Grounded:
                currentState = State.InAir;
                break;
            case State.Crouching:
                currentState = State.InAir;
                break;
        }
    }

    private void Land()
    {
        switch(currentState)
        {
            case State.InAir:
                currentState = State.Grounded;
                break;
        }
    }

    private void Crouch()
    {
        switch(currentState)
        {
            case State.Grounded:
                currentState = State.Crouching;
                break;
            case State.Crouching:
                currentState = State.Grounded;
                break;
        }
    }
}
