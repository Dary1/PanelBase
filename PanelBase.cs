using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelBase : MonoBehaviour {

    GameObject CurrentPanel;
    public GameObject SubPanelContainer;

    public void Start()
    {
        if (SubPanelContainer == null)
            SubPanelContainer = this.gameObject;
        UpdateInfo();
    }

    public void EnablePanelByName(string name) {
        SubPanelContainer.transform.Find(name).GetComponent<PanelBase>().EnableThisPanel();
    }

    public virtual void UpdateInfo() {}

    public void EnableThisPanel()
    {
        for (int i = 0; i < this.transform.parent.childCount; i++)
        {            
            this.transform.parent.GetChild(i).gameObject.SetActive(false);            
        }
        this.gameObject.SetActive(false);
        this.gameObject.SetActive(true);//= true;
        UpdateInfo();
    }

    public virtual PanelBase FindEnabledChild() {
        for (int i = 0; i < SubPanelContainer.transform.childCount; i++)
        {
            if (SubPanelContainer.transform.GetChild(i).gameObject.activeSelf) {
                return SubPanelContainer.transform.GetChild(i).GetComponent<PanelBase>();
            }
        }
        return null;
    }

    public void Close()
    {
        this.gameObject.SetActive(false);        
    }

    public void DisableAllChild()
    {
        for (int i = 0; i < this.transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
    }
}
