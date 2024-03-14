# .NET Native AOT - Overview and Performance

*This repo contains the slides and example code for the Thinktecture Webinar about .NET Native AOT, held on March 6th 2024.*

Watch the Webinar in German language on YouTube:

[![Watch the German Webinar on YouTube](https://img.youtube.com/vi/Iiu4VAQO64A/hqdefault.jpg)](https://youtu.be/Iiu4VAQO64A?si=GgQKUdkLkTNUz87F)

## How to build and run the example

To run the example, please ensure that you have the following things installed:

- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download)
- [docker](https://www.docker.com/get-started/)

Execute the following statements on a command line of your choice:

```bash
docker compose -f docker-compose.postgres-dev.yml up -d
cd WebApp
dotnet publish -o bin/native-aot
cd bin/native-aot
```

This will spin up a PostgreSQL database and publish the ASP.NET Core app in Native AOT mode.
On Windows, use `./WebApp.exe` to start the app. On Mac OS X and Linux, use `./WebApp` instead.

You can then use the WebApp/requests.http file to issue different requests against the web app. Rider, Visual Studio and Visual Studio Code have built-in support for .http files.

## How to run the throughput benchmark

To execute the spike load test, you need to have [Grafana k6](https://k6.io/) installed.

You should first checkout the corresponding branch in git:

```bash
git checkout in-memory-spike-test
```

In one terminal, start the web app in regular CLR mode (make sure that no other instance is running on localhost:5000):

```bash
cd WebApp
dotnet run -c Release
```

Then execute k6 in another terminal:

```bash
k6 run spike-test.js
```

After the test, do the same thing for the Native AOT version and compare the results.
