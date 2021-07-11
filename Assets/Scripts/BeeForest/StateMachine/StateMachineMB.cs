using System;
using System.Collections;
using UnityEngine;

public abstract class StateMachineMB : MonoBehaviour
{
    /// <summary>
    /// File that contains the State Machine (inheriting from MonoBehaviour) for switching States.
    /// </summary>

    /// <summary>
    /// The idea:
    /// A State Machine can be in one of a finite number of states. It can change from one state to
    /// another based on different kind of inputs. Each state the State Machine can transition to is handled
    /// by its own classes.
	/// The State Machine inherits MonoBehaviour to easily implement Component-based functionality.

    /// In order to implement this StateMachine, the following things are required:
    /// Create some sort of Controller that inherits from StateMachine.
    /// Create a few classes that inherit from State.
    /// Implement the required functions in the new State class.
    /// Create a few instances of the class somewhere in the new controller
    /// Using ChangeState(state) the states in the controller can be changed.
    /// If the States need more information, it's possible to pass them down in the Constructor when the Controller initializes them.
    /// </summary>

    #region Variables

    // Reference to State Interface.
    public IState currentState { get; private set; }
    public IState previousState;

    private bool _inTransition = false;

    #endregion


    #region Functions

	// Function that changes states from one into another.
    public void ChangeState(IState newState)
    {
        // Ensure current state is new state or in transition.
        if (currentState == newState || _inTransition)
        {
            return;
        }

		// Call the function for the transition between states.
        ChangeStateRoutine(newState);
    }

	// Function that allows to revert states.
    public void RevertState()
    {
        if (previousState != null)
        {
            ChangeState(previousState);
        }
    }

	// Function that handles the transition from one state into another.
    void ChangeStateRoutine(IState newState)
    {
		// State Machine is transitioning between states.
        _inTransition = true;

        // Begins the Exit sequence of one state to prepare for new state.
        if (currentState != null)
        {
            currentState.Exit();
        }

        // Saves the current state.
        if (previousState != null)
        {
            previousState = currentState;
        }

        currentState = newState;

        // Begins the Enter sequence of a new state.
        if (currentState != null)
        {
            currentState.Enter();
        }

		// State Machine is no longer transitioning between states.
        _inTransition = false;
    }

    // States (currently) do not inherit from MonoBehaviour. Basic functionality is passed down from the State Machine instead.

	// Pass down Update ticks to States.
    public void Update()
    {
        // Simulate Update ticks in States.
        if (currentState != null && !_inTransition)
        {
			// Call the States "Update"-function called Tick.
            currentState.Tick();
        }

    }

	// Pass down FixedUpdate ticks to States.
    public void FixedUpdate()
    {
        // Simulate FixedUpdate ticks in States.
        if (currentState != null && !_inTransition)
        {
			// Call the States "FixedUpdate"-function called FixedTick.
            currentState.FixedTick();
        }

    }

    #endregion
}