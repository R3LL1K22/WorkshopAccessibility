using UnityEngine;
using UnityEngine.InputSystem;

public class GamepadDebug : MonoBehaviour
{
    void Start()
    {
        foreach (var device in InputSystem.devices)
        {
            Debug.Log("Périphérique détecté : " + device.name);
        }

        if (Gamepad.all.Count == 0)
        {
            Debug.LogWarning("Aucun gamepad détecté !");
        }
        else
        {
            Debug.Log("Nombre de gamepads détectés : " + Gamepad.all.Count);
        }
    }
}