using UnityEngine;

public class ChoosingMap : MonoBehaviour {
    public string mapName = "";
    public void ChooseMap1() {
        gameObject.SetActive(false);
        mapName = "Arena3";
    }
    public void ChooseMap2() {
        gameObject.SetActive(false);
        mapName = "Other";
    }
}
