## API Endpoints

### Host Management


| Action             | Method | Endpoint     | Request Body             | Response Body                                                         |
| -------------------- | -------- | -------------- | -------------------------- | ----------------------------------------------------------------------- |
| Create and Confirm | POST   | `/api/hosts` | `{ "name": "HostName" }` | `{ "id": "uniqueHostId", "name": "HostName", "status": "confirmed" }` |

### Client Management


| Action          | Method | Endpoint                 | Request Body               | Response Body                                                                                            |
| ----------------- | -------- | -------------------------- | ---------------------------- | ---------------------------------------------------------------------------------------------------------- |
| Create and Join | POST   | `/api/parties/{id}/join` | `{ "name": "ClientName" }` | `{ "clientId": "uniqueClientId", "name": "ClientName", "partyId": "uniquePartyId", "status": "joined" }` |

### Video Player Controls


| Action      | Method | Endpoint                  | Request Body              | Response Body                                 |
| ------------- | -------- | --------------------------- | --------------------------- | ----------------------------------------------- |
| Play Video  | PUT    | `/api/parties/{id}/play`  | -                         | `{ "status": "playing" }`                     |
| Pause Video | PUT    | `/api/parties/{id}/pause` | -                         | `{ "status": "paused" }`                      |
| Stop Video  | PUT    | `/api/parties/{id}/stop`  | -                         | `{ "status": "stopped" }`                     |
| Seek Video  | PUT    | `/api/parties/{id}/seek`  | `{ "time": "timestamp" }` | `{ "status": "seeked", "time": "timestamp" }` |

### UI Updates


| Action    | Method | Endpoint               | Request Body                | Response Body                                       |
| ----------- | -------- | ------------------------ | ----------------------------- | ----------------------------------------------------- |
| Update UI | PUT    | `/api/clients/{id}/ui` | `{ "uiState": "newState" }` | `{ "status": "ui_updated", "uiState": "newState" }` |

### WebSocket Endpoint


| Action        | Protocol  | Endpoint           |
| --------------- | ----------- | -------------------- |
| Party Updates | WebSocket | `/ws/parties/{id}` |

#### WebSocket Details

- **Connection:** Clients should establish a WebSocket connection to `/ws/parties/{id}` upon joining a party.
- **Incoming Messages:** The server will send messages to all connected clients when events occur (e.g., new member joins, video state changes, UI updates).
- **Message Types:**
  - `memberJoined`: Sent when a new member joins the party.
  - `memberLeft`: Sent when a member leaves the party.
  - `videoStateChanged`: Sent when the video state changes (play, pause, stop, seek, volume).
  - `uiUpdated`: Sent when the UI state is updated.
