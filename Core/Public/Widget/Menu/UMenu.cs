using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// 
/// </summary>
public class UMenu : UControl
{
    #region Data

    /// <summary>
    /// 
    /// </summary>
    private List<UMenuItem> _items = new List<UMenuItem>();

    #endregion

    #region Override

    public override void OnGUI()
    {
        GenericMenu menu = new GenericMenu();

        for (int i=0; i<_items.Count; i++)
        {
            UMenuItem item = _items[i];

            if (item.IsEnabled)
            {
                menu.AddItem(new GUIContent(item.Caption), false, item.OnClickedHandler);
            }
            else
            {
                menu.AddDisabledItem(new GUIContent(item.Caption));
            }
        }
    }

    #endregion

    #region Public

    /// <summary>
    /// 
    /// </summary>
    /// <param name="item"></param>
    public void AddItem(UMenuItem item)
    {
        if (item != null || !_items.Contains(item))
        {
            _items.Add(item);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="item"></param>
    public void RemoveItem(UMenuItem item)
    {
        if (item != null)
        {
            _items.Remove(item);
        }
    }

    #endregion
}
