using UnityEngine;

public static class Extensions
{
    private static LayerMask layerMask = LayerMask.GetMask("Default");

    // Checks if the rigidbody is colliding with an object in a given direction.
   
    public static bool Raycast(this Rigidbody2D rigidbody, Vector2 direction)
    {
       

        Vector2 edge = rigidbody.ClosestPoint(rigidbody.position + direction);
        float radius = (edge - rigidbody.position).magnitude / 2f;
        float distance = radius + 0.125f;

        Vector2 point = rigidbody.position + (direction.normalized * distance);
        Collider2D collider = Physics2D.OverlapCircle(point, radius, layerMask);
        return collider != null && collider.attachedRigidbody != rigidbody;
    }

    // Checks if the transform is facing another transform in a given direction.
    
    public static bool DotTest(this Transform transform, Transform other, Vector2 testDirection)
    {
        Vector2 direction = other.position - transform.position;
        return Vector2.Dot(direction.normalized, testDirection) > 0.25f;
    }

}
