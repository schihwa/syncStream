# SyncStream: MVP Design Document

## Technology Stack

- **Frontend**: Vue.js, HTML, CSS (using Bootstrap for styling)
- **Backend**: .NET Minimal API
- **Real-time Communication**: SignalR
- **Database**: SQLite or MongoDB (for user sessions and party information)
- **Video Player**: Video.js

## 1. Project Overview

**SyncStream** is a web application designed to synchronize video playback across multiple devices, enabling a shared viewing experience. Users pre-download the video file, reducing latency and bandwidth usage during playback.

- Synchronized video playback across multiple devices
- Basic user management and party creation
- Shared playback controls (play, pause, seek)
- Simple file verification

## 3. System Architecture

### 3.1 Client-Side Components

- **Video Player**: HTML5 video player (e.g., Video.js)
- **Sync Module**: Handles local playback synchronization based on server instructions
- **User Interface**: Provides controls for video playback and basic party management

### 3.2 Server-Side Components

- **Synchronization Server**: Manages playback state across all clients using WebSocket
- **User Management Service**: Handles user sessions and party creation
- **File Verification Service**: Ensures users have the correct video file via checksum verification

### 3.3 Communication Protocol

- **WebSocket**: For real-time communication between clients and server

## 4. Data Flow

1. Users download the video file and join a party.
2. Server verifies file integrity across all users using checksums.
3. Host initiates playback.
4. Server broadcasts playback state to all clients.
5. Clients adjust local playback based on server instructions.

## 5. Security Considerations

- **File Integrity**: Use checksums to verify file consistency across users.
- **User Authentication**: Simple session-based authentication for party management.
- **Encrypted Communication**: Use HTTPS and WSS for secure communication.

## 8. Development Roadmap

### Phase 1: Basic Functionality

1. **Client-Side Video Player**:

   - Integrate Video.js for video playback.
   - Implement basic playback controls (play, pause, seek).
2. **Server-Side Synchronization**:

   - Set up a .NET Minimal API.
   - Implement WebSocket communication using SignalR.
   - Create synchronization logic to manage playback state.

### Phase 2: User Management and Party Creation

3. **User Management**:

   - Implement session-based authentication.
   - Develop basic party creation and joining functionality.
4. **File Verification**:

   - Implement checksum generation and verification for video files.
