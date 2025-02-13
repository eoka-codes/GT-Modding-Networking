# GT-Modding-Networking

A simple and single-file library for creating networked mods for Gorilla Tag. This library provides an easy way to implement networking features in your mods, allowing for enhanced multiplayer experiences.

## Features

- Lightweight and easy to integrate
- Supports basic networking functionalities
- Single-file implementation for convenience

## Installation

1. Download the `NetworkingLib.cs` file.
2. Place it in your Gorilla Tag mod directory under `BepInEx/plugins`.
3. Reference the library in your mod project.

## Usage

To use the library with BepInEx, include it in your mod and initialize the networking features. Here’s a basic example:

```csharp
using BepInEx;
using ModsNetworking;
using UnityEngine;

[BepInPlugin("com.yourname.example", "My awesome networked plugin", "1.0.0")]
public class MyMod : BaseUnityPlugin
{
    private ModNetworking _modNetworking;

    private void Awake()
    {
        _modNetworking = new ModNetworking(1); // Initialize with a channel number
        _modNetworking.OnMessageReceived += HandleMessage;
    }

    private void HandleMessage(object message)
    {
        // Handle the received message
        Debug.Log($"Received message: {message}");
    }

    public void SendMessage(string messageContent)
    {
        _modNetworking.SendMessage(messageContent);
    }
}
```
