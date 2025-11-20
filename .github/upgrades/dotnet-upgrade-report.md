# .NET 10.0 Upgrade Report

## Project target framework modifications

| Project name                                   | Old Target Framework | New Target Framework | Commits                          |
|:-----------------------------------------------|:--------------------:|:--------------------:|:---------------------------------|
| APRS_Passcode.vbproj                           | net48                | net10.0-windows      | b6c205ea, 6b180779, 7b9b2b31, 8e888fee, a39bf9f2 |

## All commits

| Commit ID  | Description                                                     |
|:-----------|:----------------------------------------------------------------|
| b6c205ea   | Commit upgrade plan                                             |
| 6b180779   | Modernize APRS_Passcode.vbproj to SDK-style format              |
| 7b9b2b31   | Remove System.Data.DataSetExtensions reference from APRS_Passcode.vbproj |
| 8e888fee   | Add assembly metadata to APRS_Passcode.vbproj                   |
| a39bf9f2   | Store final changes for step 'Upgrade APRS_Passcode.vbproj'     |

## Project feature upgrades

Contains summary of modifications made to the project assets during different upgrade stages.

### APRS_Passcode.vbproj

Here is what changed for the project during upgrade:

- Converted legacy .NET Framework 4.8 Windows Forms project file to SDK-style simplifying property groups and item groups.
- Updated TargetFramework from net48 to net10.0-windows enabling modern .NET tooling.
- Removed redundant assembly references now implicitly provided by the SDK (System.*, Windows Forms, Drawing, etc.).
- Centralized assembly metadata in the project file (title, company, product, versions, copyright).
- Removed obsolete System.Data.DataSetExtensions reference.

## Next steps

- Build and run the application to verify runtime behavior.
- Add or update unit tests (none were detected) to safeguard future changes.
- Review application configuration (App.config) for any framework-specific settings needing modernization.
