using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ULayout : UControl
{
    #region Data

    /// <summary>
    /// 
    /// </summary>
    protected List<UControl> _children = new List<UControl>();

    #endregion

    #region Override

    /// <summary>
    /// 
    /// </summary>
    public override void OnGUI()
    {
        BeginGUI();
        {
            for (int i = 0; i < _children.Count; i++)
            {
                UControl child = _children[i];
                child.OnGUI();
            }
        }
        EndGUI();
    }

    #endregion

    #region Public

    /// <summary>
    /// Add a widget into
    /// </summary>
    /// <param name="widget"></param>
    public void AddWidget(UWidget widget)
    {
        if (widget != null && !_children.Contains(widget))
        {
            _children.Add(widget);
        }
    }

    /// <summary>
    /// Add a layout into
    /// </summary>
    /// <param name="layout"></param>
    public void AddLayout(ULayout layout)
    {
        if (layout != null && !_children.Contains(layout))
        {
            _children.Add(layout);
        }
    }

    #endregion

    #region Private

    /// <summary>
    /// 
    /// </summary>
    protected virtual void BeginGUI()
    {

    }

    /// <summary>
    /// 
    /// </summary>
    protected virtual void EndGUI()
    {

    }

    #endregion
}
