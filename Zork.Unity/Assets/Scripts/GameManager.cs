using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zork;

public class GameManager : MonoBehaviour
{
    

    void Awake()
    {
        TextAsset gameJsonAsset = Resources.Load<TextAsset>(ZorkGameFileAssetName);
        
        Game.Start(gameJsonAsset.text, InputService, OutputService);
        Game.Instance.CommandManager.PerformCommand(Game.Instance, "LOOK");

    }

    private void Start()
    {
        
    }

    void Update()
    {
        
    }

    [SerializeField]
    private string ZorkGameFileAssetName = "Zork";

    [SerializeField]
    private UnityOutputService OutputService;

    [SerializeField]
    private UnityInputService InputService;
}
