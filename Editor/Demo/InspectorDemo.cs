using UnityEngine;
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

    enum EnumMaskType
    {
        AM,
        BM,
        CM,
        DM
    }

    public InspectorDemo()
    {
        // label
        {
            UDrawer labelDrawer = new UDrawer("Label Drawer");
            AddWidget(labelDrawer);

            ULabel label = new ULabel("This is a label");
            labelDrawer.AddWidget(label);

            UFixedSpace space = new UFixedSpace(3);
            AddWidget(space);
        }

        // helpbox
        {
            UDrawer helpboxDrawer = new UDrawer("HelpBox Drawer");
            AddWidget(helpboxDrawer);

            UHelpBox helpBox = new UHelpBox("none...", MessageType.None);
            helpboxDrawer.AddWidget(helpBox);
            UHelpBox infoHelpBox = new UHelpBox("information...", MessageType.Info);
            helpboxDrawer.AddWidget(infoHelpBox);
            UHelpBox warningHelpBox = new UHelpBox("warning...", MessageType.Warning);
            helpboxDrawer.AddWidget(warningHelpBox);
            UHelpBox errorHelpBox = new UHelpBox("error...", MessageType.Error);
            helpboxDrawer.AddWidget(errorHelpBox);

            UFixedSpace space = new UFixedSpace(3);
            AddWidget(space);
        }

        // field
        {
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

            //UPropertyField propertyField = new UPropertyField("Property Field", null);
            //fieldDrawer.AddWidget(propertyField);

            UPasswordField passwordFiled = new UPasswordField("Password Field", "123");
            fieldDrawer.AddWidget(passwordFiled);

            UFixedSpace space = new UFixedSpace(3);
            AddWidget(space);
        }

        // slider
        {
            UDrawer sliderDrawer = new UDrawer("Slider Drawer");
            AddWidget(sliderDrawer);

            UIntSlider intSlider = new UIntSlider("Int Slider", 5, 0, 10);
            sliderDrawer.AddWidget(intSlider);

            UFixedSpace space = new UFixedSpace(3);
            AddWidget(space);
        }

        // popup
        {
            UDrawer popupDrawer = new UDrawer("Popup Drawer");
            AddWidget(popupDrawer);

            UEnumPopup enumPopup = new UEnumPopup("Enum Popup", EnumType.B);
            popupDrawer.AddWidget(enumPopup);

            int[] popupValues = new int[] { 1, 3, 5, 7, 9 };
            string[] popupTexts = new string[] { "1", "3", "5", "7", "9" };

            UIntPopup intPopup = new UIntPopup("Int Popup", popupValues[2], popupValues, popupTexts);
            popupDrawer.AddWidget(intPopup);

            ULayerPopup layerPopup = new ULayerPopup("Layer Popup", 0);
            popupDrawer.AddWidget(layerPopup);

            UTagPopup tagPopup = new UTagPopup("Tag Popup", "Untagged");
            popupDrawer.AddWidget(tagPopup);

            UEnumMaskPopup enumMaskPopup = new UEnumMaskPopup("Enum Mask Popup", EnumMaskType.BM);
            popupDrawer.AddWidget(enumMaskPopup);

            UFixedSpace space = new UFixedSpace(3);
            AddWidget(space);
        }

        // button
        {
            UDrawer buttonDrawer = new UDrawer("Button Drawer");
            AddWidget(buttonDrawer);

            UButton button = new UButton("Button");
            button.color = Color.green;
            buttonDrawer.AddWidget(button);

            UHLayout buttonLayout = new UHLayout();
            buttonDrawer.AddLayout(buttonLayout);

            UButton leftButton = new UButton("LeftButton", UButton.Style.Left);
            buttonLayout.AddWidget(leftButton);
            UButton midButton = new UButton("MidButton", UButton.Style.Middle);
            buttonLayout.AddWidget(midButton);
            UButton rightButton = new UButton("RightButton", UButton.Style.Right);
            buttonLayout.AddWidget(rightButton);

            UButton miniButton = new UButton("Mini Button", UButton.Style.Mini);
            miniButton.color = Color.red;
            buttonDrawer.AddWidget(miniButton);

            UHLayout miniButtonLayout = new UHLayout();
            buttonDrawer.AddLayout(miniButtonLayout);

            UButton leftMiniButton = new UButton("Left Mini Button", UButton.Style.MiniLeft);
            miniButtonLayout.AddWidget(leftMiniButton);
            UButton midMiniButton = new UButton("Mid Mini Button", UButton.Style.MiniMiddle);
            miniButtonLayout.AddWidget(midMiniButton);
            UButton rightMiniButton = new UButton("Right Mini Button", UButton.Style.MiniRight);
            miniButtonLayout.AddWidget(rightMiniButton);

            UToggleButton toggleButton = new UToggleButton("Toggle Button");
            toggleButton.color = Color.blue;
            buttonDrawer.AddWidget(toggleButton);

            UHLayout toggleLayout = new UHLayout();
            buttonDrawer.AddLayout(toggleLayout);

            UToggleButton leftToggleButton = new UToggleButton("Left Toggle Button", UToggleButton.Style.Left);
            toggleLayout.AddWidget(leftToggleButton);
            UToggleButton midToggleButton = new UToggleButton("Mid Toggle Button", UToggleButton.Style.Middle);
            toggleLayout.AddWidget(midToggleButton);
            UToggleButton rightToggleButton = new UToggleButton("Right Toggle Button", UToggleButton.Style.Right);
            toggleLayout.AddWidget(rightToggleButton);

            UToggleButton miniToggleButton = new UToggleButton("Mini Toggle Button", UButton.Style.Mini);
            miniToggleButton.color = Color.yellow;
            buttonDrawer.AddWidget(miniToggleButton);

            UHLayout miniToggleLayout = new UHLayout();
            buttonDrawer.AddLayout(miniToggleLayout);

            UToggleButton leftMiniToggleButton = new UToggleButton("Left Mini Toggle Button", UToggleButton.Style.MiniLeft);
            miniToggleLayout.AddWidget(leftMiniToggleButton);
            UToggleButton midMiniToggleButton = new UToggleButton("Mid Mini Toggle Button", UToggleButton.Style.MiniMiddle);
            miniToggleLayout.AddWidget(midMiniToggleButton);
            UToggleButton rightMiniToggleButton = new UToggleButton("Right Mini Toggle Button", UToggleButton.Style.MiniRight);
            miniToggleLayout.AddWidget(rightMiniToggleButton);

            UCheckbox checkbox = new UCheckbox("Right Checkbox");
            buttonDrawer.AddWidget(checkbox);
            UCheckbox leftCheckbox = new UCheckbox("Left Checkbox", UCheckbox.Style.Left);
            buttonDrawer.AddWidget(leftCheckbox);

            URadiobox radiobox = new URadiobox();
            buttonDrawer.AddWidget(radiobox);
        }
    }
}
