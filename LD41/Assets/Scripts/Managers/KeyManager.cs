using UnityEngine;
using System.Collections.Generic;

public enum GameAction
{
    None,
    Brake
}

[System.Serializable]
public class GameKey : System.Object
{
    public KeyCode key;
    public GameAction action;
}

public class KeyManager : MonoBehaviour
{

    public static KeyManager main;

    void Awake()
    {
        main = this;
        /*if (GameObject.FindGameObjectsWithTag("KeyManager").Length == 0)
        {
            main = this;
            gameObject.tag = "KeyManager";
        }
        else
        {
            Destroy(gameObject);
        }*/
    }

    [SerializeField]
    private HotKeyMap hotkeyMap;

    public bool GetKeyDown(GameAction action)
    {
        foreach (KeyCode kc in GetKeyCode(action))
        {
            if (Input.GetKeyDown(kc))
            {
                return true;
            }
        }
        return false;
    }

    public bool GetKeyUp(GameAction action)
    {
        foreach (KeyCode kc in GetKeyCode(action))
        {
            if (Input.GetKeyUp(kc))
            {
                return true;
            }
        }

        return false;
    }

    public bool GetKey(GameAction action)
    {
        foreach (KeyCode kc in GetKeyCode(action))
        {
            if (Input.GetKey(kc))
            {
                return true;
            }
        }
        return false;
    }

    public List<KeyCode> GetKeyCode(GameAction action)
    {
        List<KeyCode> keys = new List<KeyCode>();
        foreach (GameKey gameKey in hotkeyMap.Keys)
        {
            if (gameKey.action == action)
            {
                keys.Add(gameKey.key);
            }
        }
        return keys;
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
