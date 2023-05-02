
# FluxoCaixa

Solution Design
https://celofilho.github.io/c4FluxoCaixa

## Manual running

### Prerequisites

Install [Docker-Desktop](https://www.docker.com/products/docker-desktop/).

Install [.NET Core](https://dotnet.microsoft.com/en-us/download/dotnet/7.0) version >=7.

## Running with Docker
You must install Docker & Docker Compose before. \

At the root of the solution, 
Run each of the commands

```bash
docker-compose build
docker-compose up or docker-compose up -d
```

### Init databases
After running the application successfully, run the following command in visual studio:

```bash
Update-Database
```
