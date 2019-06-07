/*
 * Functionality for getting components in siblings.
 * Helt jäkla onödig, eftersom jag tog fram den för att
 * hämta partikelsystem som fucking ligger på children.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ComponentExtension
{
    public static T GetComponentInSibling<T>(this Component component)
    {
        var parent = component.transform.parent;
        return parent.GetComponentInChildren<T>();
    }


    public static T[] GetComponentsInSibling<T>(this Component component)
    {
        var parent = component.transform.parent;
        return parent.GetComponentsInChildren<T>();
    }
}
