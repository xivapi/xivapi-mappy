# Mappy

Mapping application for Maps.

This mapper comes with custom json structures, do not delete that file!!!!!!!!!!!!!!!!!!!!

### To update decimals:

This project uses custom **MAPINFO** and **ZONEINFO** decimals, for example:

```json
  {
    "Key": "MAPINFO",
    "Value": "",
    "SigScanAddress": {
      "value": 0
    },
    "ASMSignature": false,
    "Offset": 0,
    "PointerPath": [
	  25198120
    ]
  },
  {
    "Key": "ZONEINFO",
    "Value": "",
    "SigScanAddress": {
      "value": 0
    },
    "ASMSignature": false,
    "Offset": 0,
    "PointerPath": [
	  24893876
    ]
  },
```

## Finding offset again for Mapper:

**MAP TERRITORY**

| ID | Map |
| --- | --- |
| 166 | Haukke Manor |
| 134 | Summerford Farms |
| 135 | Lower La Noscea |

### Haukke Manor

**MAP IDs**

| ID | Name |
| --- | --- |
| 48 | Ground Floor |
| 54 | Second Floor |
| 55 | Cellerage |

**MAP ZONE**

| ID | Name |
| --- | --- |
| 599 | Ground Floor |
| 600 | Second Floor |
| 601 | Cellerage |


Finding offset using cheat engine!:

- Go to Haukku
- Do first boss and open celleter
- Going up/down the stairs (first steep) will switch between Cellarage and Ground floor
- Go to ground floor (This is the first floor you're on)
	- Open Cheat engine
	- Attach to ffxiv_dx11
      - You do not need to chang any other settings
	- In Value enter: 599
	- Press "First Scan"
	- A lot of stuff will be found
- In game, go down the steps until "cellarage" shows up on the screen (and the map changes)
- Go back on cheat engine and enter 601 and click "NEXT SCAN"
- Keep repeating until you get 1 or a "few" entries
	- The correct/final address will be in **GREEN**
	- Once you find the green address, double click it.
- You now have the value in your list at the bottom
- If you run up and down stairs this should change between 601 and 599 in REAL-TIME
	- In the list at the bottom, double click the "address" bit (the 7FF7ED8CXXXX bit)
	- A modal will appear called "Change address"
    - You should see something like: `ffxiv_dx11.exe+17BD9BC` in the **Address:** field
	- Open up windows calculator, change to "Programmer" mode and click "Hex"
	- Paste the values after the + in. eg: `17BD9BC`
	- Switch back to Decimal, and copy the number, eg: 24893884
    - Minus 8 from it
		- That number is your "offset"
- In mappy app:
  - Open `signatures-x64.json` in sublime or a text editor
  - Look for the entry: **ZONEINFO** `"Key": "ZONEINFO",`
  - Ensure `ASMSignature` is `false`
  - Remove any values in `PointerPath` (it might have 0,0 inside it)
  - Add the new decimal in there, you should have something like this:
  
```json
  {
    "ASMSignature": false,
    "Key": "ZONEINFO",
    "PointerPath": [
      25925516
    ],
    "Value": "4056415641578b9108be0000488bf1448b35"
  },
```

  - Restart the app
        
To confirm this, close the game and restart it. Repeat the whole process and you should get the same number/address, or just wing it :D

If you need to fix **MAPINFO** then use the same process and use the values from **Haukke Manor MAP IDs** above.


## some data

Teleport to summerford farms

```
Map ID: 15
Map Index: 162
Map Territory: 134
```

```
Outputting Target:

Name: Tiny Mandragora
Level: 5
HP: 91/91
MP: 0/0
Model ID: 1053917952
NPCID 1: 3929859
NPCID 2: 118
Owner ID: 3758096384
Memory ID: 1073884831
Map ID: 15
Map Index: 162
Map Territory: 134
Is Casting: No
Is Claimed: No
Is Fate: No
Status: Idle
Type: Monster
Target Type: 232
Position: X 119.310180664063 / Y -169.146240234375 / Z 72.6660614013672
Distance from player: 31.82966
---------------------------------------------------------
```


coerthas central highlands
```
Outputting Target:

Name: House Fortemps Guard
Level: 41
HP: 9185/9185
MP: 8150/8150
Model ID: 1073002752
NPCID 1: 4291467
NPCID 2: 1774
Owner ID: 3758096384
Memory ID: 1073742831
Map ID: 53
Map Index: 380
Map Territory: 155
Is Casting: No
Is Claimed: No
Is Fate: No
Status: Idle
Type: Monster
Target Type: 232
Position: X 177.878494262695 / Y -190.71240234375 / Z 301.664611816406
Distance from player: 19.64223
---------------------------------------------------------

```

### Cheat engine lua debug code

```
THE BLACK SHROUD

Map ID: 6
Map Index: 78
Map Territory: 153


function _sigScan()
  local results=AOBScan("48897C243833FF89B9C0000000C681CD000000008B0D")
  if (results~=nil) then
    local count=stringlist_getCount(results)
    if (count>=1) then
      local address=stringlist_getString(results,0)
      local addrNum = tonumber(address, 16)
      local calcAddr = readInteger(addrNum + 22)
      address = string.format("%X", addrNum + 20 + calcAddr + 6)
      print("address: " .. address)
    end
    object_destroy(results)
    results=nil
  else
    print("nothing")
  end
end
_sigScan()
```


