using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

namespace UEditorGUI
{
    /// <summary>
    /// 
    /// </summary>
    public class UMenu : UCaptionWidget
    {
        #region Data

        /// <summary>
        /// 
        /// </summary>
        private List<UMenuItem> _menus = new List<UMenuItem>();

        #endregion

        #region Construction

        /// <summary>
        /// 
        /// </summary>
        /// <param name="caption"></param>
        public UMenu(string caption)
            : base(caption)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="caption"></param>
        /// <param name="style"></param>
        protected UMenu(string caption, GUIStyle style)
            : base(caption)
        {
            this.style = style;
        }

        #endregion

        #region Override

        /// <summary>
        /// 
        /// </summary>
        protected override void UpdateGUI()
        {
            this.style = (style == GUIStyle.none) ? GUI.skin.FindStyle("DropDownButton") : style;
            Rect rect = GUILayoutUtility.GetRect(new GUIContent(caption), style, GUILayout.ExpandWidth(false));

            if (GUI.Button(rect, caption, style))
            {
                GenericMenu menu = new GenericMenu();

                for (int i = 0; i < _menus.Count; i++)
                {
                    UMenuItem item = _menus[i];

                    item.SetParent(menu);
                    item.OnGUI();
                }

                menu.DropDown(rect);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        protected override void ActiveToolbarGuiStyle()
        {
            this.style = EditorStyles.toolbarDropDown;
        }

        #endregion

        #region Public

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        public void AddItem(UMenuItem item)
        {
            _menus.Add(item);
        }

        #endregion
    }
}