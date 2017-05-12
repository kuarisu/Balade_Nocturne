using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager_GameObjectsReferences : MonoBehaviour {

    public static Manager_GameObjectsReferences Instance;
    private void Awake()
    {
        if (Manager_GameObjectsReferences.Instance != null)
        {
            Destroy(this.gameObject);
            return;
        }

        Manager_GameObjectsReferences.Instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    public GameObject m_Player;
}
