Instructions to repro the PROTOCOL_ERROR:

1. git clone https://github.com/new2helm/healthChecker.git
2. Go to <directory>/healthChecker/HealthChecker
3. docker build -t healthchecker:latest .
4. docker run -i -t healthchecker:latest --name health 
5. (in another terminal) docker container ls | grep "healthchecker:latest”.
6. docker exec -it <container_id> bash


Get Grpcurl: 

1. apt-get update  && apt-get install wget && wget https://github.com/fullstorydev/grpcurl/releases/download/v1.7.0/grpcurl_1.7.0_linux_x86_64.tar.gz
2. tar -xvf grpcurl_1.7.0_linux_x86_64.tar.gz
3. chmod +x grpcurl
4. apt-get install vim && copy https://github.com/new2helm/healthChecker/blob/master/HealthChecker/Protos/health.proto to a file named health.proto
5. Run command ->  ./grpcurl -import-path . -proto health.proto -plaintext -v localhost:5000 grpc.health.v1.Health/Check


Get grpc health probe

1. wget -qO/bin/grpc_health_probe https://github.com/grpc-ecosystem/grpc-health-probe/releases/download/v0.3.1/grpc_health_probe-linux-amd64
2. chmod +x /bin/grpc_health_probe
3. /bin/grpc_health_probe -addr=:5000 -v
