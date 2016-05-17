using UnityEngine;

public static class KeyboardConfig {
    public static KeyCode Forward = KeyCode.D;
    public static KeyCode Backward = KeyCode.A;
    public static KeyCode Up = KeyCode.W;
    public static KeyCode Down = KeyCode.S;

    public static KeyCode Jump = KeyCode.Space;
    public static KeyCode Use = KeyCode.E;

    public static bool GetKey(string Key) {
        Key = Key.ToLower();

        bool ReturnValue;

        switch (Key) {
            case "forward":
                ReturnValue = Input.GetKey(Forward);
                break;
            case "backward":
                ReturnValue = Input.GetKey(Backward);
                break;
            case "up":
                ReturnValue = Input.GetKey(Up);
                break;
            case "down":
                ReturnValue = Input.GetKey(Down);
                break;
            case "jump":
                ReturnValue = Input.GetKey(Jump);
                break;
            case "use":
                ReturnValue = Input.GetKey(Use);
                break;
            default:
                Debug.Log("Invalid key given!");
                ReturnValue = false;
                break;
        }

        return ReturnValue;
    }

    public static bool GetKeyDown(string Key) {
        Key = Key.ToLower();

        bool ReturnValue;

        switch (Key) {
            case "forward":
                ReturnValue = Input.GetKeyDown(Forward);
                break;
            case "backward":
                ReturnValue = Input.GetKeyDown(Backward);
                break;
            case "up":
                ReturnValue = Input.GetKeyDown(Up);
                break;
            case "down":
                ReturnValue = Input.GetKeyDown(Down);
                break;
            case "jump":
                ReturnValue = Input.GetKeyDown(Jump);
                break;
            case "use":
                ReturnValue = Input.GetKeyDown(Use);
                break;
            default:
                Debug.Log("Invalid key given!");
                ReturnValue = false;
                break;
        }

        return ReturnValue;
    }

    public static bool GetKeyUp(string Key) {
        Key = Key.ToLower();

        bool ReturnValue;

        switch (Key) {
            case "forward":
                ReturnValue = Input.GetKeyUp(Forward);
                break;
            case "backward":
                ReturnValue = Input.GetKeyUp(Backward);
                break;
            case "up":
                ReturnValue = Input.GetKeyUp(Up);
                break;
            case "down":
                ReturnValue = Input.GetKeyUp(Down);
                break;
            case "jump":
                ReturnValue = Input.GetKeyUp(Jump);
                break;
            case "use":
                ReturnValue = Input.GetKeyUp(Use);
                break;
            default:
                Debug.Log("Invalid key given!");
                ReturnValue = false;
                break;
        }

        return ReturnValue;
    }
}
