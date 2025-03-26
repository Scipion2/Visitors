using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControls : MonoBehaviour
{
    
    [SerializeField] private Movement MoveFunc; 
    InputAction MoveAction,JumpAction,RunAction;

    public void Start()
    {

        MoveAction=InputSystem.actions.FindAction("Move");
        JumpAction=InputSystem.actions.FindAction("Jump");
        RunAction=InputSystem.actions.FindAction("Run");

    }

    public void Update()
    {

        MoveFunc.Move(MoveAction.ReadValue<Vector2>());

        if(JumpAction.IsPressed())
            MoveFunc.Jump();

        if(RunAction.IsPressed())
            MoveFunc.Run();
        else
            MoveFunc.WalkBack();

    }

}
