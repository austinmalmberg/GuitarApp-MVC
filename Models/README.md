Entity Relationships
====================

[TOC]

## Artist

| Key				| DataType	| Default	| Description						|
| ---				| ---		| ---		| ---								|
| ArtistID			| Integer	|    		| PRIMARY KEY						|
| Name				| String	|    		| Artist name						|
| Created			| DateTime	| Now		| The date the artist was created	|


## Song

| Key				| DataType	| Default	| Description					|
| ---				| ---		| ---		| ---							|
| SongID			| Integer	|    		| PRIMARY KEY					|
| Name				| String	|    		| Song name						|
| BaseTuning		| String	| Standard	| The base guitar tuning		|
| CapoPosition		| Integer	| 0  		| The base capo posiiton		|
| Created			| DateTime	| Now  		| The date the song was created	|
| LastUpdated		| DateTime	| Now  		| The last update to the song	|
| ArtistID			| Integer	|    		| FK representing an artist		|
| ContributorID		| Integer	|			| FK representing a user		|
|					|			|			|								|
| Artist			| Artist	|    		| Navigational Property			|
| Contributor		| User		|    		| Navigational Property			|


## SetlistEntry

| Key				| DataType	| Default	| Description							|
| ---				| ---		| ---		| ---									|
| SetlistEntryID	| Integer	|    		| PRIMARY KEY							|
| MasteryLevel		| Integer	| 0   		| The user's skill level for the song	|
| Created			| DateTime	| Now  		| The date the song was created			|
| LastPlayed		| DateTime	| Now  		| The last time the song was played		|
| UserID			| Integer	|    		| FK representing a user				|
| SongID			| Integer	|			| FK representing a song				|
| SetlistID			| Integer	|			| FK representing a setlist				|
|					|			|			|										|
| User				| User		|    		| Navigational Property					|
| Song				| Song		|    		| Navigational Property					|
| Setlist			| Setlist	|    		| Navigational Property					|


## Setlist

| Key				| DataType		| Default	| Description								|
| ---				| ---			| ---		| ---										|
| SetlistID			| Integer		|    		| PRIMARY KEY								|
| Name				| String		|			| The name of the setlist					|
| Created			| DateTime		| Now  		| The date the setlist was created			|
| LastUpdated		| DateTime		| Now  		| The last time the setlist was modified	|
| UserID			| Integer		|    		| FK representing a user					|
|					|				|			|											|
| User				| User			|    		| Navigational Property						|
| SetlistEntries	| SetlistEntry	|    		| Navigational Property						|


