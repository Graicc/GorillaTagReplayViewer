# Gorilla Tag Replay Format v0.1.0

A `.gtrec` file simply consists of a series of a series of 17-byte chunks encoding information about events that occour during the run.

The event format is as follows

|Name|Size|Type|Description|
|----|----|----|-----------|
|Header|1 byte|byte|The type of the chunk, 0 for left hand touch, 1 for right hand touch|
|Time|4 bytes|float|The current time in the run|
|Position|12 bytes|Vector3\<float>|The position of the hit, as an array of x, y, and z|

See [this file](https://github.com/Graicc/GorillaKZ/blob/8a34e2c81614a7e16e238854719df26a44f58f87/GorillaKZ/Behaviours/ReplayManager.cs) for a reference as to how the recorder is implemented, and see [this file](https://github.com/Graicc/GorillaTagReplayViewer/blob/2e03705c030dd001b6c37b8b39f816f4056e2a70/src/Assets/Scripts/ReplayLoader.cs) for a reference as to how replays are loaded.
