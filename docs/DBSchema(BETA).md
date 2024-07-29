## In-Memory Database Schema

### Host Management


| Column Name | Data Type | Description       |
| ------------- | ----------- | ------------------- |
| `id`        | `string`  | Unique identifier |
| `name`      | `string`  | Host name         |
| `status`    | `string`  | Host status       |

### Client Management


| Column Name | Data Type | Description       |
| ------------- | ----------- | ------------------- |
| `id`        | `string`  | Unique identifier |
| `name`      | `string`  | Client name       |
| `status`    | `string`  | Client status     |

### Party Management


| Column Name | Data Type | Description               |
| ------------- | ----------- | --------------------------- |
| `id`        | `string`  | Unique identifier         |
| `hostId`    | `string`  | Foreign key to Host table |
| `status`    | `string`  | Party status              |

### Party Members


| Column Name | Data Type | Description                 |
| ------------- | ----------- | ----------------------------- |
| `partyId`   | `string`  | Foreign key to Party table  |
| `clientId`  | `string`  | Foreign key to Client table |
| `status`    | `string`  | Join status                 |

### Video Player Controls


| Column Name | Data Type | Description                             |
| ------------- | ----------- | ----------------------------------------- |
| `partyId`   | `string`  | Foreign key to Party table              |
| `status`    | `string`  | Video status (playing, paused, stopped) |
| `time`      | `string`  | Timestamp for seek action               |
| `volume`    | `integer` | Volume level (0-100)                    |

### WebSocket Messages


| Column Name | Data Type | Description                                                           |
| ------------- | ----------- | ----------------------------------------------------------------------- |
| `type`      | `string`  | Message type (memberJoined, memberLeft, videoStateChanged, uiUpdated) |
| `clientId`  | `string`  | Foreign key to Client table                                           |
| `partyId`   | `string`  | Foreign key to Party table                                            |
| `content`   | `json`    | Message content JSON object                                           |
| `timestamp` | `string`  | Message timestamp                                                     |
