using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Manages a collection of flower plants and attached flowers.
/// </summary>
public class FlowerArea : MonoBehaviour
{
    // Diameter area to indicate the relative distance between the agent and flowers.
    public const float AreaDiameter = 20f;

    // The list of all flower plants in this flower area.
    private List<GameObject> flowerPlants;

    // A lookup dictionary for looking up a flower from a nectar collider
    private Dictionary<Collider, Flower> nectarFlowerDictionary;

    /// <summary>
    /// The list of all flowers in the flower area.
    /// </summary>
    public List<Flower> Flowers { get; private set; }

    /// <summary>
    /// Resert the flowers and flower plants.
    /// </summary>
    public void ResetFlowers()
    {
        // Rotate each flower in the flower around the Y axis and subtly around X and Z
        foreach (GameObject flowerPlant in flowerPlants)
        {
            float xRotation = UnityEngine.Random.Range(-5f, 5f);
            float yRotation = UnityEngine.Random.Range(-180f, 180f);
            float zRotation = UnityEngine.Random.Range(-5f, 5f);

            flowerPlant.transform.localRotation = Quaternion.Euler(xRotation, yRotation, zRotation);
        }

        // Reset each flower
        foreach (Flower flower in Flowers)
        {
            flower.ResetFlower();
        }
    }

    /// <summary>
    /// Get the <see cref="Flower"/> that a nectar collider belongs to
    /// </summary>
    /// <param name="collider">The nectar collider</param>
    /// <returns>The matrching flower</returns>
    public Flower GetFlowerFromNectar(Collider collider)
    {
        return nectarFlowerDictionary[collider];
    }


    /// <summary>
    /// Called when the area wakes up.
    /// </summary>
    private void Awake()
    {
        flowerPlants = new List<GameObject>();
        nectarFlowerDictionary = new Dictionary<Collider, Flower>();
        Flowers = new List<Flower>();

        // Find all flowers that are children of this GameObject/Transform
        FindChildFlowers(transform);
    }

    /// <summary>
    /// Recusively finds all flower that are children of a parent GameObject/Transform
    /// </summary>
    /// <param name="parent">The parent of the children to check</param>
    private void FindChildFlowers(Transform parent)
    {
        for (int i = 0; i < parent.childCount; i++)
        {
            Transform child = parent.GetChild(i);

            if (child.CompareTag("flower_plant"))
            {
                // Find a flower plant, add it to the flowerPlants list
                flowerPlants.Add(child.gameObject);

                // Look for flowers within the flower plant
                FindChildFlowers(child);
            }
            else 
            {
                // Not a flower plant, look for a Flower component
                Flower flower = child.GetComponent<Flower>();
                if (flower != null) 
                {
                    // Add the flower 
                    Flowers.Add(flower);

                    // Add the nectar collider
                    nectarFlowerDictionary.Add(flower.nectarCollider, flower);
                }
                else 
                {
                    FindChildFlowers(child);
                }
            }
        }
    }

}
