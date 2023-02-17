using UnityEngine;

public class PlantZone : MonoBehaviour { 
    public bool isright = false;
    public Plant plant;
    private string direction;

    private void Start() {
        if (isright)
        {
            direction = "right";
        }
        else 
        {
            direction = "left";
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player")
        {
            plant.Playerinzone(direction);
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.tag == "Player")
        {
            plant.Playernotinzone(direction);
        }
    }
}

