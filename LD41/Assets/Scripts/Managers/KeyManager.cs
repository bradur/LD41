// Date   : 23.04.2017 11:09
// Project: Out of This Small World
// Author : bradur

using UnityEngine;
using System.Collections.Generic;

public enum GameAction
{
    None,
    Brake,
    Shoot
}

[System.Serializable]
public class GameKey : System.Object
{
    public KeyCode key;
    public GameAction action;
}

public class KeyManager : MonoBehaviour
{

    [SerializeField]
    private bool debug;

    public static KeyManager main;

    void Awake()
    {
        main = this;
    }

    [SerializeField]
    private HotKeyMap hotkeyMap;

    public bool GetKeyDown(GameAction action)
    {
        if (GetKeyCodeDown(action))
        {
            if (debug)
            {
                Debug.Log(string.Format("Key {0} pressed down to perform {1}.", GetKeyString(action), action.ToString()));
            }
            return true;
        }
        return false;
    }

    public bool GetKeyUp(GameAction action)
    {
        if (GetKeyCodeUp(action))
        {
            if (debug)
            {
                Debug.Log(string.Format("Key {0} let up to perform {1}.", GetKeyString(action), action.ToString()));
            }
            return true;
        }
        return false;
    }

    public bool GetKey(GameAction action)
    {
        if (GetKeyCode(action))
        {
            if (debug)
            {
                Debug.Log(string.Format("Key {0} held to perform {1}.", GetKeyString(action), action.ToString()));
            }
            return true;
        }
        return false;
    }

    private List<KeyCode> mouseKeys = new List<KeyCode>()
    {
        KeyCode.Mouse0, // The Left (or primary) mouse button.
        KeyCode.Mouse1, // Right mouse button (or secondary mouse button).
        KeyCode.Mouse2, // Middle mouse button (or third button).
        KeyCode.Mouse3, // Additional (fourth) mouse button.
        KeyCode.Mouse4, // Additional (fifth) mouse button.
        KeyCode.Mouse5, // Additional (or sixth) mouse button.
        KeyCode.Mouse6  // Additional (or seventh) mouse button.
    };


    private bool GetKeyCode(GameAction action)
    {
        KeyCode keyCode = ActionToKeyCode(action);
        if (keyCode != KeyCode.None)
        {
            if (mouseKeys.Contains(keyCode))
            {
                int mouseButton = -1;
                for (int i = 0; i < mouseKeys.Count; i += 1)
                {
                    KeyCode mouseKey = mouseKeys[i];
                    if (mouseKey == keyCode)
                    {
                        mouseButton = i;
                    }
                }
                if (mouseButton != -1)
                {
                    return Input.GetMouseButton(mouseButton);
                }
            }
            else
            {
                return Input.GetKey(keyCode);
            }
        }
        return false;
    }

    private bool GetKeyCodeDown(GameAction action)
    {
        KeyCode keyCode = ActionToKeyCode(action);
        if (keyCode != KeyCode.None)
        {
            if (mouseKeys.Contains(keyCode))
            {
                int mouseButton = -1;
                for (int i = 0; i < mouseKeys.Count; i += 1)
                {
                    KeyCode mouseKey = mouseKeys[i];
                    if (mouseKey == keyCode)
                    {
                        mouseButton = i;
                    }
                }
                if (mouseButton != -1)
                {
                    return Input.GetMouseButtonDown(mouseButton);
                }
            }
            else
            {
                return Input.GetKeyDown(keyCode);
            }
        }
        return false;
    }


    private bool GetKeyCodeUp(GameAction action)
    {
        KeyCode keyCode = ActionToKeyCode(action);
        if (keyCode != KeyCode.None)
        {
            if (mouseKeys.Contains(keyCode))
            {
                int mouseButton = -1;
                for (int i = 0; i < mouseKeys.Count; i += 1)
                {
                    KeyCode mouseKey = mouseKeys[i];
                    if (mouseKey == keyCode)
                    {
                        mouseButton = i;
                    }
                }
                if (mouseButton != -1)
                {
                    return Input.GetMouseButtonUp(mouseButton);
                }
            }
            else
            {
                return Input.GetKeyUp(keyCode);
            }
        }
        return false;
    }

    public KeyCode ActionToKeyCode(GameAction action)
    {
        foreach (GameKey gameKey in hotkeyMap.Keys)
        {
            if (gameKey.action == action)
            {
                return gameKey.key;
            }
        }
        return KeyCode.None;
    }

    public string GetKeyString(GameAction action)
    {
        foreach (GameKey gameKey in hotkeyMap.Keys)
        {
            if (gameKey.action == action)
            {
                string keyString = gameKey.key.ToString();
                if (gameKey.key == KeyCode.Return)
                {
                    keyString = "Enter";
                }
                else if (gameKey.key == KeyCode.RightControl)
                {
                    keyString = "Right Ctrl";
                }
                return keyString;
            }
        }
        return "";
    }
}
