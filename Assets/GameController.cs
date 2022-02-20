using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController Instance;
    public TMP_Dropdown resolutionDropdown;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        //This code enables you to access the GameController object from any other script. 
        Instance = this;
        DontDestroyOnLoad(gameObject); // Persist this object between scenes
    }

    public GameObject[] playerControllers;

    private GameObject selectedController;

    // Start is called before the first frame update
    void Start()
    {
        selectedController = Instantiate(playerControllers[0], new Vector3(0, 0, 0), Quaternion.identity);

        resolutionDropdown.AddOptions(playerControllers.Select(s => s.name).ToList());

        resolutionDropdown.onValueChanged.AddListener(delegate
        {
            DropdownItemSelected(resolutionDropdown);
        });
    }

    void DropdownItemSelected(TMP_Dropdown dropdown)
    {
        int index = dropdown.value;

        GameObject temp = selectedController;

        Destroy(selectedController);

        selectedController = Instantiate(playerControllers[index], temp.transform.position, temp.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {

    }

}
