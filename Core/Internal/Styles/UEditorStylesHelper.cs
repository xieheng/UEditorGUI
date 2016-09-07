using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

namespace UEditorGUI.Internal.Styles
{
    /// <summary>
    /// 
    /// </summary>
    internal class UEditorStylesHelper
    {
        #region Data

        /// <summary>
        /// 
        /// </summary>
        private Dictionary<string, GUISkin> skinMap = new Dictionary<string, GUISkin>();

        /// <summary>
        /// 
        /// </summary>
        private Dictionary<string, Texture2D> iconMap = new Dictionary<string, Texture2D>();

        #endregion

        #region Instance

        /// <summary>
        /// 
        /// </summary>
        private  static UEditorStylesHelper _instance = null;

        /// <summary>
        /// 
        /// </summary>
        public static UEditorStylesHelper Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new UEditorStylesHelper();
                    _instance.Load();
                }

                return _instance;
            }
        }

        #endregion

        #region Public 

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public GUISkin GetSkin(string name)
        {
            return skinMap[name];
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Texture2D GetIcon(string name)
        {
            return iconMap[name];
        }

        #endregion

        #region Private 

        /// <summary>
        /// 
        /// </summary>
        private void Load()
        {
            UEditorStyles styles = AssetDatabase.LoadAssetAtPath("", typeof(UEditorStyles)) as UEditorStyles;

            if (styles == null)
            {
                Debug.LogError("Load styles of editor gui failed");
                return;
            }

            foreach (GUISkin skin in styles.skins)
            {
                skinMap.Add(skin.name, skin);
            }

            foreach (Texture2D icon in styles.icons)
            {
                iconMap.Add(icon.name, icon);
            }
        }

        #endregion
    }
}