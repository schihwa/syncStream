# SyncStream: MVP Design Document

## Table of Contents

1. [Technology Stack](#technology-stack)
2. [Project Overview](#project-overview)
3. [System Architecture](#system-architecture)
   - [Client-Side Components](#client-side-components)
   - [Server-Side Components](#server-side-components)
4. [Database Schema](#database-schema)
   - [Clients Table](#clients-table)
   - [Video State Table](#video-state-table)
   - [Party Management Table](#party-management-table)
5. [User Interface](#user-interface)
   - [Homepage](#homepage)
   - [Partypage](#partypage)
6. [API Endpoints Overview](#api-endpoints-overview)
   - [Host Management](#host-management)
   - [Client Management](#client-management)
   - [Video Player Controls](#video-player-controls)
   - [WebSocket Endpoint](#websocket-endpoint)


## Project Overview

**SyncStream** is a web application designed to synchronize video playback across multiple devices, providing a seamless shared viewing experience. The key objectives include:

- **Pre-downloaded Files**: Users download video files in advance to minimize latency and save bandwidth during playback.
- **Synchronized Playback**: Ensures all devices stay in sync while playing the video.
- **Basic User Management**: Allows users to create and join viewing parties.
- **Shared Playback Controls**: Users can collectively play, pause, or seek the video.

## User Interface

### Homepage
- **Pick Name**: Option to pick a name.
- **Optional Image**: Option to upload an image.
- **Host Option**:
  - Server Name
  - Password
- **Client Option**:
  - Server Name
  - Password

## System Architecture

### Client-Side Components

- **Video Player**: Integrated with Video.js to manage video playback.
- **Sync Module**: Ensures video playback is synchronized based on server instructions.
- **User Interface**: Provides controls for video playback and party management.

### Server-Side Components

- **Synchronization Server**: Utilizes SignalR for WebSocket-based communication to manage and broadcast video playback state to all connected clients.
- **User Management Service**: Handles user sessions, party creation, and maintains client records.

## Technology Stack

- **Frontend**: Vue.js for dynamic user interfaces, HTML, and CSS with Bootstrap for styling.
- **Backend**: .NET Minimal API for lightweight and efficient server-side logic.
- **Real-time Communication**: SignalR for WebSocket-based real-time updates.
- **Database**: SQLite for managing user sessions, party details, and synchronization data.
- **Video Player**: Video.js for a customizable and robust video playback experience.

## Database Schema

We have three main tables in our database:

### Clients Table
This table keeps track of all the users (clients) in our system.
- Each client has a unique ID.
- We store which party they're in, their name, and whether they're the host of a party.
- We also save a link to their profile picture.

### Video State Table

This table manages the current state of video playback for each party.
- We link each video state to a specific party.
- We keep track of whether the video is playing, paused, or in another state.
- We record the current position in the video and when this information was last updated.

### Party Management Table

This table handles the details of each viewing party.
- Each party has a unique ID.
- We store who the host is, how many people are in the party, and a password for joining the party.

### Partypage
- Displays the server status (either empty or joined).

## API Endpoints Overview

### Host Management

- **Create and Confirm Host**: Allows the creation of a new host and confirms their status. This endpoint is used to register a new host in the system.

### Client Management

- **Create and Join Party**: Enables a new client to join an existing party. This endpoint registers the client and associates them with a specified party.

### Video Player Controls

- **Play Video**: Initiates video playback for a specified party.
- **Pause Video**: Pauses the video playback for a specified party.
- **Stop Video**: Stops the video playback for a specified party.
- **Seek Video**: Adjusts the video playback to a specific timestamp for a specified party.

### WebSocket Endpoint

- **Party Updates**: Establishes a WebSocket connection to receive real-time updates about party members and video status. This connection allows clients to stay informed about changes such as new members joining, video state changes, and UI updates.