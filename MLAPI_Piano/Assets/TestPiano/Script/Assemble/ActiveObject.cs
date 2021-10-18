using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class ActiveObject : MonoBehaviour
{
    [InlineButton("GetName")]
    public string Name;

    void GetName()
    {
        Name = name;
    }
}
