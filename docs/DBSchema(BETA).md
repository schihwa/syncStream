### Clients Table


| Column Name | Data Type       | Description                         | Constraints                                                                | Indexes                                        |
| ------------- | ----------------- | ------------------------------------- | ---------------------------------------------------------------------------- | ------------------------------------------------ |
| `id`        | `UUID`          | Unique identifier (UUID)            | PRIMARY KEY                                                                | **Primary Index** on `id`                      |
| `partyId`   | `UUID`          | Foreign key to Party table          | FOREIGN KEY (`partyId`) REFERENCES `PartyManagement(id)` ON DELETE CASCADE | **Index** on `partyId` (`idx_clients_partyId`) |
| `name`      | `VARCHAR(255)`  | Client name                         | NOT NULL                                                                   |                                                |
| `isHost`    | `BOOLEAN`       | Indicates if the client is the host | NOT NULL                                                                   |                                                |
| `picture`   | `VARCHAR(2048)` | URL to profile picture              | NOT NULL                                                                   |                                                |

### Video State Table


| Column Name | Data Type                                         | Description                                         | Constraints                                                                | Indexes                                                                        |
| ------------- | --------------------------------------------------- | ----------------------------------------------------- | ---------------------------------------------------------------------------- | -------------------------------------------------------------------------------- |
| `partyId`   | `UUID`                                            | Foreign key to the Party table                      | FOREIGN KEY (`partyId`) REFERENCES `PartyManagement(id)` ON DELETE CASCADE | **Index** on `partyId` (`idx_videoState_partyId`)                              |
| `status`    | `ENUM('playing', 'paused', 'stopped', 'waiting')` | Video status                                        | NOT NULL                                                                   | **Composite Index** on (`partyId`, `status`) (`idx_videoState_partyId_status`) |
| `time`      | `TIME`                                            | Timestamp for the current seek position             | NOT NULL                                                                   |                                                                                |
| `updatedAt` | `DATETIME`                                        | Timestamp of the last update to the player controls | NOT NULL                                                                   |                                                                                |

### Party Management Table


| Column Name      | Data Type      | Description                             | Constraints                                                       | Indexes                                              |
| ------------------ | ---------------- | ----------------------------------------- | ------------------------------------------------------------------- | ------------------------------------------------------ |
| `id`             | `UUID`         | Unique identifier (UUID)                | PRIMARY KEY                                                       | **Primary Index** on `id`                            |
| `hostId`         | `UUID`         | Foreign key to the host (Client table)  | FOREIGN KEY (`hostId`) REFERENCES `Clients(id)` ON DELETE CASCADE | **Index** on `hostId` (`idx_partyManagement_hostId`) |
| `numberOfPeople` | `INTEGER`      | Number of people currently in the party | NOT NULL                                                          |                                                      |
| `password`       | `VARCHAR(255)` | Password for party access (hashed)      | NOT NULL                                                          |                                                      |
