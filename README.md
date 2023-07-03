# CustomPlayerInfo
SCP:SL Plugin that allows to set custom player's info.

# HarmonyLib
This plugin require [Harmony](https://github.com/pardeike/Harmony) to works.
Add `0Harmony.dll` (to download in plugin release or official repository) to `dependencies` folder.

# Config
**Tags:**
`{nick}` - Get player's display nickname.
`{unit}` - Get player's unit name.

```yml
enable_plugin: true
disable_power_status_info: true
disable_units_info: false
# {nick} {unit}
custom_info:
  ClassD: >-
    <color=#FF9966>{nick}

    Prisoner</color>
  Scp049: >-
    <color=#C50000>{nick}</color>

    <color=#228B22>Doctor</color>
  Scp173: >-
    <color=#960018>{nick}

    Matthew</color>
```
