using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    [SerializeField] Color hoverColor;
    [SerializeField] Color notEnoughMoneyColor;
    [SerializeField] Vector3 positionOffset;
    GameObject turret;
    Color startColor;
    Renderer nodeRenderer;
    BuildManager build;

    private void Awake()
    {
        nodeRenderer = GetComponent<Renderer>();
        startColor = nodeRenderer.material.color;
    }
    private void Start()
    {
        build = BuildManager.Instance;
    }
    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }
    public void SetTurret(GameObject whichTurret)
    {
        turret = whichTurret;
    }
    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;
        if (!build.CanBuild)
            return;
        if (turret != null)
        {
            Debug.Log("Can't build there! - TODO : Display on screen");
            return;
        }
        build.BuildTurretOn(this);
    }
    private void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;
        if (!build.CanBuild)
            return;
        if (build.HasMoney)
            nodeRenderer.material.color = hoverColor;
        else
            nodeRenderer.material.color = notEnoughMoneyColor;
    }
    private void OnMouseExit()
    {
        nodeRenderer.material.color = startColor;
    }
}