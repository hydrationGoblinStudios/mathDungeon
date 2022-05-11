using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToMouse : MonoBehaviour
{
    private GridLayout GridLayout;
    public static List<MoveToMouse> moveableObjects = new List<MoveToMouse>();
    public float speed = 5f;
    private Vector3 target;
    private bool selected;
    public GridLayout grid;
    public Vector3 targetCell;
    GridMaracutaia gridMaracutaia;
    // Start is called before the first frame update
    void Start()
    {
        gridMaracutaia = grid.gameObject.GetComponent<GridMaracutaia>();
        moveableObjects.Add(this);
        target = transform.position;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1)&& selected)
        {
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            target.x = target.x + 0.5f;
            target.y = target.y + 0.5f;
            target.z = transform.position.z;
            targetCell = grid.WorldToCell(target);
            Debug.Log(targetCell);
        }
        transform.position = Vector3.MoveTowards(transform.position, targetCell, speed * Time.deltaTime);
    }
    private void OnMouseDown()
    {
        selected = true;
        foreach (MoveToMouse obj in moveableObjects)
        {
            if (obj != this)
            {
                obj.selected = false;
                obj.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
            }
            else
            {
                obj.gameObject.GetComponent<SpriteRenderer>().color = Color.green;
            }
        }
    }
}