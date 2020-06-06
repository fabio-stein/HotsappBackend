@ECHO OFF
cd ../
docker build -t hotsapp/playlist-worker -f PlayWorker/Dockerfile .
docker push hotsapp/playlist-worker
PAUSE