using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveButton : MonoBehaviour
{
    public void Set(string go_name, bool open)
    {
        var go = find(go_name);
        if (go)
            go.SetActive(open);

        if (go == null)
            Debug.LogError(go_name + " not found");
    }

    GameObject find(string go_name)
    {
        var list = GameObject.FindObjectsOfType<ActiveObject>(true);
        foreach (var item in list)
        {
            if (item.Name == go_name)
            {
                return item.gameObject;
            }
        }

        return null;
    }

    public void Open(string go_name)
    {
        Set(go_name, true);
    }

    public void Close(string go_name)
    {
        Set(go_name, false);
    }
    /*
    public void SwitchTo(string go_name)
    {
        var go = find(go_name);
        if (go)
            go.GetComponent<GroupObjectForSwitch>().SwitchToThis();
    }*/
}
