using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

namespace UEditorGUI.Internal.Styles
{
    /// <summary>
    /// 
    /// </summary>
    public class UEditorStyles : ScriptableObject
    {
        /// <summary>
        /// 
        /// </summary>
        public List<Texture2D> icons = new List<Texture2D>();

        /// <summary>
        /// 
        /// </summary>
        public List<GUISkin> skins = new List<GUISkin>();
    }
}