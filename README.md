#### Run the app with Docker


```bash
$ docker network create kitchen # creating a docker network to connect the containers 
$ docker build -t kitchen-server-image -f ./Kitchen/Dockerfile . # create docker image for kitchen
$ docker run --net kitchen -d -p 8000:8000 --name kitchen-cont kitchen-server-image # run the created container on the network
```
