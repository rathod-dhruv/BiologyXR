using UnityEngine;
using Lean.Touch;


//Actions On User Touch are managed by this Script
public class InputController : MonoBehaviour
{
    private static bool canScaleAndRotate;

    public static float MinScaleForObject = 0.2f;
    public static float MaxScaleForObject = 2.5f;
    public GameObject go;
    public GameObject animationUI;

    private void Start()
    {
        canScaleAndRotate = false;
    }

    private void Update()
    {
        if (go == null)
            go = GameObject.FindGameObjectWithTag("Parent");
        PinchToScaleModel();
    }

    public void SwipeToRotateModel(LeanFinger finger)
    {
        if (!go)
            return;
        if (finger.IsOverGui || animationUI.activeInHierarchy || !canScaleAndRotate) return;
            go.transform.parent.transform.Rotate(Vector3.up, LeanGesture.GetScaledDelta().x * -0.1f);

    }


    public void TapToSelectPart(LeanFinger finger)
    {
        if (!canScaleAndRotate) return;
        Vector2 screenPos = finger.StartScreenPosition;
        Ray ray = Camera.main.ScreenPointToRay(screenPos);
    }



    public void PinchToScaleModel()
    {
        if (!go)
            return;

        if (!canScaleAndRotate || animationUI.activeInHierarchy) return;

        foreach (LeanFinger finger in LeanTouch.Fingers)
        {
            if (finger.IsOverGui) return;
        }
        float newScale = LeanGesture.GetPinchScale() * go.transform.parent.localScale.x; //Assuming all three axis scale factors are equal
        
        go.transform.parent.localScale = Mathf.Clamp(newScale, MinScaleForObject, MaxScaleForObject) * Vector3.one;
        
    }

    public static void ToggleManipulationGestures(bool enable)
    {
        canScaleAndRotate = enable;
    }


}
