﻿using UnityEngine;
using UnityEditor;
using UEditorGUI;

/// <summary>
/// 
/// </summary>
class InspectorDemoObject : UInspectorTargetObject
{
    
}

/// <summary>
/// A demo of UInspector
/// </summary>
[CustomEditor(typeof(InspectorDemoObject))]
public class InspectorDemo : UInspector
{
    enum EnumType
    {
        A,
        B,
        C,
        D
    }

    public InspectorDemo()
    {

        UDrawer labelDrawer = new UDrawer("Label Drawer");
        AddWidget(labelDrawer);

        ULabel label = new ULabel("This is a label");
        labelDrawer.AddWidget(label);

        UDrawer helpboxDrawer = new UDrawer("HelpBox Drawer");
        AddWidget(helpboxDrawer);

        UHelpBox helpBox = new UHelpBox("HelpBox", MessageType.Info);
        helpboxDrawer.AddWidget(helpBox);

        UDrawer fieldDrawer = new UDrawer("Field Drawer");
        AddWidget(fieldDrawer);

        UTextField textField = new UTextField("Text Filed");
        fieldDrawer.AddWidget(textField);

        UIntField intField = new UIntField("Int Field");
        fieldDrawer.AddWidget(intField);

        UFloatField floatField = new UFloatField("Float Field");
        fieldDrawer.AddWidget(floatField);

        UObjectField objectField = new UObjectField("Object Field", typeof(GameObject));
        fieldDrawer.AddWidget(objectField);

        UAnimationCurveField curveField = new UAnimationCurveField("AnimationCurve Filed");
        fieldDrawer.AddWidget(curveField);

        UColorField colorField = new UColorField("Color Field");
        fieldDrawer.AddWidget(colorField);

        UBoundsField boundsField = new UBoundsField("Bounds Field");
        fieldDrawer.AddWidget(boundsField);

        URectField rectField = new URectField("Rect Field");
        fieldDrawer.AddWidget(rectField);

        UVector2Filed vector2Field = new UVector2Filed("Vector2 Field");
        fieldDrawer.AddWidget(vector2Field);

        UVector3Filed vector3Field = new UVector3Filed("Vector3 Field");
        fieldDrawer.AddWidget(vector3Field);

        UVector4Filed vector4Field = new UVector4Filed("Vector4 Field");
        fieldDrawer.AddWidget(vector4Field);

        USearchField searchField = new USearchField("Search Field");
        fieldDrawer.AddWidget(searchField);

        UDrawer sliderDrawer = new UDrawer("Slider Drawer");
        AddWidget(sliderDrawer);

        UIntSlider intSlider = new UIntSlider("Int Slider", 5, 0, 10);
        sliderDrawer.AddWidget(intSlider);

        UDrawer popupDrawer = new UDrawer("Popup Drawer");
        AddWidget(popupDrawer);

        UEnumPopup enumPopup = new UEnumPopup("Enum Popup", EnumType.B);
        popupDrawer.AddWidget(enumPopup);

        int[] popupValues = new int[] { 1, 3, 5, 7, 9 };
        string[] popupTexts = new string[] { "1", "3", "5", "7", "9" };

        UIntPopup intPopup = new UIntPopup("Int Popup", popupValues[2], popupValues, popupTexts);
        popupDrawer.AddWidget(intPopup);

        UDrawer buttonDrawer = new UDrawer("Button Drawer");
        AddWidget(buttonDrawer);

        UButton button = new UButton("Button");
        button.color = Color.green;
        buttonDrawer.AddWidget(button);

        UMiniButton miniButton = new UMiniButton("Mini Button");
        miniButton.color = Color.red;
        buttonDrawer.AddWidget(miniButton);

        UToggleButton toggleButton = new UToggleButton("Toggle Button");
        buttonDrawer.AddWidget(toggleButton);
    }
}