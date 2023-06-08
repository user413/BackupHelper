## 1.5.2

Fixed/altered:
- Rearrange profiles - fixed

## 1.5.1

New features:
- Support for environment variables in filtered files/extensions/directories

Fixed/altered:
- Opening folders (using windows shell) - fix

## 1.5.0

Database not compatible with previous versions

New features:
- Filter directories
- Most errors won't cause the transfer to be entirely cancelled - FileControlUtility 1.3.0 (https://github.com/user413/FileControlUtility)
- Delete multiple profiles/transfer options
- Transition from .NET Framework 4.7.2 to .NET 7

## 1.4.3

Fixed/altered:
- Allow transfer of paths starting with "\\" (server) - FileControlUtility 1.2.1
- Generated profile shortcut bat file now end with "pause"

## 1.4.2

Fixed/altered:
- Execution for source paths containing environment variables - fix
	
## 1.4.1

Fixed/altered:
- Parameter execution for options with paths containing environment variables - fix
- Single open edit option window - fix

## 1.4.0

Database not compatible with previous version

New features:
- Options to re-enumerate and limit the quantity of files enumerated with the pattern "&lt;name&gt; (&lt;number&gt;)&lt;extension&gt;" (rename different files) - adapted to 
	FileControlUtility v1.1.0 library

Fixes/changes:
- Display log text on cmd window when executing profiles through parameters - fix
- Ignored files log and report text - fix

## 1.3.0

Database compatible with previous version

New features:
- Option to create execution bat file for selected profiles

Fixes/changes:
- Allow parameter executions while the program is running with the interface

## 1.2.0

Database not compatible with previous version

New features:
- Source and destiny paths can contain environment variables
- Profile grouping
- Drag and drop reordering

## 1.1.2

Database compatible with previous version

Fixes/changes:
- Improvements in library FileControlUtility
- Adapted code with FileControlUtility (v1.0.0)
- Support for readonly files
