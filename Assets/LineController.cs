using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineController : MonoBehaviour
{
    public Material lineMaterial;
    public LayerMask ignoreMask;
    LineRenderer line;
    bool isAim => aim==0;
    int aim=1;
    // Start is called before the first frame update
    private void Awake()
    {
        line = GetComponent<LineRenderer>();
        line.enabled = false;
        line.material = lineMaterial;
    }
    void LineMove()
    {
        lineMaterial.SetTextureOffset("_MainTex", new Vector2(lineMaterial.mainTextureOffset.x - .5f * Time.deltaTime, lineMaterial.mainTextureOffset.y));
    }
    // Update is called once per frame
    void Update()
    {
        PlayerInput();
        
        if (isAim)
        {
            LineMove();
            Aiming();
        }
        else
        {
            line.enabled = false;
        }
    }
    void Aiming()
    {
        line.positionCount=1;
        line.enabled = true;
        Vector3 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - Camera.main.transform.position - transform.position; 
        RaycastHit2D hit= Physics2D.Raycast(transform.position, direction , Mathf.Infinity, ~ignoreMask);
        line.SetPosition(0, transform.position);
        if (hit)
        {
            line.positionCount++;
            line.SetPosition(1, hit.point);
            direction = Vector2.Reflect(direction, hit.normal);
            Debug.Log(direction);
            hit = Physics2D.Raycast(hit.point, direction, Mathf.Infinity, ~ignoreMask);
            if (hit)
            {
                line.positionCount++;
                line.SetPosition(2, hit.point);
            }
            /*for (int i = 2; i < 4; i++)
            {
                direction = Vector2.Reflect(direction, hit.normal);
                hit = Physics2D.Raycast(transform.position, direction, Mathf.Infinity, ~ignoreMask);
                if (hit)
                {
                    line.positionCount++;
                    line.SetPosition(i, hit.point);
                }
                else return;
            }*/
        }
        
    }
    void PlayerInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            aim = 0;
        }
        if (Input.GetMouseButtonUp(0))
        {
            aim = 1;
        }
    }
}
