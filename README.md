# BackupHelper
Interface implementation of the library https://github.com/user413/FileControlUtility
- Lightweight interface
- Includes binary comparison and renaming
- Groups of settings are saved into profiles for later execution
------------
Alternatively profiles can be executed directly without the interface:
#### CMD example:
```batch
BackupHelper.exe -nd profilename1;profilename2;profilename3
```
Optional -nd tag can be added to avoid error dialogs during executions
