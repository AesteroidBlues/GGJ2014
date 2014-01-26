using UnityEngine;
using System.Collections;
using XInputDotNetPure;

public class XInputManager : MonoBehaviour {
    
    public static Vector3 GetSticks( PlayerIndex p ) {
        GamePadState state = GamePad.GetState( p );
        return new Vector3( state.ThumbSticks.Left.X, state.ThumbSticks.Left.Y, 0 );
    }

    public static bool GetXButton( PlayerIndex p ) {
        GamePadState state = GamePad.GetState( p );
        return state.Buttons.X == ButtonState.Pressed ? true : false;
    }

    public static bool GetAButton( PlayerIndex p ) {
        GamePadState state = GamePad.GetState( p );
        return state.Buttons.A == ButtonState.Pressed ? true : false;
    }

    public static bool GetStart(PlayerIndex p)
    {
        GamePadState state = GamePad.GetState(p);
        return state.Buttons.Start == ButtonState.Pressed ? true : false;
    }
}
