
# API Endpoints

## Host Management

### Create and Confirm Host
- **Method**: POST
- **Endpoint**: `/api/hosts`
- **Description**: Creates a new host and confirms it.
- **Request Body**:
  ```json
  {
    "name": "HostName",
    "image": "base64EncodedImage",
    "password": "HostPassword"
  }
  ```
- **Response**:
  ```json
  {
    "id": "uniqueHostId",
    "name": "HostName",
    "status": "confirmed"
  }
  ```
- **Errors**:
  - `400 Bad Request`: Invalid request body.
  - `401 Unauthorized`: Bad password.
  - `500 Internal Server Error`: Server error.

## Client Management

### Create and Join Party
- **Method**: POST
- **Endpoint**: `/api/parties/{id}/join`
- **Description**: Creates a new client and joins a party.
- **Request Body**:
  ```json
  {
    "name": "ClientName",
    "image": "base64EncodedImage",
    "password": "ClientPassword"
  }
  ```
- **Response**:
  ```json
  {
    "clientId": "uniqueClientId",
    "name": "ClientName",
    "partyId": "uniquePartyId",
    "status": "joined"
  }
  ```
- **Errors**:
  - `400 Bad Request`: Invalid request body.
  - `401 Unauthorized`: Wrong password.
  - `404 Not Found`: Party not found.
  - `500 Internal Server Error`: Server error.

## Video Player Controls

### Play Video
- **Method**: PUT
- **Endpoint**: `/api/parties/{id}/play`
- **Description**: Plays the video for the specified party.
- **Response**:
  ```json
  {
    "status": "playing"
  }
  ```
- **Errors**:
  - `404 Not Found`: Party not found.
  - `500 Internal Server Error`: Server error.

### Pause Video
- **Method**: PUT
- **Endpoint**: `/api/parties/{id}/pause`
- **Description**: Pauses the video for the specified party.
- **Response**:
  ```json
  {
    "status": "paused"
  }
  ```
- **Errors**:
  - `404 Not Found`: Party not found.
  - `500 Internal Server Error`: Server error.

### Stop Video
- **Method**: PUT
- **Endpoint**: `/api/parties/{id}/stop`
- **Description**: Stops the video for the specified party.
- **Response**:
  ```json
  {
    "status": "stopped"
  }
  ```
- **Errors**:
  - `404 Not Found`: Party not found.
  - `500 Internal Server Error`: Server error.

### Seek Video
- **Method**: PUT
- **Endpoint**: `/api/parties/{id}/seek`
- **Description**: Seeks the video to a specific timestamp for the specified party.
- **Request Body**:
  ```json
  {
    "timestamp": "00:10:00"
  }
  ```
- **Response**:
  ```json
  {
    "status": "seeked",
    "timestamp": "00:10:00"
  }
  ```
- **Errors**:
  - `400 Bad Request`: Invalid request body.
  - `404 Not Found`: Party not found.
  - `500 Internal Server Error`: Server error.
