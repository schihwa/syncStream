# SyncStream

## Overview

**SyncStream** is a web application designed to synchronize video playback across multiple devices, enabling a shared viewing experience. Users pre-download the video file, reducing latency and bandwidth usage during playback.

### Key Features

- Synchronized video playback across multiple devices
- Basic user management and party creation
- Shared playback controls (play, pause, seek)
- Simple file verification

## Technology Stack

- **Frontend**: Vue.js, HTML, CSS (using Bootstrap for styling)
- **Backend**: .NET Minimal API
- **Real-time Communication**: SignalR
- **Database**: SQLite or MongoDB (for user sessions and party information)
- **Video Player**: Video.js

## Security Considerations

- **File Integrity**: Use checksums to verify file consistency across users.
- **User Authentication**: Simple session-based authentication for party management.
- **Encrypted Communication**: Use HTTPS and WSS for secure communication.

## Development Roadmap

### Phase 1: Basic Functionality

1. **Client-Side Video Player**:

   - Integrate Video.js for video playback.
   - Implement basic playback controls (play, pause, seek).
2. **Server-Side Synchronization**:

   - Set up a .NET Minimal API.
   - Implement WebSocket communication using SignalR.
   - Create synchronization logic to manage playback state.
   - Develop basic party creation and joining functionality.

### Phase 2: User Management and Party Creation

3. **User Management**:

   - Implement session-based authentication.

4. **File Verification**:

   - Implement checksum generation and verification for video files.

## Getting Started

1. Clone the repository
   ```sh
   git clone https://github.com/schihwa/syncstream.git
   ```
2. Navigate to the project directory
   ```sh
   cd syncstream
   ```
