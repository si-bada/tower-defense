using UnityEngine;
using UnityEngine.EventSystems;
public class Stone : MonoBehaviour
{
    #region Script Parameters
    public Color HoverColor;
    public Color NotEnoughMoneyColor;
    public Vector3 Offset;
    #endregion

    #region Fields
    [HideInInspector]
    public  GameObject turret;
    private Renderer myRenderer;
    private Color startColor;
    private BuildingManager buildingManager;
    #endregion

    #region Unity Methods
    private void Start()
    {
        myRenderer = GetComponent<Renderer>();
        startColor = myRenderer.material.color;
        buildingManager = BuildingManager.sIntance;
    }

    private void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;
        if (!buildingManager.CanBuild)
            return;
        if(buildingManager.HasMoney)
        {
            myRenderer.material.color = HoverColor;
        }
        else
        {
            myRenderer.material.color = NotEnoughMoneyColor;
        }
    }

    private void OnMouseExit()
    {
        myRenderer.material.color = startColor;
    }

    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;
        if (!buildingManager.CanBuild)
            return;
        if (turret != null)
        {
            Debug.LogWarning("can't build there! -- Display on screen");
            return;
        }
        buildingManager.BuildTurretOn(this);
    }
    #endregion

    #region Methods
    public Vector3 GetBuildPosition()
    {
        return transform.position + Offset;
    }
    #endregion

}
