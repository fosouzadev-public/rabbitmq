# RabbitMQ

Container utilizado:
```shell
docker run -d --hostname rabbit-server --name rabbit-docker -e RABBITMQ_DEFAULT_USER=admin -e RABBITMQ_DEFAULT_PASS=Abc-123456 -p 15672:15672 -p 5672:5672 rabbitmq:3-management
```