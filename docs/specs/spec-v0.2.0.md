# Gorilla Tag Replay Format v0.2.0

A `.gtrec` file consists of a header section with metadata about the run, followed by a series of chunks that encode information about events that occur during the run.

## Overall Structure

The overall structure is as follows:

| Name        | Size      | Type                   | Description                                                                   |
| ----------- | --------- | ---------------------- | ----------------------------------------------------------------------------- |
| Magic Bytes | 2 bytes   | hex                    | 0x4754, signals that the file is a gtrec                                      |
| Version     | 2 bytes   | ushort                 | Version number of the recording file                                          |
| Platform    | 1 byte    | byte                   | Platform that the run is on, 0 for PCVR, 1 for Quest, reserved for future use |
| Generator   | 2-n bytes | null terminated string | The name and version of what created the replay, e.g. "GKZv0.1.0"             |
| Map         | 2-n bytes | null terminated string | The full name of the map, e.g. "gkz_blockshard"                               |
| Mods        | 2-n bytes | null terminated string | A list of all mod ids a user has, separated by commas                         |
| Events      | 1-n bytes | Event array            | All the events occurring during the run, by convention in chronological order |

## Events

Each event consists of the following structure:

| Name       | Size      | Type  | Description                                            |
| ---------- | --------- | ----- | ------------------------------------------------------ |
| Type       | 1 byte    | byte  | The type of the event, as defined below                |
| Time       | 4 bytes   | float | The current time in the run                            |
| Other Data | 0-n bytes | any   | Other data associated with the event, as defined below |

### Types

| ID   | Name       | Size     | Description                    |
| ---- | ---------- | -------- | ------------------------------ |
| 0x00 | Left       | 12 bytes | Left hand jump position        |
| 0x01 | Right      | 12 bytes | Right hand hit position        |
| 0x02 | Checkpoint | 16 bytes | Checkpoint position + rotation |
| 0x03 | Teleport   | 16 bytes | Teleport position + rotation   |

#### Left

| Name     | Size     | Type    | Description                             |
| -------- | -------- | ------- | --------------------------------------- |
| Position | 12 bytes | 3*float | The position of the hit, order by x,y,z |

#### Right

| Name     | Size     | Type    | Description                             |
| -------- | -------- | ------- | --------------------------------------- |
| Position | 12 bytes | 3*float | The position of the hit, order by x,y,z |

#### Checkpoint

| Name     | Size     | Type    | Description                                      |
| -------- | -------- | ------- | ------------------------------------------------ |
| Position | 12 bytes | 3*float | The position of the checkpoint, ordered by x,y,z |
| Rotation | 4 bytes  | float   | The y rotation of the checkpoint                 |

#### Teleport

| Name     | Size     | Type    | Description                                    |
| -------- | -------- | ------- | ---------------------------------------------- |
| Position | 12 bytes | 3*float | The position of the teleport, ordered by x,y,z |
| Rotation | 4 bytes  | float   | The y rotation of the teleport                 |
