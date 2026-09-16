using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    private Dictionary<string, Panel> _panelList = new Dictionary<string, Panel>();
    public override void Awake()
    {
        base.Awake();
        var existPanels = GetComponentsInChildren<Panel>(true);
        foreach (var panel in existPanels)
        {
            _panelList[panel.name] = panel;
        }
    }
    public Panel GetPanel(string panelName)
    {
        if (_panelList.ContainsKey(panelName))
        {
            Panel panel = _panelList[panelName];
            return panel;
        }
        Panel loadedPanel = Resources.Load<Panel>("PanelPrefabs/" + panelName);
        Panel newPanel = Instantiate(loadedPanel, transform);
        newPanel.transform.SetAsLastSibling();
        newPanel.gameObject.SetActive(false);

        _panelList[panelName] = newPanel;
        return newPanel;
    }
    public void OpenPanel(string panelName)
    {
        Panel panel = GetPanel(panelName);
        panel.Show();
    }
    public void ClosePanel(string panelName)
    {
        Panel panel = GetPanel(panelName);
        panel.Hide();
    }
    public void CloseAllPanel()
    {
        foreach (var panel in _panelList.Values)
        {
            panel.Hide();
        }
    }

}