using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class BoolValue : ScriptableObject, ISerializationCallbackReceiver
{
    public bool initialValue;
    [HideInInspector]
    public bool RuntimeValue;

    public void OnAfterDeserialize()
    {
        //End Game
        RuntimeValue = initialValue;
    }
    public void OnBeforeSerialize()
    {
        //Start Game
    }
}
