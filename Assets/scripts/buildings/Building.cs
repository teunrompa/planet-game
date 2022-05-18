using UnityEngine;

public abstract class Building : MonoBehaviour
{
     [Header("Building Data")] [SerializeField]
     public float cost = 200;

     [SerializeField] public float inhabitants = 20;

     protected PlayerController _playerController;

     public GameObject resourceManager;
     public Resources resources;

     private void Awake()
     {
          _playerController = FindObjectOfType<PlayerController>();
          resourceManager = GameObject.Find("ResourceManager");
          resources = resourceManager.GetComponent<Resources>();
     }

     protected abstract void Build();
}


