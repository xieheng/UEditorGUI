using UnityEngine;
using System;

namespace UEditorGUI
{
    #region UEventArgs

    /// <summary>
    /// 
    /// </summary>
    public class UEventArgs
    {
        #region Data

        /// <summary>
        /// 
        /// </summary>
        private object _sender = null;

        #endregion

        #region Construction

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        public UEventArgs(object sender)
        {
            _sender = sender;
        }

        #endregion

        #region Public

        /// <summary>
        /// 
        /// </summary>
        public object sender
        {
            get { return _sender; }
        }

        #endregion
    }

    #endregion

    #region UTextEventArgs

    /// <summary>
    /// 
    /// </summary>
    public class UTextEventArgs : UEventArgs
    {
        #region Data

        /// <summary>
        /// 
        /// </summary>
        private string _text = string.Empty;

        #endregion

        #region Construction

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="text"></param>
        public UTextEventArgs(object sender, string text)
            : base(sender)
        {
            _text = text;
        }

        #endregion

        #region Public

        /// <summary>
        /// 
        /// </summary>
        public string text
        {
            get { return _text; }
        }

        #endregion
    }

    #endregion

    #region UIntEventArgs

    /// <summary>
    /// 
    /// </summary>
    public class UIntEventArgs : UEventArgs
    {
        #region Data

        /// <summary>
        /// 
        /// </summary>
        private int _value = 0;

        #endregion

        #region Construction

        public UIntEventArgs(object sender, int intValue)
            : base(sender)
        {
            _value = intValue;
        }

        #endregion

        #region Public

        /// <summary>
        /// 
        /// </summary>
        public int value
        {
            get { return _value; }
        }

        #endregion
    }

    #endregion

    #region UFloatEventArgs

    /// <summary>
    /// 
    /// </summary>
    public class UFloatEventArgs : UEventArgs
    {
        #region Data

        /// <summary>
        /// 
        /// </summary>
        private float _value = 0;

        #endregion

        #region Construction

        public UFloatEventArgs(object sender, float intValue)
            : base(sender)
        {
            _value = intValue;
        }

        #endregion

        #region Public

        /// <summary>
        /// 
        /// </summary>
        public float value
        {
            get { return _value; }
        }

        #endregion
    }

    #endregion

    #region UEnumEventArgs

    /// <summary>
    /// 
    /// </summary>
    public class UEnumEventArgs : UEventArgs
    {
        #region Data

        /// <summary>
        /// 
        /// </summary>
        private System.Enum _enum = null;

        #endregion

        #region Construction

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="text"></param>
        public UEnumEventArgs(object sender, System.Enum enumValue)
            : base(sender)
        {
            _enum = enumValue;
        }

        #endregion

        #region Public

        /// <summary>
        /// 
        /// </summary>
        public System.Enum value
        {
            get { return _enum; }
        }

        #endregion
    }

    #endregion

    #region UToggleEventArgs

    /// <summary>
    /// 
    /// </summary>
    public class UToggleEventArgs : UEventArgs
    {
        #region Data

        /// <summary>
        /// 
        /// </summary>
        private bool _toggled = false;

        #endregion

        #region Construction

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="toggled"></param>
        public UToggleEventArgs(object sender, bool toggled)
            : base(sender)
        {
            _toggled = toggled;
        }

        #endregion

        #region Public

        /// <summary>
        /// 
        /// </summary>
        public bool toggled
        {
            get { return _toggled; }
        }

        #endregion
    }

    #endregion

    #region UObjectEventArgs

    /// <summary>
    /// 
    /// </summary>
    public class UObjectEventArgs : UEventArgs
    {
        #region Data

        /// <summary>
        /// 
        /// </summary>
        private System.Object _object = null;

        #endregion

        #region Construction

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="color"></param>
        public UObjectEventArgs(object sender, System.Object value)
            : base(sender)
        {
            _object = value;
        }

        #endregion

        #region Public

        /// <summary>
        /// 
        /// </summary>
        public System.Object targetObject
        {
            get { return _object; }
        }

        #endregion
    }

    #endregion

    #region UBoundsEventArgs

    /// <summary>
    /// 
    /// </summary>
    public class UBoundsEventArgs : UEventArgs
    {
        #region Data

        /// <summary>
        /// 
        /// </summary>
        private Bounds _bounds = new Bounds();

        #endregion

        #region Construction

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="color"></param>
        public UBoundsEventArgs(object sender, Bounds bounds)
            : base(sender)
        {
            _bounds = bounds;
        }

        #endregion

        #region Public

        /// <summary>
        /// 
        /// </summary>
        public Bounds bounds
        {
            get { return _bounds; }
        }

        #endregion
    }

    #endregion

    #region URectEventArgs

    /// <summary>
    /// 
    /// </summary>
    public class URectEventArgs : UEventArgs
    {
        
        #region Data

        /// <summary>
        /// 
        /// </summary>
        private Rect _rect = new Rect();

        #endregion

        #region Construction

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="color"></param>
        public URectEventArgs(object sender, Rect rect)
            : base(sender)
        {
            _rect = rect;
        }

        #endregion

        #region Public

        /// <summary>
        /// 
        /// </summary>
        public Rect rect
        {
            get { return _rect; }
        }

        #endregion
    }

    #endregion

    #region UColorEventArgs

    /// <summary>
    /// 
    /// </summary>
    public class UColorEventArgs : UEventArgs
    {
        #region Data

        /// <summary>
        /// 
        /// </summary>
        private Color _color = Color.white;

        #endregion

        #region Construction

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="color"></param>
        public UColorEventArgs(object sender, Color color)
            : base(sender)
        {
            _color = color;
        }

        #endregion

        #region Public

        /// <summary>
        /// 
        /// </summary>
        public Color color
        {
            get { return _color; }
        }

        #endregion
    }

    #endregion

    #region UAnimationCurveEventArgs

    /// <summary>
    /// 
    /// </summary>
    public class UAnimationCurveEventArgs : UEventArgs
    {
        #region Data

        /// <summary>
        /// 
        /// </summary>
        private AnimationCurve _curve = null;

        #endregion

        #region Construction

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="color"></param>
        public UAnimationCurveEventArgs(object sender, AnimationCurve curve)
            : base(sender)
        {
            _curve = curve;
        }

        #endregion

        #region Public

        /// <summary>
        /// 
        /// </summary>
        public AnimationCurve animationCurve
        {
            get { return _curve; }
        }

        #endregion
    }

    #endregion

    #region  UVector2EventArgs

    /// <summary>
    /// 
    /// </summary>
    public class UVector2EventArgs : UEventArgs
    {
        #region Data

        /// <summary>
        /// 
        /// </summary>
        private Vector2 _vector = Vector2.zero;

        #endregion

        #region Construction

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="color"></param>
        public UVector2EventArgs(object sender, Vector2 vector)
            : base(sender)
        {
            _vector = vector;
        }

        #endregion

        #region Public

        /// <summary>
        /// 
        /// </summary>
        public Vector2 vector2
        {
            get { return _vector; }
        }

        #endregion
    }

    #endregion

    #region  UVector3EventArgs

    /// <summary>
    /// 
    /// </summary>
    public class UVector3EventArgs : UEventArgs
    {
        #region Data

        /// <summary>
        /// 
        /// </summary>
        private Vector3 _vector = Vector3.zero;

        #endregion

        #region Construction

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="color"></param>
        public UVector3EventArgs(object sender, Vector3 vector)
            : base(sender)
        {
            _vector = vector;
        }

        #endregion

        #region Public

        /// <summary>
        /// 
        /// </summary>
        public Vector3 vector3
        {
            get { return _vector; }
        }

        #endregion
    }

    #endregion

    #region  UVector4EventArgs

    /// <summary>
    /// 
    /// </summary>
    public class UVector4EventArgs : UEventArgs
    {
        #region Data

        /// <summary>
        /// 
        /// </summary>
        private Vector4 _vector = Vector4.zero;

        #endregion

        #region Construction

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="color"></param>
        public UVector4EventArgs(object sender, Vector4 vector)
            : base(sender)
        {
            _vector = vector;
        }

        #endregion

        #region Public

        /// <summary>
        /// 
        /// </summary>
        public Vector4 vector4
        {
            get { return _vector; }
        }

        #endregion
    }

    #endregion
}