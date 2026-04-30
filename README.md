# Dont Shoot The Bus
![Stars](https://img.shields.io/github/stars/Chazut/Dont-Shoot-The-Bus?style=flat-square&label=STARS&color=007ec6)
![Issues](https://img.shields.io/github/issues/Chazut/Dont-Shoot-The-Bus?style=flat-square&label=ISSUES&color=44cc11)
![Downloads](https://img.shields.io/github/downloads/Chazut/Dont-Shoot-The-Bus/total?style=flat-square&label=DOWNLOADS&color=44cc11)

A lightweight BepInEx mod for SPT that prevents AI bots from targeting the BTR.

## The Problem

PMC bots treat the BTR as a hostile target — they waste ammo shooting at it and reveal their positions for nothing.

## The Fix

Two Harmony patches on `BotsGroup.IsPlayerEnemy` and `BotsGroup.AddEnemy` that ensure:
- The BTR's bot group never considers anyone an enemy
- No bot group can add the BTR as an enemy

Paid cover fire (paying the BTR driver to shoot hostiles) still works normally — it uses a separate targeting system.

## Installation

1. Download the latest release zip
2. Extract into your SPT root folder
3. That's it.

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

- Discovered via [Raid Review](https://forge.sp-tarkov.com/mod/1479/raid-review) bot behavior tracking
