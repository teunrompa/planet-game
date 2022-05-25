using UnityEngine;

public abstract class Building : MonoBehaviour
{
     public int id = 0;

     [Header("Building Data")] [SerializeField]
     public float cost = 200;

     [SerializeField] public float inhabitants = 20;

     private PlayerController _playerController;

     public GameObject resourceManager;
     public Resources resources;

     private void Awake()
     {
          _playerController = FindObjectOfType<PlayerController>();
          resourceManager = GameObject.Find("ResourceManager");
          resources = resourceManager.GetComponent<Resources>();
          
          id = GetInstanceID();
     }

}


