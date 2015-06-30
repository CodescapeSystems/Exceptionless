# Codescape Exceptionless extensions

This is a simple set of helper extensions for logging to exceptionless.

### Version
1.0.0

### Installation
Install using nuget

```sh
$ install-package Codescape.Exceptionless
```
### Setup
If logging to exceptionless is managed via this library all logging can be switched on or off
via the use os application configuration.

```sh
<add key="ExceptionlessLoggingEnabled" value="true" />
```

### Usage
To use this library you can simply use the default exceptionless client.

```sh
// Default info log
ExceptionlessClient.Default.Log(message);

// Default info log with tags
ExceptionlessClient.Default.LogWithTags(message, new[] { "Tag1", "Tag2" });

// Specify source and level
ExceptionlessClient.Default.Log(message, "Log source", LogLevels.Warn);
```

Log levels have four options.
- Info
- Warn
- Error
- Critical