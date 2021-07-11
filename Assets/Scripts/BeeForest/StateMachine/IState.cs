public interface IState
{
    /// <summary>
    /// The Interface that all States inherit from.
    /// </summary>

    // Signals the change to a new State. Gets called automatically in the State Machine.
    void Enter();
    // Allows simulation of Update() method without a MonoBehaviour attached.
    void Tick();
    // Allows simulation of FixedUpdate() method without a MonoBehaviour attached.
    void FixedTick();
    // Signals the change from an old state to a new one. Gets called automatically in the State Machine.
    void Exit();
}