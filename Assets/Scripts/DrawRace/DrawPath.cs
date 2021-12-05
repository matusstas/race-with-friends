using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawPath : MonoBehaviour
{
    public GameObject linePrefab;
    public List<Vector2> drawnPositions;
    GameObject line = null;
    LineRenderer lineRenderer;
    PolygonCollider2D polygonCollider;

    // Start is called before the first frame update
    void Start()
    {

    }

    private Vector2 getMousePosition()
    {
        // Debug.Log("Mouse Position before: " + Input.mousePosition);
        // Debug.Log("Mouse Position after: " + Camera.main.ScreenToWorldPoint(Input.mousePosition));
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mousePosition2d = new Vector2(mousePosition.x, mousePosition.y);
        return mousePosition2d;
    }

    // track mouse position in world space
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            if (Helpers.GetGameObjectUnderMouse2D() == null)
            {
                line = Instantiate(linePrefab, transform);
                lineRenderer = line.GetComponent<LineRenderer>();
                polygonCollider = line.GetComponent<PolygonCollider2D>();
            }
        }

        // if mouse is pressed
        if (Input.GetMouseButton(0))
        {
            if (line != null)
            {

                Vector2 mousePos = getMousePosition();
                // if last mouse position is at least 0.2 away from current mouse position
                if (drawnPositions.Count == 0 || Vector2.Distance(drawnPositions[drawnPositions.Count - 1], mousePos) > 0.2f)
                {

                    drawnPositions.Add(mousePos);
                    lineRenderer.positionCount++;
                    lineRenderer.SetPosition(lineRenderer.positionCount - 1, mousePos);

                    int numberOfLines = drawnPositions.Count - 1;
                    polygonCollider.pathCount = numberOfLines;
                    for (int i = 0; i < numberOfLines; i++)
                    {
                        // Get the two next points
                        List<Vector2> currentPositions = new List<Vector2> { drawnPositions[i], drawnPositions[i + 1] };
                        List<Vector2> currentColliderPoints = CalculateColliderPoints(currentPositions);
                        polygonCollider.SetPath(i, currentColliderPoints.ConvertAll(p => (Vector2)transform.InverseTransformPoint(p)));
                    }
                }
                // transform line position to 0, 0
                line.transform.position = Vector2.zero;
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            drawnPositions.Clear();
            line = null;
        }
    }

    // author theblankdev
    // https://theblankdev.itch.io/linerenderseries
    private List<Vector2> CalculateColliderPoints(List<Vector2> positions)
    {
        //Get The Width of the Line
        float width = 0.1f;

        // m = (y2 - y1) / (x2 - x1)
        float m = (positions[1].y - positions[0].y) / (positions[1].x - positions[0].x);
        float deltaX = (width / 2f) * (m / Mathf.Pow(m * m + 1, 0.5f));
        float deltaY = (width / 2f) * (1 / Mathf.Pow(1 + m * m, 0.5f));

        //Calculate Vertex Offset from Line Point
        Vector2[] offsets = new Vector2[2];
        offsets[0] = new Vector2(-deltaX, deltaY);
        offsets[1] = new Vector2(deltaX, -deltaY);

        List<Vector2> colliderPoints = new List<Vector2> {
            positions[0] + offsets[0],
            positions[1] + offsets[0],
            positions[1] + offsets[1],
            positions[0] + offsets[1]
        };

        return colliderPoints;
    }
}

