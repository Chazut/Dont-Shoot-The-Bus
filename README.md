# Dont Shoot The Bus

A lightweight BepInEx mod for SPT that prevents AI bots from targeting the BTR armored vehicle.

## The Problem

PMC bots treat the BTR as a hostile target — they waste ammo shooting at it and reveal their positions for nothing. The BTR is armored and can't be destroyed by small arms fire, so this behavior is purely detrimental to bot survival.

## The Fix

A single Harmony patch on `BotsGroup.AddEnemy` that prevents the BTR bot shooter from being registered as an enemy. Bots will simply ignore the BTR and focus on actual threats.

## Installation

1. Copy `DontShootTheBus.dll` into `SPT/BepInEx/plugins/`
2. That's it.

## Compatibility

- **SPT 4.0.X**
- Compatible with **SAIN** and other AI mods — this patch runs before any AI decision logic.

## Building from source

1. Copy the following DLLs from your SPT installation into `dependencies/`:
   - `BepInEx/core/BepInEx.dll`
   - `BepInEx/core/0Harmony.dll`
   - `EscapeFromTarkov_Data/Managed/Assembly-CSharp.dll`
   - `EscapeFromTarkov_Data/Managed/UnityEngine.dll`
   - `EscapeFromTarkov_Data/Managed/UnityEngine.CoreModule.dll`
2. Run `dotnet build -c Release`

## Credits

- Discovered via [Raid Review](https://github.com/Chazut/SPT-RaidReview) bot behavior tracking
